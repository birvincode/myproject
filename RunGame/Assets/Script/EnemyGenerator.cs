using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public List<Transform> EnemyList;

    List<GameObject> BattleRoomList;

    private void Start()
    {
        StartCoroutine("GetRoomList");
    }

    IEnumerator GetRoomList()
    {
        while (true)
        {
            bool temp = MapGenerator.Instance.GetFinCreateMap();

            if (temp)
            {
                BattleRoomList = MapGenerator.Instance.GetList_RoomBattle();
            }

            if (BattleRoomList != null)
            {
                StopCoroutine("GetRoomList");
                GenerateEnemy();
            }                

            yield return new WaitForFixedUpdate();
        }
    }

    void GenerateEnemy()
    {
        foreach (GameObject Obj in BattleRoomList)
        {
            Vector3 BasePos = Obj.transform.position;

            for (int i = 0; i < 1; i++)
            {
                Instantiate(EnemyList[Random.Range(0, 3)], BasePos + new Vector3(5.0f, 0.0f, 5.0f), Quaternion.identity);
                Instantiate(EnemyList[Random.Range(0, 3)], BasePos + new Vector3(-5.0f, 0.0f, 5.0f), Quaternion.identity);
                Instantiate(EnemyList[Random.Range(0, 3)], BasePos + new Vector3(5.0f, 0.0f, -5.0f), Quaternion.identity);
                Instantiate(EnemyList[Random.Range(0, 3)], BasePos + new Vector3(-5.0f, 0.0f, -5.0f), Quaternion.identity);
            }
        }
    }
}
