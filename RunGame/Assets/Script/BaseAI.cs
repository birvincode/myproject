using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseAI : MonoBehaviour
{
    int prevAIType;
    int curAIType = (int)AIType.IDLE;

    NavMeshAgent enemyAgent;

    GameObject[] checkPoint;

    public int curCheckPoint = 0;

    Actor[] actor;

    Actor targetActor;

    Actor selfActor;

    GameObject targetBox;

    List<Actor> list_DistActor = new List<Actor>();

    float stackTimeActor = 0f;
    float stackTimeBox = 0f;

    bool isAttacked = false;

    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();

        checkPoint = GameObject.FindGameObjectsWithTag("CheckPoint");

        selfActor = GetComponent<Actor>();

        actor = GameObject.FindObjectsOfType<Actor>();
        for (int i = 0; i < actor.Length; i++)
        {
            if (actor[i] == selfActor)
            {
                continue;
            }
            list_DistActor.Add(actor[i]);
        }
    }

    void Update()
    {
        SearchTarget();
        SearchBox();
        SetAIType();
        Debug.Log(curAIType);

        RunAI();
    }

    void RunAI()
    {
        if (curAIType == prevAIType)
            return;

        switch (curAIType)
        {
            case (int)AIType.IDLE:
                {
                    curAIType = (int)AIType.RUN;
                }
                break;

            case (int)AIType.STOP:
                {

                }
                break;

            case (int)AIType.USEITEM:
                {

                }
                break;

            case (int)AIType.GETBOX:
                {
                    GetBox();
                }
                break;

            case (int)AIType.ATTACK:
                {
                    MoveToTarget();
                    Attack();
                }
                break;

            case (int)AIType.RUN:
                {
                    MoveToCheckPoint();
                }
                break;

            case (int)AIType.STUN:
                {

                }
                break;

            case (int)AIType.HIT:
                {

                }
                break;
        }

        prevAIType = curAIType;
    }

    void SetAIType()     //ToDo 무수한 예외상황 추가
    {
        if (curCheckPoint == checkPoint.Length)
        {
            curAIType = (int)AIType.STOP;
        }

        //else if (true)
        //{
        //    aiType = (int)AIType.STUN;
        //    return;
        //}

        else if (isAttacked)
        {
            curAIType = (int)AIType.HIT;
        }

        else if (selfActor.invenItem != null)
        {
            curAIType = (int)AIType.USEITEM;
        }

        else if (Vector3.Distance(transform.position, targetActor.transform.position) < 5f)
        {
            curAIType = (int)AIType.ATTACK;
        }

        else if (Vector3.Distance(transform.position, targetBox.transform.position) < 10f)
        {
            curAIType = (int)AIType.GETBOX;
        }

        else
        {
            curAIType = (int)AIType.RUN;
        }


    }



    void MoveToCheckPoint()      // Todo 항상 SetDestination 하지 않고 curCheckPoint가 바뀌었을 때만 SetDestination 하게
    {
        for (int i = 0; i < checkPoint.Length; i++)
        {
            CheckPoint go = checkPoint[i].GetComponent<CheckPoint>();

            if (go.pointNum == curCheckPoint)
            {
                enemyAgent.SetDestination(go.transform.position);
                break;
            }
        }
        if (Vector3.Distance(enemyAgent.transform.position, enemyAgent.destination) <3f)
            curCheckPoint++;
    }

    void MoveToTarget()
    {
        enemyAgent.SetDestination(targetActor.transform.position);
    }

    void SearchTarget()
    {
        stackTimeActor += Time.deltaTime;

        if (stackTimeActor > 0.5f)
        {
            targetActor = list_DistActor[0];

            for (int i = 1; i < list_DistActor.Count; i++)
            {
                if (Vector3.Distance(transform.position, list_DistActor[i].transform.position) < Vector3.Distance(transform.position, targetActor.transform.position))
                {
                    targetActor = list_DistActor[i];
                }
            }
            stackTimeActor = 0;
        }
    }

    void SearchBox()
    {
        stackTimeBox += Time.deltaTime;
        if (stackTimeBox > 1f)
        {
            targetBox = ItemManager.Instance.list_Box[0];

            for (int i = 1; i < ItemManager.Instance.list_Box.Count; i++)
            {
                if (Vector3.Distance(transform.position, ItemManager.Instance.list_Box[i].transform.position) <
                    Vector3.Distance(transform.position, targetBox.transform.position))
                {
                    targetBox = ItemManager.Instance.list_Box[i];
                }
            }
            stackTimeBox = 0;
        }
    }

    void GetBox()
    {
        enemyAgent.SetDestination(targetBox.transform.position);
    }

    void Attack()
    {
        targetActor.GetComponent<BaseAI>().isAttacked = true;
        transform.LookAt(targetActor.transform.position);
    }

    void Hit()
    {

    }
}
