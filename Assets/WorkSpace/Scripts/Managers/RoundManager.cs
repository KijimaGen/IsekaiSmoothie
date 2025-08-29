/*
 * Date 2025年6月18日
 * programar Sum1r3
 * RoundManager.cs
 * ラウンド(作って提供して評価してもらうまで)の処理管理
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static ShopModeUtility;

public class RoundManager : SystemObject{
    public enum GameState {
        GameStart,
        Come,
        Make,
        Shake,
        Drink,
        Result,
        Go,
        Max
    };

    public GameState state;

    public static RoundManager instance;
   
    /// <summary>
    /// ラウンドステート遷移！
    /// </summary>
    /// <param name="state"></param>
    public void ChangeState(GameState state) {
        this.state = state;
    }

    public override void Initialize() {
        instance = this;
        MasterDataManager.LoadAllData();
        state = GameState.GameStart;
    }

    private void Update() {
        //ゲームステートによって制限時間を減らすかどうかを遷移
        if (state == GameState.Make || state == GameState.Shake)
            SetIsReduceTime(true);
        else
            SetIsReduceTime(false);

        //ゲームステートによってリザルトステートに遷移するか確認
        if(state == GameState.Come)
            SetIsHospitality(true);
        if (state == GameState.Go) {
            SetIsReduceTime(false);
            SetIsHospitality(false);
        }
            

    }

}
