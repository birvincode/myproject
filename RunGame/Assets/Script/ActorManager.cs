using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoSingleton<ActorManager>
{
    List<GameObject> list_Enemy = new List<GameObject>();
    GameObject cloneEnemy;


    int actorStatus;
    bool _isDead;

    bool _loadFin = false;

    public bool isDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }

    void Awake()
    {
        

        list_Enemy = new List<GameObject>();        // 에너미 리스트 동적 할당


        //GameObject[] go = Resources.LoadAll<GameObject>("Prefabs/Enemy");       // 에너미 프리팹 로드

        //for (int i = 0; i < go.Length; i++)                                     // 클론 생성 후 에너미 리스트에 Add
        //{
        //    cloneEnemy = Instantiate(go[i]);
        //    //cloneEnemy.SetActive(false);
        //    list_Enemy.Insert(i, cloneEnemy);
        //    cloneEnemy.transform.position = new Vector3(10f * i, 0f, 0f);
        //}

        GameObject _go = Resources.Load<GameObject>("Prefabs/Player/Player");    // 플레이어 프리팹 로드
        Instantiate(_go);

        _loadFin = true;
    }

    public bool GetLoadComplate()
    {
        return _loadFin;
    }
}
