/*
 * Date 2025�N6��18��
 * programar Sum1r3
 * RoundManager.cs
 * ���E���h(����Ē񋟂��ĕ]�����Ă��炤�܂�)�̏����Ǘ�
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static ShopModeUtility;

public class RoundManager : SystemObject{
    public enum GameState {
        GameStart,
        Come,
        Make,
        Shake,
        Drink,
        Result,
        Go,
        Max
    };

    public GameState state;

    public static RoundManager instance;
   
    /// <summary>
    /// ���E���h�X�e�[�g�J�ځI
    /// </summary>
    /// <param name="state"></param>
    public void ChangeState(GameState state) {
        this.state = state;
    }

    public override void Initialize() {
        instance = this;
        MasterDataManager.LoadAllData();
        state = GameState.GameStart;
    }

    private void Update() {
        //�Q�[���X�e�[�g�ɂ���Đ������Ԃ����炷���ǂ�����J��
        if (state == GameState.Make || state == GameState.Shake)
            SetIsReduceTime(true);
        else
            SetIsReduceTime(false);

        //�Q�[���X�e�[�g�ɂ���ă��U���g�X�e�[�g�ɑJ�ڂ��邩�m�F
        if(state == GameState.Come)
            SetIsHospitality(true);
        if (state == GameState.Go) {
            SetIsReduceTime(false);
            SetIsHospitality(false);
        }
            

    }

}
