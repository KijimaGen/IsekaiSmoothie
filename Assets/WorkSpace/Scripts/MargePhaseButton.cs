/**
 * @file MargePhaseButton.cs
 * @brief 次のフェーズに遷移するためのボタン
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
        //入っていたらgetButtonをつけて押している間にマウスが離れたらfalse
        //マウスをクリックしたときに自身に入っているかを確認
        

        //離したタイミングでgetButtonがついていたら次のフェーズ
        
        //マウスが押されているときに縮む
        if (getButton) {
            this.gameObject.transform.localScale = buttonDown;
        }
        else {
            this.gameObject.transform.localScale = Vector3.one;
        }

        //テキストの文字変えとか
        switch (RoundManager.instance.state) {
            case GameState.Make:
                if (Cup.havingItem <= 0) canvas.enabled = false;
                else canvas.enabled = true;

                buttonText.text = "ふる！";
                break;
            case GameState.Shake:
                if (ShakeManager.ShakeCount <= 0) {
                    buttonText.text = "ふろう！";

                }
                else {
                    buttonText.text = "わたす！";
                }
                break;
            case GameState.Drink:
                if(!Cup.instance.isHaveCop)canvas.enabled = false;
                else canvas.enabled = true;
                buttonText.text = "つぎのきゃく";
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
    /// 押して離したときの処理
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
                //ここで色々リセット
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
