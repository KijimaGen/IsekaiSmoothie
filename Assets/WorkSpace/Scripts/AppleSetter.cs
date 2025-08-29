/**
 * @file AppleSetter.cs
 * @brief ƒŠƒ“ƒS‚Ì’²®
 * @author Sum1r3
 * @date 2025/7/11
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSetter : MonoBehaviour{
    Vector3 AppleRotat = new Vector3 (-90f, 0f, -90f);

    
    void Start()
    {
        transform.Rotate(AppleRotat);
    }
}
