/**
 * @file Button.cs
 * @brief ��ɓ����蔻����s���A�{�^���̊��N���X
 * @author Sum1r3
 * @date 2025/7/11
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour,IPointerDownHandler,IPointerUpHandler, IPointerClickHandler {
    
    protected bool getButton = false;
    
    //�{�^����������Ă���Ƃ��̃T�C�Y
    protected Vector3 buttonDown = new Vector3(0.9f, 0.9f, 0.9f);


    /// <summary>
    /// UI��p�̓��͌��m(��������)
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData) {
        getButton = true;
    }

    /// <summary>
    /// ������͘b�����Ƃ��Ɍ��m
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData) {
        getButton = false;
    }

    /// <summary>
    /// �����Ęb�����Ƃ��Ɍ��m
    /// </summary>
    /// <param name="eventData"></param>
    public virtual void OnPointerClick(PointerEventData eventData) {

    }

}
