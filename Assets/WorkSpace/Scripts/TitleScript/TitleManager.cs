/**
 * @file TitleManager.cs
 * @brief タイトルの基本処理
 * @author Sum1r3
 * @date 2025/7/4
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameConst;

public class TitleManager : SystemObject {
    //初期設定で必要なもの
    public TitleState state { get; private set; }
    public static TitleManager instance;

    [SerializeField]
    private CanvasGroup canvasGroup;

    //点滅周期
    private const float cycle = 1.5f;
    private float time = 0;

    private async void Update() {
        switch (state) {
            case TitleState.Start:
                canvasGroup.alpha = FlashUI(canvasGroup.alpha);
                if(Input.GetMouseButtonDown(0)){
                    state = TitleState.Select;
                    canvasGroup.alpha = 0;
                }
                break;
            case TitleState.Select:
                if (Input.GetMouseButtonDown(0)) {
                    await FadeManager.instance.FadeOut();
                    SceneManager.LoadScene(SHOPMODE_SCENE_NAME);
                    canvasGroup.alpha = 0;
                }
                break;
            case TitleState.GameStart:
                break;
            case TitleState.Max:
                break;
        }
    }

    /// <summary>
    /// イージングも利用したタイトル画面の帯をつけたり消したりする処理
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private float FlashUI(float value) {
        time += Time.deltaTime;

        // 0〜1の範囲で進む正規化時間
        float t = (time % cycle) / cycle;

        // 0〜1の範囲で上下する波（Cosを使ったサイクル波）
        float raw = Mathf.Cos(2 * Mathf.PI * t) * 0.5f + 0.5f;

        // イージング関数で波形を歪ませて「見えている状態が長く」する
        // ここでは「EaseOutQuart」を利用（なめらかに暗くなる）
        float eased = EaseOutQuart(raw);

        // α値を計算（0〜1）
        value = eased;

        return value;

    }

    /// <summary>
    /// ゆっくり暗くなるイージング（見えている状態が長くなる）
    /// </summary>
    /// <param name="EaseValue"></param>
    /// <returns></returns>
    float EaseOutQuart(float EaseValue) {
        return 1 - Mathf.Pow(1 - EaseValue, 4);
    }

    public override async void Initialize() {
        instance = this;
        state = TitleState.Start;
        await FadeManager.instance.FadeIn();
        SoundManager.instance.PlayBGM(0);
    }
}
