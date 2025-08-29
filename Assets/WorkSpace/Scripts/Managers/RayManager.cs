/**
 * @file RayManager.cs
 * @brief ���C�L���X�g����
 * @author Sum1r3
 * @date 2025/7/18
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayManager : SystemObject{

    public static RayManager instance;
    
    //���C�L���X�g�֘A
    public List<GameObject> rayHitters;
    //�N���b�N�����Ƃ�����̃��C�q�b�g�B
    public List<GameObject> clickRayHitter;
    
    //�˒��ő�
    private const float _MAX_DISTANCE = 5;

    /// <summary>
    /// ������
    /// </summary>
    public override void Initialize() {
        
        instance = this;
    }

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // �f�o�b�O���iScene�r���[�Ō�����j
        Debug.DrawRay(ray.origin, ray.direction * _MAX_DISTANCE, Color.green);
    }

    /// <summary>
    /// �����ŃQ�[���I�u�W�F�N�g��������Ă��ꂪ�������Ă��邩�ǂ�����Ԃ�
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public bool GetHitRay(GameObject gameObject) {
        for(int i = 0,max  = rayHitters.Count; i < max; ++i) {
            if (rayHitters[i] == null) continue;
            if (rayHitters[i] == gameObject) return true;

        }
        return false;
    }

    /// <summary>
    /// �N���b�N�Ȃǂ̃A�N�V�����������^�C�~���O�Ń��C���������Ă��邩��Ԃ�
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public bool CheckShootRay(GameObject gameObject) {
        rayHitters.Clear(); // �܂��N���A���Ă���

        // �@ �}�E�X�ʒu����Ray���΂�
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, _MAX_DISTANCE);

        foreach (RaycastHit hit in hits) {
            GameObject obj = hit.collider.gameObject;

            rayHitters.Add(obj);
        }

        if(GetHitRay(gameObject)) return true;
        return false;
    }
}
