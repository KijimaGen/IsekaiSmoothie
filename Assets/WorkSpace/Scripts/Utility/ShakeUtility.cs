/**
 * @file ShakeUtility.cs
 * @brief �X�}�z��U��֘A�֗̕��ȋ@�\�܂Ƃ�
 * @author Sum1r3
 * @date 2025/8/25
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeUtility {
    //�U���Ă���͂�n��
    public static Vector3 GetShakePower() {
        return ShakeManager.instance.GetShakePower();
    }

    //�U���Ă��邩�ǂ�����n��
    public static bool IsShake() {
        return ShakeManager.instance.IsShake();
    }
}
