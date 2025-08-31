/**
 * @file ShopModeManager.cs
 * @brief ショップモードの処理、管理
 * @author Sum1r3
 * @date 2025/7/18
 */
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameConst;

public class ShopModeManager : SystemObject{
    //制限時間
    private float _limitTime;
    private const float _LIMIT_MAX_TIME = 60;
    //時間を減らすかどうか
    private bool _isReduceTime = false;
    //スコア
    private int _score = 0;
    //今のショップモードステート
    public ShopModeState shopModeState ;
    //自身のインスタンス
    public static ShopModeManager instance;
    //今接待中か否か
    private bool _isHospitality = false;
    //ゲーム中に開く予定のキャンバス
    [SerializeField]
    private GameObject _startEndCanvas;
    //キャンバスの中のテキスト
    [SerializeField]
    private TextMeshProUGUI _canvasText;
    //ゲーム中に開く予定のキャンバス
    [SerializeField]
    private GameObject _timerScoreCanvas;
    //キャンバスのタイマーの中のテキスト
    [SerializeField]
    private TextMeshProUGUI _timerText;
    //キャンバスの中のスコア表示テキスト
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    //ゲーム終了状態か否か
    public bool isGameEnd { get; private set; }


    /// <summary>
    /// 初期化
    /// </summary>
    public override async void Initialize() {
        
        instance = this;
        _limitTime = _LIMIT_MAX_TIME;
        _score = 0;
        shopModeState = ShopModeState.Start;
        _isReduceTime = false;
        _isHospitality = false;
        GameStartCanvasText();
        _startEndCanvas.SetActive(true);
        isGameEnd = false;
        await FadeManager.instance.FadeIn();
    }

    public async void Update() {
        //制限時間を減らす
        if (_isReduceTime && _limitTime > 0)
            _limitTime -= Time.deltaTime;
        if(_limitTime < 0)
            //制限時間が来たのでこれをつける
            isGameEnd = true;

        //制限時間が0でお客さん対応中で無ければリザルトに遷移
        if(_limitTime < 0  && !_isHospitality) 
            shopModeState = ShopModeState.Result;

        switch (shopModeState) {
            case ShopModeState.Start:

                if (Input.GetMouseButtonDown(0)) {
                    shopModeState = ShopModeState.Game;
                    RoundManager.instance.ChangeState(RoundManager.GameState.Come);
                    _startEndCanvas.SetActive(false);
                    
                }
                break;
            case ShopModeState.Game:
                //本当はここに色々な処理を置いてメインのように扱うべきでした(後悔)
                if (_limitTime > 0)
                    _timerText.text = "TimeLimit\n" + _limitTime.ToString("F2");
                else
                    _timerText.text = "TimeLimit\n0.00";

                _scoreText.text = "Score\n" + _score;

                break;
            case ShopModeState.Result:
                //ゲーム終了時にキャンバスを表示
                GameEndCanvasText();
                _startEndCanvas.SetActive(true);
                if(Input.GetMouseButtonDown(0)) {
                    //フェードイン
                    await FadeManager.instance.FadeOut();
                    SceneManager.LoadScene(TITLE_SCENE_NAME);
                }

                break;
           
        }
    }


    /// <summary>
    /// スコア加算
    /// </summary>
    /// <param name="evaluationScore"></param>
    public void AddScore(EvaluationScore evaluationScore) {
        _score += (int)evaluationScore;
    }

    /// <summary>
    /// 時間を減らすかをセット
    /// </summary>
    /// <param name="isReduceTime"></param>
    public void SetIsReduceTime(bool isReduceTime) {
        _isReduceTime = isReduceTime;
    }

    /// <summary>
    /// 今接待中か否か
    /// </summary>
    /// <param name="isHospitality"></param>
    public void SetIsHospitality(bool isHospitality) {
        this._isHospitality = isHospitality;
    }
    
    /// <summary>
    /// ゲーム開始時に用意しておいたテキストにする
    /// </summary>
    void GameStartCanvasText() {
        _canvasText.text = "ショップモードへようこそ！\r\n" +
            "ここではたくさんのお客さんを対応して結果に応じてスコアゲット！\r\n" +
            "一分間の間に出来るだけ沢山のスコアを手に入れよう！\r\n" +
            "食材の効能や味は画面左下の表をタッチで確認できるよ！\r\n\r\n" +
            "スコア一覧\r\n" +
            "速い     +300\r\n" +
            "まあまあ +200\r\n" +
            "遅い     +100\r\n" +
            "違う     +000";
        
    }

    /// <summary>
    /// ゲーム終了時に用意しておいたテキストにする
    /// </summary>
    void GameEndCanvasText() {
        _canvasText.text = "終了～\r\n\r\nスコア: " + _score + "\r\n\r\n画面タッチでタイトルに戻る";
    }

    
}
