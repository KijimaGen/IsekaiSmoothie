/**
 * @file ShopModeManager.cs
 * @brief �V���b�v���[�h�̏����A�Ǘ�
 * @author Sum1r3
 * @date 2025/7/18
 */
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameConst;

public class ShopModeManager : SystemObject{
    //��������
    private float _limitTime;
    private const float _LIMIT_MAX_TIME = 60;
    //���Ԃ����炷���ǂ���
    private bool _isReduceTime = false;
    //�X�R�A
    private int _score = 0;
    //���̃V���b�v���[�h�X�e�[�g
    public ShopModeState shopModeState ;
    //���g�̃C���X�^���X
    public static ShopModeManager instance;
    //���ڑҒ����ۂ�
    private bool _isHospitality = false;
    //�Q�[�����ɊJ���\��̃L�����o�X
    [SerializeField]
    private GameObject _startEndCanvas;
    //�L�����o�X�̒��̃e�L�X�g
    [SerializeField]
    private TextMeshProUGUI _canvasText;
    //�Q�[�����ɊJ���\��̃L�����o�X
    [SerializeField]
    private GameObject _timerScoreCanvas;
    //�L�����o�X�̃^�C�}�[�̒��̃e�L�X�g
    [SerializeField]
    private TextMeshProUGUI _timerText;
    //�L�����o�X�̒��̃X�R�A�\���e�L�X�g
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    //�Q�[���I����Ԃ��ۂ�
    public bool isGameEnd { get; private set; }


    /// <summary>
    /// ������
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
        //�������Ԃ����炷
        if (_isReduceTime && _limitTime > 0)
            _limitTime -= Time.deltaTime;
        if(_limitTime < 0)
            //�������Ԃ������̂ł��������
            isGameEnd = true;

        //�������Ԃ�0�ł��q����Ή����Ŗ�����΃��U���g�ɑJ��
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
                //�{���͂����ɐF�X�ȏ�����u���ă��C���̂悤�Ɉ����ׂ��ł���(���)
                if (_limitTime > 0)
                    _timerText.text = "TimeLimit\n" + _limitTime.ToString("F2");
                else
                    _timerText.text = "TimeLimit\n0.00";

                _scoreText.text = "Score\n" + _score;

                break;
            case ShopModeState.Result:
                //�Q�[���I�����ɃL�����o�X��\��
                GameEndCanvasText();
                _startEndCanvas.SetActive(true);
                if(Input.GetMouseButtonDown(0)) {
                    //�t�F�[�h�C��
                    await FadeManager.instance.FadeOut();
                    SceneManager.LoadScene(TITLE_SCENE_NAME);
                }

                break;
           
        }
    }


    /// <summary>
    /// �X�R�A���Z
    /// </summary>
    /// <param name="evaluationScore"></param>
    public void AddScore(EvaluationScore evaluationScore) {
        _score += (int)evaluationScore;
    }

    /// <summary>
    /// ���Ԃ����炷�����Z�b�g
    /// </summary>
    /// <param name="isReduceTime"></param>
    public void SetIsReduceTime(bool isReduceTime) {
        _isReduceTime = isReduceTime;
    }

    /// <summary>
    /// ���ڑҒ����ۂ�
    /// </summary>
    /// <param name="isHospitality"></param>
    public void SetIsHospitality(bool isHospitality) {
        this._isHospitality = isHospitality;
    }
    
    /// <summary>
    /// �Q�[���J�n���ɗp�ӂ��Ă������e�L�X�g�ɂ���
    /// </summary>
    void GameStartCanvasText() {
        _canvasText.text = "�V���b�v���[�h�ւ悤�����I\r\n" +
            "�����ł͂�������̂��q�����Ή����Č��ʂɉ����ăX�R�A�Q�b�g�I\r\n" +
            "�ꕪ�Ԃ̊Ԃɏo���邾����R�̃X�R�A����ɓ���悤�I\r\n" +
            "�H�ނ̌��\�□�͉�ʍ����̕\���^�b�`�Ŋm�F�ł����I\r\n\r\n" +
            "�X�R�A�ꗗ\r\n" +
            "����     +300\r\n" +
            "�܂��܂� +200\r\n" +
            "�x��     +100\r\n" +
            "�Ⴄ     +000";
        
    }

    /// <summary>
    /// �Q�[���I�����ɗp�ӂ��Ă������e�L�X�g�ɂ���
    /// </summary>
    void GameEndCanvasText() {
        _canvasText.text = "�I���`\r\n\r\n�X�R�A: " + _score + "\r\n\r\n��ʃ^�b�`�Ń^�C�g���ɖ߂�";
    }

    
}
