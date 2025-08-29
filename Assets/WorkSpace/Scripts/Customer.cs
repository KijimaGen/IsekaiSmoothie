/*
 * Date 2025年6月20日
 * programar Sum1r3
 * Customer.cs
 * お客さんの処理
 */
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using TMPro;
using UnityEngine.Animations;

using static RoundManager;
using static GameConst;
using static CommonModule;
using static CustomerMasterUtility;


public class Customer : MonoBehaviour{
    [SerializeField]
    Transform child;

    //制限時間設定
    float timer = -1;

    private const float _TIME_GOOD = 15;
    private const float _TIME_NOTBAD = 0;

    //マイ評価
    private EvaluationScore myEvauation;

    //public static Customer instance;

    //要求
    private Taste hopeTaste;
    private Effect hopeEffect;

    //テキストボックスの取得
    TextMeshProUGUI customerText;

    //停止座標、しょうめちゅ座標を宣言
    Vector3 customerPos;
    Vector3 customerEndPos;

    //必要なテキスト
    string customerName;
    string tasteText;
    string effectText;
    string smoothieText;

    //移動スピード
    int speed = -1;

    //画面外判定
    private new Camera camera;
   
    //回転の矯正
    Vector3 lookRot = new Vector3(0, 90, 0);

    //自身のエクセルの中でのID
    int ID = -1;

    //今接待中か否か
    public bool isHospitality = false;

    //自身のアニメーションコンポーネント
    Animator animator;
    //アニメーターのアニメーションの番号
    private static readonly int ANIM_WALK_ID = Animator.StringToHash("Walk");
    private static readonly int ANIM_IDLE_ID = Animator.StringToHash("Idle");

    private void Start() {
        Initialize();
        
    }


    public void Initialize() {
        ID = Random.Range(0, MasterDataManager.customerData[0].Count);
        //マスターーデータを利用したセットアップ
        SetupMaster();

        //ここで希望の商品を作成(この奇怪な文体は変なステートを拾わないためのモノ也)
        do {
            hopeEffect = GetRandomEnumValue<Effect>();
        } while (hopeEffect == Effect.Max);

        
        do {
            hopeTaste = GetRandomEnumValue<Taste>();
        } while (hopeTaste == Taste.None || hopeTaste == Taste.Max || hopeTaste == Taste.Chaos);

        //何回も呼び出すための物
        customerText = CustomerManager.instance.GetCustmerText();
        customerPos = CustomerManager.instance.GetCustmerPos();
        customerEndPos = CustomerManager.instance.GetCustomereEndPos();
        camera = Camera.main;

        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (timer > _TIME_BOTTOM && RoundManager.instance.state == GameState.Make || RoundManager.instance.state == GameState.Shake) {
            timer -= Time.deltaTime;
        }

        //ここで特定のゲームステートの時の挙動
        
        
        switch (RoundManager.instance.state) {
            case GameState.Come:
                MoveToTarget(customerPos);
                if (Vector3.Distance(customerPos,this.transform.position) < DISTANCE_MIN)
                    RoundManager.instance.state = GameState.Make;

                //ここで非表示
                if (CustomerManager.instance.GetCanvasEnable())
                    CustomerManager.instance.SetCanvasEnable(false);
                //アニメーション設定
                animator.SetTrigger(ANIM_WALK_ID);
                break;
            case GameState.Make:
                if (!CustomerManager.instance.GetCanvasEnable())
                    CustomerManager.instance.SetCanvasEnable(true);

                //注文作成
                tasteText = ChangeTextFromTaste(hopeTaste);
                effectText = ChangeTextFromEffect(hopeEffect);
                this.transform.LookAt(camera.transform.position);
                customerText.text = customerName + "\n" + tasteText + effectText + smoothieText;

                animator.SetTrigger(ANIM_IDLE_ID);

                break;
            case GameState.Shake:
                customerText.text = "";
                this.transform.LookAt(camera.transform.position);
                if (CustomerManager.instance.GetCanvasEnable())
                    CustomerManager.instance.SetCanvasEnable(false);
                break;
            case GameState.Drink:
                this.transform.LookAt(camera.transform.position);
                if (!CustomerManager.instance.GetCanvasEnable())
                    CustomerManager.instance.SetCanvasEnable(true);
                break;
            case GameState.Result:

                break;
            case GameState.Go:
                //キャンバスを非表示にしておくよん
                if (CustomerManager.instance.GetCanvasEnable())
                    CustomerManager.instance.SetCanvasEnable(false);

                MoveToTarget(customerEndPos);
                //ゴールに着いたらもう一個再生成して消える
                if (Vector3.Distance(customerEndPos, this.transform.position) < DISTANCE_MIN) {

                    if (!ShopModeManager.instance.isGameEnd)
                    CustomerManager.instance.InstantiateCustmer();
                    
                    RoundManager.instance.ChangeState(GameState.Come);
                    Destroy(this.gameObject);
                }

                animator.SetTrigger(ANIM_WALK_ID);
                break;
           
        }

        transform.Rotate(lookRot + new Vector3(transform.rotation.x,transform.rotation.y,transform.rotation.z));

    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Cup") {
            other.gameObject.transform.position = child.position;
            other.GetComponent<Cup>().ChangeisHaveCop(true);

            var customerMaster = GetCustomerMaster(ID);

            if (hopeEffect != other.GetComponent<Cup>().GetEffect()) {
                customerText.text = customerMaster.wrongEffect;
                return;
            }

            if(hopeTaste != other.GetComponent<Cup>().GetTaste()) {
                customerText.text = customerMaster.wrongTaste;
                return;
            }

            //時間で分ける評価
            if (timer > _TIME_GOOD) {
                customerText.text = customerMaster.fast;
                myEvauation = EvaluationScore.VeryGood;
            }
            else if(timer > _TIME_NOTBAD) {
                customerText.text = customerMaster.soso;
                myEvauation = EvaluationScore.Good;
            }
            else {
                customerText.text = customerMaster.late;
                myEvauation = EvaluationScore.Soso;
            }

            ShopModeUtility.AddScore(myEvauation);
        }
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    /// <param name="targetPos"></param>
    private void MoveToTarget(Vector3 targetPos) {
        // ターゲット方向を計算
        Vector3 direction = (targetPos - transform.position).normalized;

        // 移動
        transform.position += direction * speed * Time.deltaTime; 
        //移動先を見る
        transform.LookAt(targetPos);
    }

    /// <summary>
    /// マスターデータを使用したセットアップ
    /// </summary>
    private void SetupMaster() {
        var customerMaster = GetCustomerMaster(ID);

        //制限時間の設定(お客さんに性格を設定してそれぞれで設定)
        timer = customerMaster.time;
        //デバッグ
        customerName = customerMaster.characterName;

        smoothieText = customerMaster.smoothie;
        speed = customerMaster.speed;

    }
}