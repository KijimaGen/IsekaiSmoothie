/*
 * Date 2025年6月25日
 * programar Sum1r3
 * Arrow.cs
 * 画面上に表示する矢印UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static RoundManager;

public class Arrow : Button {
    //フルーツの増加値
    [SerializeField]
    private int changeValue;

    //自身が入っているキャンバス
    [SerializeField]
    Canvas canvas;
   
    private void Awake() {
        Initialized();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialized() {
        canvas.enabled = true;
        
    }

    //新しい方法、rectを取得して当たり判定を行うのをやる
    private void Update() {
        //メークフェーズ以外なら表示をしない
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
    /// 自身がクリックされたときの処理
    /// </summary>
    /// <param name="eventData"></param>
    public override void OnPointerClick(PointerEventData eventData) {
        FoodManager.instance.IncreaceIndex(changeValue);
    }
   
}
