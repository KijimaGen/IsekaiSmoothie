/*
 * Date 2025�N6��27��
 * programar Sum1r3
 * CommonModule.cs
 * �F�X�ėp���̂���֐�����
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConst;

public static class CommonModule {
   
    /// <summary>
    /// enum��������āA���̒����烉���_���Ɉ������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetRandomEnumValue<T>() {
        System.Array values = System.Enum.GetValues(typeof(T));
        return (T) values.GetValue(Random.Range(0, values.Length));
    }

    /// <summary>
    /// ��]���閡�ɂ���ăe�L�X�g��Ԃ�
    /// </summary>
    /// <param name="hopeTaste"></param>
    /// <returns></returns>
    public static string ChangeTextFromTaste(Taste hopeTaste) {
        switch (hopeTaste) {
            case Taste.Sweet:
                return "���܂�\n";
                
            case Taste.Spicy:
                return "���炢\n";
                
            case Taste.Bitter:
                return "�ɂ���\n";
            case Taste.Sour:
                return "�����ς�\n";
        }
        return null;
    }

    /// <summary>
    /// ��]������ʂɂ���ăe�L�X�g��Ԃ�
    /// </summary>
    /// <param name="hopeEffect"></param>
    /// <returns></returns>
    public static string ChangeTextFromEffect(Effect hopeEffect) {
        switch (hopeEffect) {
            case Effect.None:
               return "";
                
            case Effect.Life:
                return "���񂫂����炦��\n";
            case Effect.Power:
                return "�����炪��\n";
            case Effect.Defense:
                return "���񂶂傤�ɂȂ��\n";
            case Effect.Heal:
                return "�����̂Ȃ��肪�͂₭�Ȃ�\n";
            case Effect.Magic:
                return "�܂�傭�����炦��\n";
            case Effect.Lucky:
                return "���񂪂悭�Ȃ�\n";

        }
        return null;
    }
}
