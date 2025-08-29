/*
 * Date 2025年6月13日
 * programar Sum1r3
 * MargeManager.cs
 * コップにレイが当たっているかとフルーツ持っているかの可否を判定
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargeManager : SystemObject {
    //インスタンス
    public static MargeManager instance;
    [SerializeField]
    private Material _juice;
    Camera cam;

    //↓しばらくの恥
    public static  bool haveFruit;
    public static bool hitRayCup;

   

    public override void Initialize() {
        instance = this;
        cam = Camera.main;
    }

    private void Update() {
        
        if (Cup.instance.GetRayCop()) {
            hitRayCup = true;
            
        }
        else
            hitRayCup = false;

        
        

    }

    /// <summary>
    /// フルーツとコップが重なっているかを返す関数
    /// </summary>
    /// <returns></returns>
    public bool OverlapFruitToCup() {
        return haveFruit && hitRayCup;
    }

    

    
}