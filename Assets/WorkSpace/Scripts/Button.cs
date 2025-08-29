/**
 * @file Button.cs
 * @brief 主に当たり判定を行う、ボタンの基底クラス
 * @author Sum1r3
 * @date 2025/7/11
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour,IPointerDownHandler,IPointerUpHandler, IPointerClickHandler {
    
    protected bool getButton = false;
    
    //ボタンが押されているときのサイズ
    protected Vector3 buttonDown = new Vector3(0.9f, 0.9f, 0.9f);


    /// <summary>
    /// UI専用の入力検知(押し込み)
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData) {
        getButton = true;
    }

    /// <summary>
    /// こちらは話したときに検知
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData) {
        getButton = false;
    }

    /// <summary>
    /// 押して話したときに検知
    /// </summary>
    /// <param name="eventData"></param>
    public virtual void OnPointerClick(PointerEventData eventData) {

    }

}
