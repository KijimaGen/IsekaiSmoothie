/**
 * @file ResetButton.cs
 * @brief ���Z�b�g�{�^���̏���
 * @author Sum1r3
 * @date 2025/7/11
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static RoundManager;

public class ResetButton : Button{
    [SerializeField]
    Canvas canvas;

    void Update() {
        if(RoundManager.instance.state == GameState.Make) {
            canvas.enabled = true;
        }
        else {
            canvas.enabled = false;
        }
        

        //�}�E�X��������Ă���Ƃ��ɏk��
        if (getButton) {
            this.gameObject.transform.localScale = buttonDown;
        }
        else {
            this.gameObject.transform.localScale = Vector3.one;
        }
    }
    /// <summary>
    /// �N���b�N�����Ƃ��Ƀ��Z�b�g
    /// </summary>
    /// <param name="eventData"></param>
    public override void OnPointerClick(PointerEventData eventData) {
        Cup.instance.Resetting();
    }
}
