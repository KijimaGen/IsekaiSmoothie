/*
 * Date 2025�N6��20��
 * programar Sum1r3
 * Customer.cs
 * ���q����̏���
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

    //�������Ԑݒ�
    float timer = -1;

    private const float _TIME_GOOD = 15;
    private const float _TIME_NOTBAD = 0;

    //�}�C�]��
    private EvaluationScore myEvauation;

    //public static Customer instance;

    //�v��
    private Taste hopeTaste;
    private Effect hopeEffect;

    //�e�L�X�g�{�b�N�X�̎擾
    TextMeshProUGUI customerText;

    //��~���W�A���傤�߂�����W��錾
    Vector3 customerPos;
    Vector3 customerEndPos;

    //�K�v�ȃe�L�X�g
    string customerName;
    string tasteText;
    string effectText;
    string smoothieText;

    //�ړ��X�s�[�h
    int speed = -1;

    //��ʊO����
    private new Camera camera;
   
    //��]�̋���
    Vector3 lookRot = new Vector3(0, 90, 0);

    //���g�̃G�N�Z���̒��ł�ID
    int ID = -1;

    //���ڑҒ����ۂ�
    public bool isHospitality = false;

    //���g�̃A�j���[�V�����R���|�[�l���g
    Animator animator;
    //�A�j���[�^�[�̃A�j���[�V�����̔ԍ�
    private static readonly int ANIM_WALK_ID = Animator.StringToHash("Walk");
    private static readonly int ANIM_IDLE_ID = Animator.StringToHash("Idle");

    private void Start() {
        Initialize();
        
    }


    public void Initialize() {
        ID = Random.Range(0, MasterDataManager.customerData[0].Count);
        //�}�X�^�[�[�f�[�^�𗘗p�����Z�b�g�A�b�v
        SetupMaster();

        //�����Ŋ�]�̏��i���쐬(���̊���ȕ��͕̂ςȃX�e�[�g���E��Ȃ����߂̃��m��)
        do {
            hopeEffect = GetRandomEnumValue<Effect>();
        } while (hopeEffect == Effect.Max);

        
        do {
            hopeTaste = GetRandomEnumValue<Taste>();
        } while (hopeTaste == Taste.None || hopeTaste == Taste.Max || hopeTaste == Taste.Chaos);

        //������Ăяo�����߂̕�
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

        //�����œ���̃Q�[���X�e�[�g�̎��̋���
        
        
        switch (RoundManager.instance.state) {
            case GameState.Come:
                MoveToTarget(customerPos);
                if (Vector3.Distance(customerPos,this.transform.position) < DISTANCE_MIN)
                    RoundManager.instance.state = GameState.Make;

                //�����Ŕ�\��
                if (CustomerManager.instance.GetCanvasEnable())
                    CustomerManager.instance.SetCanvasEnable(false);
                //�A�j���[�V�����ݒ�
                animator.SetTrigger(ANIM_WALK_ID);
                break;
            case GameState.Make:
                if (!CustomerManager.instance.GetCanvasEnable())
                    CustomerManager.instance.SetCanvasEnable(true);

                //�����쐬
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
                //�L�����o�X���\���ɂ��Ă������
                if (CustomerManager.instance.GetCanvasEnable())
                    CustomerManager.instance.SetCanvasEnable(false);

                MoveToTarget(customerEndPos);
                //�S�[���ɒ������������Đ������ď�����
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

            //���Ԃŕ�����]��
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
    /// �ړ�����
    /// </summary>
    /// <param name="targetPos"></param>
    private void MoveToTarget(Vector3 targetPos) {
        // �^�[�Q�b�g�������v�Z
        Vector3 direction = (targetPos - transform.position).normalized;

        // �ړ�
        transform.position += direction * speed * Time.deltaTime; 
        //�ړ��������
        transform.LookAt(targetPos);
    }

    /// <summary>
    /// �}�X�^�[�f�[�^���g�p�����Z�b�g�A�b�v
    /// </summary>
    private void SetupMaster() {
        var customerMaster = GetCustomerMaster(ID);

        //�������Ԃ̐ݒ�(���q����ɐ��i��ݒ肵�Ă��ꂼ��Őݒ�)
        timer = customerMaster.time;
        //�f�o�b�O
        customerName = customerMaster.characterName;

        smoothieText = customerMaster.smoothie;
        speed = customerMaster.speed;

    }
}