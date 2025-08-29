/**
 * @file SystemManager.cs
 * @brief �e�}�l�[�W���[�̊Ǘ��N���X
 * @author Sum1r3
 * @date 2025/7/18
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SystemManager : MonoBehaviour{
    /// <summary>
    /// �Ǘ�����V�X�e���I�u�W�F�N�g�̃��X�g
    /// </summary>
    [SerializeField]
    private SystemObject[] _systemObjectList = null;

    private void Awake() {
        Initialize();
        Screen.SetResolution(1080, 1920, true);
    }

    /// <summary>
    /// ����������
    /// </summary>
    /// <returns></returns>
    private void Initialize() {
        // �S�V�X�e���I�u�W�F�N�g�̐����A������
        for (int i = 0, max = _systemObjectList.Length; i < max; i++) {
            SystemObject origin = _systemObjectList[i];
            if (origin == null) continue;
            // �V�X�e���I�u�W�F�N�g����
            SystemObject createObject = Instantiate(origin, transform);
            // ������
            createObject.Initialize();
        }
        
    }
}
