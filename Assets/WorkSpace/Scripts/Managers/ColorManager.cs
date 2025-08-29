/*
 * Date 2025�N6��23��
 * programar Sum1r3
 * ColorManager.cs
 * �F�Ǘ��X�N���v�g(��ɃQ�[�~���O�F)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : SystemObject{

    public static Color rainbow;

    public float colorSpeed = 1f;

    public override void Initialize() {
        
    }

    private void Update() {
       
        float t = Mathf.PingPong(Time.time * colorSpeed, 1f);
        rainbow = Color.HSVToRGB(t, 1f, 1f); // HSV�ł��邮��
        
    }
}
