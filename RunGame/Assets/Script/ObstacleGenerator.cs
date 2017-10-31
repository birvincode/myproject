using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

    public List<Transform> ObstacleList;
    List<GameObject> BattleRoomList;

    public Transform ObstacleHolder;

    private void Start()
    {
        StartCoroutine("GetRoomList");
    }

    IEnumerator GetRoomList()
    {
        while (true)
        {
            bool temp = MapGenerator.Instance.GetFinCreateMap();

            if(temp)
            {
                BattleRoomList = MapGenerator.Instance.GetList_RoomBattle();
            }

            if (BattleRoomList != null)
            {
                StopCoroutine("GetRoomList");
                CreateObstacle();
            }

            yield return new WaitForFixedUpdate();
        }
    }

    void CreateObstacle()
    {
        List<int> OldPosX = new List<int>();
        List<int> OldPosZ = new List<int>();

        int BaseTerm = 10;

        foreach (GameObject Obj in BattleRoomList)
        {
            Vector3 BasePos = Obj.transform.position;                       

            int temp = ObstacleList.Count;

            for (int i = 0; i < 5; i++)
            {
                int posX = Random.Range(-3, 4);
                int posZ = Random.Range(-3, 4);

                bool btemp = false;

                OldPosX.Add(posX);
                OldPosZ.Add(posZ);

                if (OldPosX.Count > 1)
                {
                    for (int j = 0; j < OldPosX.Count - 1; j++)
                    {
                        // 예외처리
                        if (btemp) continue;

                        if (OldPosX[j] == posX)
                        {
                            if (OldPosZ[j] == posZ)
                            {
                                i -= 1;

                                OldPosX.RemoveAt(j);
                                OldPosZ.RemoveAt(j);

                                btemp = true;
                                continue;
                            }
                        }
                    }
                    
                    if (btemp) continue;
                }                    

                Transform ObstacleTr = ObstacleList[Random.Range(0, temp)];
                Vector3 RotatePos = new Vector3(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
                Instantiate(ObstacleTr, BasePos + new Vector3(posX * BaseTerm, 0.0f, posZ * BaseTerm), Quaternion.Euler(RotatePos), ObstacleHolder);
            }

            OldPosX.Clear();
            OldPosZ.Clear();
        }
    }
}
