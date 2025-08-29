/**
 * @file FadeManager.cs
 * @brief フェードの管理
 * @author Sum1r3
 * @date 2025/7/28
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;

public class FadeManager : SystemObject{
    //自身への参照
    public static FadeManager instance;
    //フェードの黒幕
    [SerializeField]
    private Image BackGround;
    
    //どのくらいの時間をかけてフェードインフェードアウトするかの基本値
    private const float _DEFAULT_FADE_DURATION = 0.5f;

    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void Initialize() {
        instance = this;
    }

    /// <summary>
    /// フェードアウト、暗くする
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    public async UniTask FadeOut(float duration = _DEFAULT_FADE_DURATION) {
        await Fade(1.0f, duration);
    }

    /// <summary>
    /// フェードイン、どうだ？明るくなっただろう？
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    public async UniTask FadeIn(float duration = _DEFAULT_FADE_DURATION) {
        await Fade(0.0f, duration);
    }


    /// <summary>
    /// フェード
    /// </summary>
    /// <param name="fade"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    public async UniTask Fade(float targetAlpha,float duration) {
        float time = 0;
        Color color = BackGround.color;         //代入用の色
        float alphaMin = BackGround.color.a;    //最低値
        while (time < duration) {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(alphaMin, targetAlpha, time / duration);
            BackGround.color = color;
            await UniTask.Delay(1);
        }
        color.a = targetAlpha;
        BackGround.color = color;
    }

}
