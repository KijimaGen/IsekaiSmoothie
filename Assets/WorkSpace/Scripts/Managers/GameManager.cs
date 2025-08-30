/*
 * Date 2025年6月9日
 * programar Sum1r3
 * GameManager.cs
 * ゲームマネージャー
 */
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : SystemObject{
    bool stopGameTime = false;

    public static GameManager instance;
    public override void Initialize() {
        instance = this;
        SoundManager.instance.PlayBGM(1);
    }


    void Update(){
        if (stopGameTime) {
            Time.timeScale = 0.0f;
        }
        else {
            Time.timeScale = 1.0f;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            stopGameTime = stopGameTime?false:true;
        }
    }

    public void SetGameStop(bool setGameTime) {
        stopGameTime = setGameTime;
    }

    public bool GetGameStop() {
        return stopGameTime;
    }

    
}
