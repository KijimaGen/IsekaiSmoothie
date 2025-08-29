/**
 * @file SystemManager.cs
 * @brief 各マネージャーの管理クラス
 * @author Sum1r3
 * @date 2025/7/18
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SystemManager : MonoBehaviour{
    /// <summary>
    /// 管理するシステムオブジェクトのリスト
    /// </summary>
    [SerializeField]
    private SystemObject[] _systemObjectList = null;

    private void Awake() {
        Initialize();
        Screen.SetResolution(1080, 1920, true);
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <returns></returns>
    private void Initialize() {
        // 全システムオブジェクトの生成、初期化
        for (int i = 0, max = _systemObjectList.Length; i < max; i++) {
            SystemObject origin = _systemObjectList[i];
            if (origin == null) continue;
            // システムオブジェクト生成
            SystemObject createObject = Instantiate(origin, transform);
            // 初期化
            createObject.Initialize();
        }
        
    }
}
