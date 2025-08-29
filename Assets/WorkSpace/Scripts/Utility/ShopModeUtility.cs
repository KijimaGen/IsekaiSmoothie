using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConst;

public class ShopModeUtility{
    public static void AddScore(EvaluationScore evaluationScore) {
        ShopModeManager.instance.AddScore(evaluationScore);
    }
    public static void SetIsReduceTime(bool isReduceTime) { 
        ShopModeManager.instance.SetIsReduceTime(isReduceTime);
    }

    public static void SetIsHospitality(bool isHospitality) {
        ShopModeManager.instance.SetIsHospitality(isHospitality);
    }
}
