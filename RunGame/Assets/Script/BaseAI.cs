using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseAI : MonoBehaviour
{
    int aiType = (int)AIType.IDLE;

    NavMeshAgent enemyAgent;

    GameObject[] checkPoint;

    public int curCheckPoint = 0;

    Actor[] actor;

    List<Actor> list_Distance = new List<Actor>();


    bool spot;

    void Start ()
    {
        enemyAgent = GetComponent<NavMeshAgent>();

        checkPoint = GameObject.FindGameObjectsWithTag("CheckPoint");

        actor = GameObject.FindObjectsOfType<Actor>();

        for (int i = 0; i < actor.Length; i++)
        {
            if (actor[i] == gameObject)
            {
                continue;
            }
            list_Distance.Add(actor[i]);
        }
    }

    void Update ()
    {
        RunAI();
	}

    void RunAI()
    {
        switch (aiType)
        {
            case (int)AIType.IDLE:
                {
                    aiType = (int)AIType.RUN;
                }
                break;

            case (int)AIType.RUN:
                {
                    SetMove();
                }
                break;

            case (int)AIType.ATTACK:
                {

                }
                break;
        }
    }

    int SetAIType()
    {



        return aiType;
    }

    // RunAI는 각각의 AI상황에 할 일을 결정하고
    // SetAIType은 그 AI상황을 결정


    void SetMove()
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
        if (enemyAgent.transform.position == enemyAgent.destination)
            curCheckPoint++;
    }

    Actor SearchTarget()
    {
        Actor target = actor[0];

        for (int i = 0; i < actor.Length - 1; i++)

        {
            if (i > 0 && 
                (Vector3.Distance(transform.position, actor[i].transform.position) > Vector3.Distance(transform.position, actor[i - 1].transform.position)))
            {
                target = actor[i];
            }
        }

        return target;
    }


}
