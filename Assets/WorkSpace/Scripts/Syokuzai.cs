/*
 * Date 2025�N6��13��
 * programar Sum1r3
 * Syokuzai.cs
 * �H�ނ�������Ă��邨�M�̃N���X
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using static RayUtility;

public class Syokuzai : MonoBehaviour{
    
    //�Ăяo���t���[�c
    private GameObject _instatiateObject = null;
    //�����p�̃t���[�c
    private GameObject _putObject = null;
    
    [SerializeField]Transform foodPos;
    Vector3 SpawnPos;
    
    void Start() {
        SpawnPos = foodPos.position;
        
    }

   
    void Update(){
        //���g�ɓ������Ă��邩
        if (Input.GetMouseButtonDown(0)) {
            if (CheckShootRay(gameObject)) {
                // �}�E�X���N���b�N�ő���J�n
                Instantiate(_instatiateObject, this.transform.position, Quaternion.identity);
                MargeManager.haveFruit = true;
            }
        }
            
    } 


    /// <summary>
    /// ���g�ɏ�����Ă���t���[�c�̕ύX
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
