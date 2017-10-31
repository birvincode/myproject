using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoSingleton<StageManager>
{        
    int currStage = 5;
    int nextStage;

    // 현재 스테이지 반환
    public int GetCurrStage()
    {
        return currStage;
    }

    public int GetNextStage(int _currStage)
    {
        nextStage = currStage + 1;

        return nextStage;
    }
}
