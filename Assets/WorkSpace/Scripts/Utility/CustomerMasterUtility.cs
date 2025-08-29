/**
 * @file CustomerMasterUtility.cs
 * @brief お客さんのマスターデータの実行処理
 * @author Sum1r3
 * @date 2025/7/4
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMasterUtility{
    /// <summary>
    /// ID指定のカスタマーマスター取得
    /// </summary>
    /// <param name="MasterID"></param>
    /// <returns></returns>
    public static Entity_CustomerMasterData.Param GetCustomerMaster(int MasterID) {
        //キャラクターマスターデータ取得
        List<Entity_CustomerMasterData.Param> customerMasterList = MasterDataManager.customerData[0];
        //IDが一致するものを返す
        for (int i = 0, max = customerMasterList.Count; i < max; i++) {
            if (customerMasterList[i].ID != MasterID) continue;
            return customerMasterList[i];
        }
        return null;
    }
}
