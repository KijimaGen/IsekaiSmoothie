/**
 * @file TitleCameraContoroller.cs
 * @brief �^�C�g���̃J�����R���g���[��
 * @author Sum1r3
 * @date 2025/7/4
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static GameConst;

public class TitleCameraContoroller : MonoBehaviour{

    //�ڕW�n�_(�ʓ|�L���̂�Tra)
    [SerializeField] private Transform targetTra;
    private Vector3 targetPos;

    //�^�񒆒n�_
    private Vector3 halfPos;

    //����
    [SerializeField] private GameObject targetItem;

    //�~�^��
    float radius;
    float rotationSpeed = 10f;
    float time = 0f;

    private void Start() {
        targetPos = targetTra.position;
        halfPos = (this.transform.position + targetPos) / 2;
        radius = Vector3.Distance(halfPos, this.transform.position);

        
    }
    private void Update() {
        if (TitleManager.instance.state == TitleState.Select) {
            
            //CalcPos();
            LookRotation(targetTra.position);
        }
       
    }

    private void CalcPos() {
        time += Time.deltaTime;
       
        //�p�x�����Ԃŕω�������
        float angle = -time * rotationSpeed * TOW_PI;

        // x = r * cos(��),z = r * sin(��)
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        //�ʒu���X�V
        transform.position = halfPos + new Vector3(x, 0, z);

        Look(halfPos);


    }

    /// <summary>
    /// �������J��(�킢�̂���)
    /// </summary>
    /// <param name="center"></param>
    private void Look(Vector3 center) {
        //�O��������
        Vector3 dir = (transform.position - center).normalized;
        transform.forward = dir;
    }

    /// <summary>
    /// �����J��(�������)
    /// </summary>
    /// <param name="targetPos"></param>
    private void LookRotation(Vector3 targetPos) {
        //�ڕW�Ǝ����̕����x�N�g�������߂�
        Vector3 direction = (targetPos - this.transform.position).normalized;

        //���g�̉�]��ڕW�x�N�g����speed�̃X�s�[�h�ŉ�]
        // direction �� Vector3�i�����j
        // rotationSpeed �� ���b���x��]���邩
        Quaternion targetRot = Quaternion.LookRotation(direction);

        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
    }
}
