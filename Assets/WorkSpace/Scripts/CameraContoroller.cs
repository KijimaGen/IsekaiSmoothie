/*
 * Date 2025�N6��18��
 * programar Sum1r3
 * CameraContoroller.cs
 * �J�������A�j���[�V�������邽�߂̏���
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraContoroller : MonoBehaviour{

    //��������Ƃ��̋���
    private float distance = -1;
    //�����Ώ�
    [SerializeField]
    private GameObject target;
    float speed = 1f;
    //�{���̍��W
    Vector3 originPos;
    Quaternion originRotate;

    private void Start() {
        distance = 0.5f;
        originPos = transform.position;
        originRotate =transform.rotation;
    }

    private void Update() {
        if(RoundManager.instance.state == RoundManager.GameState.Shake) {
            //���������ȏゾ������
            if(Vector3.Distance(this.transform.position, target.transform.position)> distance) {
                //��������Ώۂɋ߂Â�
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            transform.LookAt(target.transform.position);

        }
        else {
            transform.position = originPos;
            transform.rotation = originRotate;
        }
        
    }

    /// <summary>
    /// �ʒu�̏���������
    /// </summary>
    private void Reset() {
        transform.position = originPos;
        transform.rotation = originRotate;
    }
}
