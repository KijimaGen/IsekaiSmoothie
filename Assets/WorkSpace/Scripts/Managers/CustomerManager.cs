/*
 * Date 2025�N6��30��
 * programar Sum1r3
 * CustomerManager.cs
 * ���q����Ăяo������
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerManager : SystemObject{
    //���q����Ăяo���ɕK�v�Ȃ���
    [SerializeField]
    private List<GameObject> customerList;

    //���q����Ɉ����n���������
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    TextMeshProUGUI customerText;
    
    Vector3 CustmerPos = new Vector3( 0,1.0f,-7.3f);
    Vector3 CustomerSpawnPos = new Vector3( 6.58f,1.0f,-7.3f);
    Vector3 CustomerEndPos = new Vector3(-4f, 1.0f,-7.3f);
   
    
    public static CustomerManager instance;

   
    public override void Initialize() {
        instance = this;
        canvas.gameObject.SetActive(false);
        InstantiateCustmer();
    }

    /// <summary>
    /// ���X�g�̒����烉���_���ɂ��q����𐶐�
    /// </summary>
    public void InstantiateCustmer() {
        //�Q�[�����I����Ă�����Ă΂Ȃ���
        


        int custmerIndex = Random.Range(0,customerList.Count);
        Instantiate(customerList[custmerIndex], CustomerSpawnPos,Quaternion.identity);
    }

    public Canvas GetCustomerCanvas() {
        return canvas;
    }

    public TextMeshProUGUI GetCustmerText() {
        return customerText;
    }

    public Vector3 GetCustmerPos() {
        return CustmerPos;
    }

    public Vector3 GetCustomereEndPos() {
        return CustomerEndPos;
    }


    /// <summary>
    /// �L�����o�X�̕\����\��
    /// </summary>
    /// <param name="enable"></param>
    public void SetCanvasEnable(bool enable) {
        canvas.gameObject.SetActive(enable);
    }

    /// <summary>
    /// �L�����o�X�̕\����\���擾
    /// </summary>
    /// <returns></returns>
    public bool GetCanvasEnable() {
        return canvas.gameObject.activeSelf;
    }

}
