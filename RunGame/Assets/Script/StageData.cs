using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageData : MonoSingleton<StageData>
{
    List<Vector2> list_StageSize = new List<Vector2>();

    void Awake()
    {
        list_StageSize.Insert(0, new Vector2(1, 1));
        list_StageSize.Insert(1, new Vector2(2, 2));     // Test로 숫자 임시 변경
        list_StageSize.Insert(2, new Vector2(2, 3));
        list_StageSize.Insert(3, new Vector2(3, 2));
        list_StageSize.Insert(4, new Vector2(2, 4));
        list_StageSize.Insert(5, new Vector2(3, 3));
        list_StageSize.Insert(6, new Vector2(3, 4));
        list_StageSize.Insert(7, new Vector2(4, 3));
        list_StageSize.Insert(8, new Vector2(3, 5));
        list_StageSize.Insert(9, new Vector2(4, 4));
        list_StageSize.Insert(10, new Vector2(4, 5));
        list_StageSize.Insert(11, new Vector2(5, 4));
        list_StageSize.Insert(12, new Vector2(4, 6));
        list_StageSize.Insert(13, new Vector2(5, 5));
    }

    public Vector2 GetStageSize(int _stageLevel)
    {
        Vector2 temp = list_StageSize[_stageLevel];

        return temp;
    }
}
