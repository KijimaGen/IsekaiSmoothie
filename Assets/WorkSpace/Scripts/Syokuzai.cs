/*
 * Date 2025年6月13日
 * programar Sum1r3
 * Syokuzai.cs
 * 食材を乗っけてあるお皿のクラス
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using static RayUtility;

public class Syokuzai : MonoBehaviour{
    
    //呼び出すフルーツ
    private GameObject _instatiateObject = null;
    //装飾用のフルーツ
    private GameObject _putObject = null;
    
    [SerializeField]Transform foodPos;
    Vector3 SpawnPos;
    
    void Start() {
        SpawnPos = foodPos.position;
        
    }

   
    void Update(){
        //自身に当たっているか
        if (Input.GetMouseButtonDown(0)) {
            if (CheckShootRay(gameObject)) {
                // マウス左クリックで操作開始
                Instantiate(_instatiateObject, this.transform.position, Quaternion.identity);
                MargeManager.haveFruit = true;
            }
        }
            
    } 


    /// <summary>
    /// 自身に乗っけてあるフルーツの変更
    /// </summary>
    /// <param name="putFruit"></param>
    /// <param name="instantObject"></param>
    public void ChangePutFruit(GameObject putFruit,GameObject instantObject) {
        if (foodPos.GetChild(0).gameObject != null) {
            Destroy(foodPos.GetChild(0).gameObject);
        }
        _instatiateObject = instantObject;
        _putObject = putFruit;

        Instantiate(putFruit, foodPos.transform.position,transform.rotation,foodPos);
    }

    
}
