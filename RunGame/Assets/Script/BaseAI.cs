using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseAI : MonoBehaviour
{
    int aiType = (int)AIType.NONE;

    NavMeshAgent enemyAgent;

    CheckPoint checkPoint;

    public int curCheckPoint = 0;

    void Start ()
    {
        enemyAgent = ActorManager.Instance.cloneEnemy.GetComponent<NavMeshAgent>();
        checkPoint = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<CheckPoint>();

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
                case (int)AIType.NONE:
                    {
                        aiType = (int)AIType.IDLE;
                    }
                    break;

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
        if (checkPoint.pointNum == curCheckPoint)
        {
            enemyAgent.SetDestination(checkPoint.transform.position);
        }
        if (enemyAgent.pathStatus == NavMeshPathStatus.PathComplete)
            curCheckPoint++;
    }
}
