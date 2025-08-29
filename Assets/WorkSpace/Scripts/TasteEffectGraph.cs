/**
 * @file MargePhaseButton.cs
 * @brief ���\���g�傷�邽�߂̃��m
 * @author Sum1r3
 * @date 2025/6/18
 */
using UnityEngine;
using UnityEngine.EventSystems;


using static RoundManager;
using static UnityEngine.Input;


public class TasteEffectGraph : Button {
    [SerializeField]
    Canvas canvas;

    Vector2 originPos = Vector2.zero;
    Vector2 originScale = Vector2.zero;

    Vector2 STOP_POS = new Vector2(0, 0);
    

    bool checkGraph = false;

    //���g�̃T�C�Y�ҏW�p
    [SerializeField] 
    RectTransform targetUI;
    [SerializeField]
    GameObject BG;

    //�m�F���̃{�^���T�C�Y
    const float _IS_STOP_SIZE = 1080;

    /// <summary>
    /// ���g���N���b�N���ꂽ�Ƃ��̏���
    /// </summary>
    /// <param name="eventData"></param>
    public override void OnPointerClick(PointerEventData eventData) {
        GameManager.instance.SetGameStop(true);

        checkGraph = true;
    }

    private void Start() {
        originPos = targetUI.anchoredPosition;
        originScale = targetUI.sizeDelta;
    }

    void Update() {
        //�����Ă�����getButton�����ĉ����Ă���ԂɃ}�E�X�����ꂽ��false
        //�}�E�X���N���b�N�����Ƃ��Ɏ��g�ɓ����Ă��邩���m�F
        if(GetMouseButtonDown(0) ) {
            if (!checkGraph) return;
            GameManager.instance.SetGameStop(false);
            checkGraph = false;
        }

        if (checkGraph) {
            GameManager.instance.SetGameStop(true);
            targetUI.anchoredPosition = STOP_POS;
            targetUI.sizeDelta = new Vector2(_IS_STOP_SIZE,_IS_STOP_SIZE);

            BG.SetActive(true);
        }
        else {
            GameManager.instance.SetGameStop(false);
            targetUI.anchoredPosition = originPos;
            targetUI.sizeDelta = originScale;
            BG.SetActive(false);
        }

        if (RoundManager.instance.state == GameState.Make) {
            canvas.enabled = true;
        }
        else {
            canvas.enabled = false;
        }

        if (!checkGraph) {
            //�}�E�X��������Ă���Ƃ��ɏk��
            if (getButton) {
                this.gameObject.transform.localScale = buttonDown;
            }
            else {
                this.gameObject.transform.localScale = Vector3.one;
            }
        }

    }
}
