/**
 * @file FadeManager.cs
 * @brief �t�F�[�h�̊Ǘ�
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
    //���g�ւ̎Q��
    public static FadeManager instance;
    //�t�F�[�h�̍���
    [SerializeField]
    private Image BackGround;
    
    //�ǂ̂��炢�̎��Ԃ������ăt�F�[�h�C���t�F�[�h�A�E�g���邩�̊�{�l
    private const float _DEFAULT_FADE_DURATION = 0.5f;

    /// <summary>
    /// ����������
    /// </summary>
    public override void Initialize() {
        instance = this;
    }

    /// <summary>
    /// �t�F�[�h�A�E�g�A�Â�����
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    public async UniTask FadeOut(float duration = _DEFAULT_FADE_DURATION) {
        await Fade(1.0f, duration);
    }

    /// <summary>
    /// �t�F�[�h�C���A�ǂ����H���邭�Ȃ������낤�H
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    public async UniTask FadeIn(float duration = _DEFAULT_FADE_DURATION) {
        await Fade(0.0f, duration);
    }


    /// <summary>
    /// �t�F�[�h
    /// </summary>
    /// <param name="fade"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    public async UniTask Fade(float targetAlpha,float duration) {
        float time = 0;
        Color color = BackGround.color;         //����p�̐F
        float alphaMin = BackGround.color.a;    //�Œ�l
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
