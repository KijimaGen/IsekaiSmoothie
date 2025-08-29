/**
 * @file RayUtility.cs
 * @brief ���C�L���X�g�֘A�̏����B
 * @author Sum1r3
 * @date 2025/7/18
 */
using UnityEngine;

public class RayUtility {
    public static bool GetHitRay(GameObject gameObject) {
        return RayManager.instance.GetHitRay(gameObject);
    }

    public static bool CheckShootRay(GameObject gameObject) {
        return RayManager.instance.CheckShootRay(gameObject);
    }
}
