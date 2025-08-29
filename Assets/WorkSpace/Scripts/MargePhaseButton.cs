/**
 * @file MargePhaseButton.cs
 * @brief ���̃t�F�[�Y�ɑJ�ڂ��邽�߂̃{�^��
 * @author Sum1r3
 * @date 2025/6/18
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static RoundManager;
using static GameConst;
using UnityEngine.EventSystems;

public class MargePhaseButton : Button{
    [SerializeField]
    TextMeshProUGUI buttonText;
    [SerializeField]
    Canvas canvas;
    

    void Update() {
        //�����Ă�����getButton�����ĉ����Ă���ԂɃ}�E�X�����ꂽ��false
        //�}�E�X���N���b�N�����Ƃ��Ɏ��g�ɓ����Ă��邩���m�F
        

        //�������^�C�~���O��getButton�����Ă����玟�̃t�F�[�Y
        
        //�}�E�X��������Ă���Ƃ��ɏk��
        if (getButton) {
            this.gameObject.transform.localScale = buttonDown;
        }
        else {
            this.gameObject.transform.localScale = Vector3.one;
        }

        //�e�L�X�g�̕����ς��Ƃ�
        switch (RoundManager.instance.state) {
            case GameState.Make:
                if (Cup.havingItem <= 0) canvas.enabled = false;
                else canvas.enabled = true;

                buttonText.text = "�ӂ�I";
                break;
            case GameState.Shake:
                if (ShakeManager.ShakeCount <= 0) {
                    buttonText.text = "�ӂ낤�I";

                }
                else {
                    buttonText.text = "�킽���I";
                }
                break;
            case GameState.Drink:
                if(!Cup.instance.isHaveCop)canvas.enabled = false;
                else canvas.enabled = true;
                buttonText.text = "���̂��Ⴍ";
                break;
            case GameState.Result:
                break;
            
            case GameState.Come:
                if(canvas.enabled)
                canvas.enabled = false;
                break;
            case GameState.Go:
                if (canvas.enabled)
                    canvas.enabled = false;
                break;
        }

        if (ShopModeManager.instance.shopModeState == ShopModeState.Start)
            canvas.enabled = false;


    }

    /// <summary>
    /// �����ė������Ƃ��̏���
    /// </summary>
    /// <param name="eventData"></param>
    public override void OnPointerClick(PointerEventData eventData) {
        switch (RoundManager.instance.state) {
            case GameState.Make:
                if (Cup.havingItem > 0)
                    RoundManager.instance.state = GameState.Shake;
                break;
            case GameState.Shake:
                if (ShakeManager.ShakeCount > 0) {
                    RoundManager.instance.state = GameState.Drink;
                    SoundManager.instance.PlaySound(0);
                }

                break;
            case GameState.Drink:
                //�����ŐF�X���Z�b�g
                Cup.instance.Resetting();
                ShakeManager.ShakeCount = 0;
                RoundManager.instance.state = GameState.Go;
                break;
            case GameState.Result:
                break;

            case GameState.Come:
                break;
            case GameState.Go:
                break;
        }
    }




}
