/**
 * @file ScreenSetter.cs
 * @brief ��ʂ̃T�C�Y���Œ肷�邽�߂̂���(�����Œn�������邩������Ȃ�)
 * @author Sum1r3
 * @date 2025/7/25
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenSetter {
    /// <summary>
    /// ���������ɃJ�����̌�����͈͂𒲐�����16:9���ێ�
    /// </summary>
    public static void Initialize() {
        //�ݒ肵�����A�X�y�N�g��
        float targetAspect = 9f / 16f;  

        Camera cam = Camera.main;
        //���݂̔䗦���m�F
        float windowAspect = (float)Screen.width / Screen.height;   
        float scaleHeight = windowAspect / targetAspect;

        //�[�����c���Ȃ̂ŏ㉺�Ƀ��^�[�{�b�N�X
        if (scaleHeight < 1.0f) {
            Rect rect = cam.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            cam.rect = rect;
        }
        //�[���������Ȃ̂ō��E�Ƀs���[�{�b�N�X
        else {
            float scaleWidth = 1.0f / scaleHeight;
            
            Rect rect = cam.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;

            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            cam.rect = rect;
        }
    }
}
