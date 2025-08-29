/*
 * Date 2025年6月18日
 * programar Sum1r3
 * ShakeManager.cs
 * スマホが揺れているかどうかを感知するための物
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : SystemObject{
    //スマホの現在の加速度
    private Vector3 Acceleration;
    //スマホの1フレーム前の加速度
    private Vector3 preAcceleration;
    //上二つの内積
    float DotProduct;
    //振った回数
    public static int ShakeCount;
    public static ShakeManager instance;
    //スマホ振っているかどうか
    public bool isShake = false;

    
    public void Update() {
        //しゃけふぇーずの時だけ動くように
        if (RoundManager.instance.state == RoundManager.GameState.Shake) {
            ShakeCheck();
            //デバッグ用のしゃけ
            if (Input.GetKeyDown(KeyCode.S)) {
                ShakeCount++;
                
                SoundManager.instance.PlaySound(1);
            }
        }
        //1フレームだけ振っているかどうかを判定したい
        if(isShake)
        isShake = false;
    }


    /// <summary>
    /// スマホが揺れているかどうかのチェック
    /// </summary>
    void ShakeCheck() {
        //現在の移動ベクトルをpreに代入
        preAcceleration = Acceleration;
        //現在の移動フレームの書き換え
        Acceleration = Input.acceleration;
        //二つのベクトルの内積を求める
        DotProduct = Vector3.Dot(Acceleration, preAcceleration);
        //内積が0以下 = 逆方向に動いているので処理 
        if(DotProduct < 0) {
            ShakeCount++;
            SoundManager.instance.PlaySound(1);
            isShake=true;
        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void Initialize() {
        instance = this;
    }

    /// <summary>
    /// 振るときの力を送る
    /// </summary>
    /// <returns></returns>
    public Vector3 GetShakePower() {
        return Acceleration;
    }

    /// <summary>
    /// 今振られているかを送る
    /// </summary>
    /// <returns></returns>
    public bool IsShake() {
        return isShake;
    }

}
