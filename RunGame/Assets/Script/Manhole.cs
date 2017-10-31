using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manhole : MonoBehaviour
{

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PLAYER")
        {
            Debug.Log("다음스테이지로");

            StageManager.Instance.GetNextStage(StageManager.Instance.GetCurrStage());
        }
    }
}
