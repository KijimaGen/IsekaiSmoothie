/*
 * Date 2025�N6��18��
 * programar Sum1r3
 * ShakeManager.cs
 * �X�}�z���h��Ă��邩�ǂ��������m���邽�߂̕�
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : SystemObject{
    //�X�}�z�̌��݂̉����x
    private Vector3 Acceleration;
    //�X�}�z��1�t���[���O�̉����x
    private Vector3 preAcceleration;
    //���̓���
    float DotProduct;
    //�U������
    public static int ShakeCount;
    public static ShakeManager instance;
    //�X�}�z�U���Ă��邩�ǂ���
    public bool isShake = false;

    
    public void Update() {
        //���Ⴏ�ӂ��[���̎����������悤��
        if (RoundManager.instance.state == RoundManager.GameState.Shake) {
            ShakeCheck();
            //�f�o�b�O�p�̂��Ⴏ
            if (Input.GetKeyDown(KeyCode.S)) {
                ShakeCount++;
                
                SoundManager.instance.PlaySound(1);
            }
        }
        //1�t���[�������U���Ă��邩�ǂ����𔻒肵����
        if(isShake)
        isShake = false;
    }


    /// <summary>
    /// �X�}�z���h��Ă��邩�ǂ����̃`�F�b�N
    /// </summary>
    void ShakeCheck() {
        //���݂̈ړ��x�N�g����pre�ɑ��
        preAcceleration = Acceleration;
        //���݂̈ړ��t���[���̏�������
        Acceleration = Input.acceleration;
        //��̃x�N�g���̓��ς����߂�
        DotProduct = Vector3.Dot(Acceleration, preAcceleration);
        //���ς�0�ȉ� = �t�����ɓ����Ă���̂ŏ��� 
        if(DotProduct < 0) {
            ShakeCount++;
            SoundManager.instance.PlaySound(1);
            isShake=true;
        }
    }

    /// <summary>
    /// ����������
    /// </summary>
    public override void Initialize() {
        instance = this;
    }

    /// <summary>
    /// �U��Ƃ��̗͂𑗂�
    /// </summary>
    /// <returns></returns>
    public Vector3 GetShakePower() {
        return Acceleration;
    }

    /// <summary>
    /// ���U���Ă��邩�𑗂�
    /// </summary>
    /// <returns></returns>
    public bool IsShake() {
        return isShake;
    }

}
