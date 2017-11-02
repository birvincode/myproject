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

    void Start ()
    {
        enemyAgent = GetComponent<NavMeshAgent>();

        checkPoint = GameObject.FindGameObjectsWithTag("CheckPoint");

        StartCoroutine("RunAI");
    }

    void Update ()
    {
		
	}

    IEnumerator RunAI()
    {
        while(true)
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
            }

            yield return new WaitForEndOfFrame();
        }

    }
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
}
