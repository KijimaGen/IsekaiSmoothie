/*
 * Date 2025�N6��25��
 * programar Sum1r3
 * GameConst.cs
 * �Q�[���̒萔�Ƃ��`
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

    //�����鎞�Ԃ̉���
    public const float _TIME_BOTTOM = -1;

    //�����̔���̂��߂̃��m
    public const float DISTANCE_MIN = 0.1f;

    //���W�A���p�ɂ��邽�߂̃��m
    public const float TOW_PI = Mathf.PI * 2;

    //�T�C���g���s���Ƃ���-�ɍs���Ȃ��悤�ɂ��邽�߂̃��m�̃R���X�g
    public const float SIN_TO_ABS = 0.5f + 0.5f;

    //�]���ɂ��X�R�A�̗�
    public enum EvaluationScore {
        Soso = 100,
        Good = 200,
        VeryGood = 300,
    }
    //�^�C�g���V�[���̖��O
    public const string TITLE_SCENE_NAME = "TitleScene";
    //���C���Q�[���V�[���̖��O
    public const string SHOPMODE_SCENE_NAME = "MainGameScene";

}