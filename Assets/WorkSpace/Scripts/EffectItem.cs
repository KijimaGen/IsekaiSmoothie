/*
 * Date 2025�N6��25��
 * programar Sum1r3
 * EffectItem.cs
 * �G�t�F�N�g���ʂ̂���t���[�c
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConst;

public class EffectItem : Foods{
    [SerializeField]
    private Effect myEffect;
    [SerializeField]
    private Taste myTaste;

    public override void Initialize() {
       
    }

    public override void MargeSmoothie() {
        Cup.instance.ChangeEffect(myEffect);
        Cup.instance.AddTaste(myTaste);
    }

}
