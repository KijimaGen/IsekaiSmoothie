/**
 * @file TasteFood.cs
 * @brief 味しかないフルーツのクラス
 * @author Sum1r3
 * @date 2025/7/18
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConst;

public class TasteFood : Foods{
    [SerializeField]
    private Taste ownTaste;
    public override void Initialize() {
        
    }

    public override void MargeSmoothie() {
        Cup.instance.AddTaste(ownTaste);
    }

}
