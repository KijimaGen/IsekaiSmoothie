/**
 * @file ScreenSetter.cs
 * @brief 画面のサイズを固定するためのもの(こいつで地獄を見るかもしれない)
 * @author Sum1r3
 * @date 2025/7/25
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenSetter {
    /// <summary>
    /// 初期化時にカメラの見える範囲を調整して16:9を維持
    /// </summary>
    public static void Initialize() {
        //設定したいアスペクト比
        float targetAspect = 9f / 16f;  

        Camera cam = Camera.main;
        //現在の比率を確認
        float windowAspect = (float)Screen.width / Screen.height;   
        float scaleHeight = windowAspect / targetAspect;

        //端末が縦長なので上下にレターボックス
        if (scaleHeight < 1.0f) {
            Rect rect = cam.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            cam.rect = rect;
        }
        //端末が横長なので左右にピラーボックス
        else {
            float scaleWidth = 1.0f / scaleHeight;
            
            Rect rect = cam.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;

            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            cam.rect = rect;
        }
    }
}
