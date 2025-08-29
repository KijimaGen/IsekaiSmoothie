/*
 * Date 2025�N6��23��
 * programar Sum1r3
 * ColorManager.cs
 * �W���[�X�𕡐��Ƃ������Ƃ������邽�߂̃��m�A�o�C�o�C�������ő��₷
 */
using UnityEngine;
using static ShakeUtility;

public class Juice : MonoBehaviour{
    Rigidbody rb;
    private float powor = 10;

    //��яo���Ȃ����߂̃��m
    private const float maxSpeed = 1;
    private float distance = -1;
    private const float maxDistanace = 0.3f;
    private GameObject Cup;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        Cup = GameObject.Find("�R�b�v");
    }
    private void Update() {
        //�X�s�[�h�̍ő�l��ݒ�
        if(rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
        //�͂ݏo�������Ȃ����߂ɂ͂ݏo���x��ݒ�
        distance = Vector3.Distance(this.gameObject.transform.position, Cup.transform.position);
        //�݂͂����x���͂ݏo���ō��l�𒴂������ɂȂ�����^�񒆂ɖ߂����
        if (distance > maxDistanace) {
            rb.velocity = Vector3.zero;
            this.transform.position = Cup.transform.position;
        }
        if(IsShake())
        //�V�F�C�N�}�l�[�W���[����X�}�z�̐U�����͂�������Ď��g���΂�
        rb.AddForce(GetShakePower() / powor, ForceMode.Impulse);
    }

}
