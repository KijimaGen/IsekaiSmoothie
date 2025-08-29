/*
 * Date 2025�N6��25��
 * programar Sum1r3
 * Arrow.cs
 * ��ʏ�ɕ\��������UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static RoundManager;

public class Arrow : Button {
    //�t���[�c�̑����l
    [SerializeField]
    private int changeValue;

    //���g�������Ă���L�����o�X
    [SerializeField]
    Canvas canvas;
   
    private void Awake() {
        Initialized();
    }

    /// <summary>
    /// ����������
    /// </summary>
    private void Initialized() {
        canvas.enabled = true;
        
    }

    //�V�������@�Arect���擾���ē����蔻����s���̂����
    private void Update() {
        //���[�N�t�F�[�Y�ȊO�Ȃ�\�������Ȃ�
        if (RoundManager.instance.state != GameState.Make) {
            canvas.enabled = false;
            return;
        }
        else {
            if (!canvas.enabled) {
                canvas.enabled = true;
            }
        }

        
    }

    /// <summary>
    /// ���g���N���b�N���ꂽ�Ƃ��̏���
    /// </summary>
    /// <param name="eventData"></param>
    public override void OnPointerClick(PointerEventData eventData) {
        FoodManager.instance.IncreaceIndex(changeValue);
    }
   
}
