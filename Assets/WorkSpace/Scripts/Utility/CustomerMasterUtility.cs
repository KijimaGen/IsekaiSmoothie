/**
 * @file CustomerMasterUtility.cs
 * @brief ���q����̃}�X�^�[�f�[�^�̎��s����
 * @author Sum1r3
 * @date 2025/7/4
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMasterUtility{
    /// <summary>
    /// ID�w��̃J�X�^�}�[�}�X�^�[�擾
    /// </summary>
    /// <param name="MasterID"></param>
    /// <returns></returns>
    public static Entity_CustomerMasterData.Param GetCustomerMaster(int MasterID) {
        //�L�����N�^�[�}�X�^�[�f�[�^�擾
        List<Entity_CustomerMasterData.Param> customerMasterList = MasterDataManager.customerData[0];
        //ID����v������̂�Ԃ�
        for (int i = 0, max = customerMasterList.Count; i < max; i++) {
            if (customerMasterList[i].ID != MasterID) continue;
            return customerMasterList[i];
        }
        return null;
    }
}
