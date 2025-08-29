/*
 * Date 2025�N6��9��
 * programar Sum1r3
 * Foods.cs
 * �H�ׂ��̂̊��N���X
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Foods : MonoBehaviour{
    private Camera cam;
    private float zDistance;

    private GameObject selectedObject;
    private Vector3 offset;

    //�͂�ł��邩�ǂ���
    private bool catchThis = true;

    //�����X�s�[�h
    private const float fallSpeed = 0.1f;

    //���݂��Ă�������
    private const int bottom = -1;

    void Start() {
        cam = Camera.main;

        selectedObject = this.gameObject;
        zDistance = cam.WorldToScreenPoint(selectedObject.transform.position).z;

        // �I�t�Z�b�g���v�Z�i����h�~�j
        Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
        offset = selectedObject.transform.position - mouseWorld;
        Initialize();


    }

    private void Update() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //�R�b�v�ɓ������Ă������ɂ��̃A�C�e�����P�X
        if (Input.GetMouseButtonUp(0)) {
            if (MargeManager.instance.OverlapFruitToCup()) {
                MargeManager.haveFruit = false;
                MargeSmoothie();
                SoundManager.instance.PlaySound(0);
                Destroy(gameObject);
            }
            //�ǂ݂̂������Ă���̂�false
            catchThis = false;
        }

        //���C�L���X�g������ē������Ă���ړ��\
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == this.gameObject) 
                catchThis = true;
            else
                catchThis = false;

            Vector3 mouseWorld = cam.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
            offset = selectedObject.transform.position - mouseWorld;
        }

        if (transform.position.y < bottom) {
            //�f�o�b�O�폜
            Destroy(gameObject);
        }

        //�h���b�O�ړ�
        if (Input.GetMouseButton(0) && catchThis) {
            Vector3 mouseWorld = cam.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
            selectedObject.transform.position = mouseWorld + offset;
            MargeManager.haveFruit = true;
        }

        if(!catchThis) {
            //(�N���b�N����Ă��Ȃ��Ƃ�)���~
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed,
                transform.position.z);
        }
    }

    public abstract void MargeSmoothie();

    public abstract void Initialize();

    
}