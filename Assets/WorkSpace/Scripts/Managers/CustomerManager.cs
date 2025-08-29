/*
 * Date 2025年6月30日
 * programar Sum1r3
 * CustomerManager.cs
 * お客さん呼び出し処理
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerManager : SystemObject{
    //お客さん呼び出しに必要なもの
    [SerializeField]
    private List<GameObject> customerList;

    //お客さんに引き渡したい情報
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
    /// リストの中からランダムにお客さんを生成
    /// </summary>
    public void InstantiateCustmer() {
        //ゲームが終わっていたら呼ばないよ
        


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
    /// キャンバスの表示非表示
    /// </summary>
    /// <param name="enable"></param>
    public void SetCanvasEnable(bool enable) {
        canvas.gameObject.SetActive(enable);
    }

    /// <summary>
    /// キャンバスの表示非表示取得
    /// </summary>
    /// <returns></returns>
    public bool GetCanvasEnable() {
        return canvas.gameObject.activeSelf;
    }

}
