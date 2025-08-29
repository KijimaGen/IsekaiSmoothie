/**
 * @file SystemObject.cs
 * @brief 各マネージャーの基底クラス
 * @author Sum1r3
 * @date 2025/7/18
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SystemObject : MonoBehaviour{
    public abstract void Initialize();
}
