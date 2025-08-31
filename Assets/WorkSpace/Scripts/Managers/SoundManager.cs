/**
 * @file SoundManager.cs
 * @brief ���֌W�̃}�l�[�W���[
 * @author Sum1r3
 * @date 2025/6/17
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SystemObject{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource BGMSource;
    [SerializeField]
    private AudioSource SoundSource;
    [SerializeField]
    private List<AudioClip> BGMClips = new List<AudioClip>();
    [SerializeField]
    private List<AudioClip> SoundClips = new List<AudioClip>();
    

    /// <summary>
    /// SE�𗬂�
    /// </summary>
    /// <param name="SoundIndex"></param>
    public void PlaySound(int SoundIndex) {
        if (BGMSource == null || SoundIndex > SoundClips.Count || SoundIndex < 0) return; 

        SoundSource.PlayOneShot(SoundClips[SoundIndex]);
    }

    public override void Initialize() {
        instance = this;
    }
    /// <summary>
    /// ���y�𗬂�
    /// </summary>
    /// <param name="SoundIndex"></param>
    public void PlayBGM(int SoundIndex)
    {
        if (BGMSource == null || SoundIndex > BGMClips.Count || SoundIndex < 0) return;

        BGMSource.clip = BGMClips[SoundIndex];
        BGMSource.Play();
    }

}
