/*
 * Date 2025�N6��13��
 * programar Sum1r3
 * MargeManager.cs
 * �R�b�v�Ƀ��C���������Ă��邩�ƃt���[�c�����Ă��邩�̉ۂ𔻒�
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargeManager : SystemObject {
    //�C���X�^���X
    public static MargeManager instance;
    [SerializeField]
    private Material _juice;
    Camera cam;

    //�����΂炭�̒p
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
    /// �t���[�c�ƃR�b�v���d�Ȃ��Ă��邩��Ԃ��֐�
    /// </summary>
    /// <returns></returns>
    public bool OverlapFruitToCup() {
        return haveFruit && hitRayCup;
    }

    

    
}