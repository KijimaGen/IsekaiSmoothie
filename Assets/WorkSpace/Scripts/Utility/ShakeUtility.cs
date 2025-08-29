/**
 * @file ShakeUtility.cs
 * @brief ƒXƒ}ƒz‚ğU‚éŠÖ˜A‚Ì•Ö—˜‚È‹@”\‚Ü‚Æ‚ß
 * @author Sum1r3
 * @date 2025/8/25
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeUtility {
    //U‚Á‚Ä‚¢‚é—Í‚ğ“n‚·
    public static Vector3 GetShakePower() {
        return ShakeManager.instance.GetShakePower();
    }

    //U‚Á‚Ä‚¢‚é‚©‚Ç‚¤‚©‚ğ“n‚·
    public static bool IsShake() {
        return ShakeManager.instance.IsShake();
    }
}
