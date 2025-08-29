/*
 * Date 2025年6月27日
 * programar Sum1r3
 * CommonModule.cs
 * 色々汎用性のある関数たち
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConst;

public static class CommonModule {
   
    /// <summary>
    /// enumをもらって、その中からランダムに一個かえす
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetRandomEnumValue<T>() {
        System.Array values = System.Enum.GetValues(typeof(T));
        return (T) values.GetValue(Random.Range(0, values.Length));
    }

    /// <summary>
    /// 希望する味によってテキストを返す
    /// </summary>
    /// <param name="hopeTaste"></param>
    /// <returns></returns>
    public static string ChangeTextFromTaste(Taste hopeTaste) {
        switch (hopeTaste) {
            case Taste.Sweet:
                return "あまい\n";
                
            case Taste.Spicy:
                return "からい\n";
                
            case Taste.Bitter:
                return "にがい\n";
            case Taste.Sour:
                return "すっぱい\n";
        }
        return null;
    }

    /// <summary>
    /// 希望する効果によってテキストを返す
    /// </summary>
    /// <param name="hopeEffect"></param>
    /// <returns></returns>
    public static string ChangeTextFromEffect(Effect hopeEffect) {
        switch (hopeEffect) {
            case Effect.None:
               return "";
                
            case Effect.Life:
                return "げんきがもらえる\n";
            case Effect.Power:
                return "ちからがつく\n";
            case Effect.Defense:
                return "がんじょうになれる\n";
            case Effect.Heal:
                return "きずのなおりがはやくなる\n";
            case Effect.Magic:
                return "まりょくがもらえる\n";
            case Effect.Lucky:
                return "うんがよくなる\n";

        }
        return null;
    }
}
