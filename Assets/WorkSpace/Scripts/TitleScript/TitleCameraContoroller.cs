/**
 * @file TitleCameraContoroller.cs
 * @brief タイトルのカメラコントロール
 * @author Sum1r3
 * @date 2025/7/4
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static GameConst;

public class TitleCameraContoroller : MonoBehaviour{

    //目標地点(面倒臭いのでTra)
    [SerializeField] private Transform targetTra;
    private Vector3 targetPos;

    //真ん中地点
    private Vector3 halfPos;

    //視線
    [SerializeField] private GameObject targetItem;

    //円運動
    float radius;
    float rotationSpeed = 10f;
    float time = 0f;

    private void Start() {
        targetPos = targetTra.position;
        halfPos = (this.transform.position + targetPos) / 2;
        radius = Vector3.Distance(halfPos, this.transform.position);

        
    }
    private void Update() {
        if (TitleManager.instance.state == TitleState.Select) {
            
            //CalcPos();
            LookRotation(targetTra.position);
        }
       
    }

    private void CalcPos() {
        time += Time.deltaTime;
       
        //角度を時間で変化させる
        float angle = -time * rotationSpeed * TOW_PI;

        // x = r * cos(θ),z = r * sin(θ)
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        //位置を更新
        transform.position = halfPos + new Vector3(x, 0, z);

        Look(halfPos);


    }

    /// <summary>
    /// 旧方向遷移(戦いのあと)
    /// </summary>
    /// <param name="center"></param>
    private void Look(Vector3 center) {
        //外側を向く
        Vector3 dir = (transform.position - center).normalized;
        transform.forward = dir;
    }

    /// <summary>
    /// 方向遷移(ゆっくり)
    /// </summary>
    /// <param name="targetPos"></param>
    private void LookRotation(Vector3 targetPos) {
        //目標と自分の方向ベクトルを求める
        Vector3 direction = (targetPos - this.transform.position).normalized;

        //自身の回転を目標ベクトルにspeedのスピードで回転
        // direction は Vector3（向き）
        // rotationSpeed は 毎秒何度回転するか
        Quaternion targetRot = Quaternion.LookRotation(direction);

        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
    }
}
