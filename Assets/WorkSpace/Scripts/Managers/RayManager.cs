/**
 * @file RayManager.cs
 * @brief レイキャスト処理
 * @author Sum1r3
 * @date 2025/7/18
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayManager : SystemObject{

    public static RayManager instance;
    
    //レイキャスト関連
    public List<GameObject> rayHitters;
    //クリックしたとき限定のレイヒット達
    public List<GameObject> clickRayHitter;
    
    //射程最大
    private const float _MAX_DISTANCE = 5;

    /// <summary>
    /// 初期化
    /// </summary>
    public override void Initialize() {
        
        instance = this;
    }

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // デバッグ線（Sceneビューで見える）
        Debug.DrawRay(ray.origin, ray.direction * _MAX_DISTANCE, Color.green);
    }

    /// <summary>
    /// 引数でゲームオブジェクトをもらってそれが当たっているかどうかを返す
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
    /// クリックなどのアクションをしたタイミングでレイが当たっているかを返す
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public bool CheckShootRay(GameObject gameObject) {
        rayHitters.Clear(); // まずクリアしてから

        // ① マウス位置からRayを飛ばす
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
