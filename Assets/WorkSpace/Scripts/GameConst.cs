/*
 * Date 2025年6月25日
 * programar Sum1r3
 * GameConst.cs
 * ゲームの定数とか～
 */

using UnityEngine;

public static class GameConst {
    public enum Effect {
        None,
        Life,
        Power,
        Defense,
        Heal,
        Magic,
        Lucky,
        Max,
    }


    public enum Taste {
        None,
        Sweet,
        Spicy,
        Bitter,
        Sour,
        Chaos,
        Max,
    }

    public enum TitleState {
        Start,
        Select,
        GameStart,
        Max,
    }

    public enum ShopModeState {
        Start,
        Game,
        Result,
        Max,
    }

    //下がる時間の下限
    public const float _TIME_BOTTOM = -1;

    //距離の判定のためのモノ
    public const float DISTANCE_MIN = 0.1f;

    //ラジアン角にするためのモノ
    public const float TOW_PI = Mathf.PI * 2;

    //サイン波を行うときに-に行かないようにするためのモノのコンスト
    public const float SIN_TO_ABS = 0.5f + 0.5f;

    //評価によるスコアの量
    public enum EvaluationScore {
        Soso = 100,
        Good = 200,
        VeryGood = 300,
    }
    //タイトルシーンの名前
    public const string TITLE_SCENE_NAME = "TitleScene";
    //メインゲームシーンの名前
    public const string SHOPMODE_SCENE_NAME = "MainGameScene";

}