/*
 * Date 2025�N6��20��
 * programar Sum1r3
 * FoodManager.cs
 * �H�ފǗ��X�N���v�g
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour{
    //�M�̏�ɒu�����t���[�c�̃��X�g
    [SerializeField]
    List<GameObject> fashonFruitList;
    //�o�Ă���t���[�c�̃��X�g
    [SerializeField]
    List<GameObject> margeFruitList;

    //���M
    [SerializeField]
    private GameObject syokuzaiLeft;
    [SerializeField]
    private GameObject syokuzaiCenter;
    [SerializeField]
    private GameObject syokuzaiRight;

    private int leftIndex;
    private int centerIndex;
    private int rightIndex;

    public static FoodManager instance;

    private void Start() {
        leftIndex = 0;
        centerIndex = 1;
        rightIndex = 2;
        instance = this;
        SetFruit();
        
    }

    private void Update() {
        //���͂̎�t
        if (Input.GetKeyDown(KeyCode.RightArrow))
            IncreaceIndex(1);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            IncreaceIndex(-1);

    }



    private void SetFruit() {
        syokuzaiLeft.GetComponent<Syokuzai>().ChangePutFruit(fashonFruitList[leftIndex], margeFruitList[leftIndex]);
        syokuzaiCenter.GetComponent<Syokuzai>().ChangePutFruit(fashonFruitList[centerIndex], margeFruitList[centerIndex]);
        syokuzaiRight.GetComponent<Syokuzai>().ChangePutFruit(fashonFruitList[rightIndex], margeFruitList[rightIndex]);
    }

    public void IncreaceIndex(int count) {
        //���[�̃C���f�b�N�X�����Z
        leftIndex += count;
        //���Z������̒l��fashonFruitList�̃J�E���g�𒴂���悤�Ȃ�0�ɐݒ�
        if(leftIndex > fashonFruitList.Count - 1)
            leftIndex = 0;
        if(leftIndex < 0)
            leftIndex = fashonFruitList.Count - 1;
        //�^�񒆂ƉE�[��ݒ�
        centerIndex = leftIndex + 1;
        if(centerIndex >  fashonFruitList.Count -1) 
            centerIndex = 0;
        //�^��
        rightIndex = leftIndex + 2;
        if(rightIndex > fashonFruitList.Count - 1) 
            rightIndex = rightIndex -fashonFruitList.Count;
        //�S�ďI������̂Œu���A�C�e����ݒ�
        SetFruit();

    }
}
