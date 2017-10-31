using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Transform playerTr;

    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        // TODO : 위치차에 의한 메서드 발행 > 일정 가속도로 따라감
        transform.position = playerTr.position + new Vector3(0f, 20f, -6f);
        transform.eulerAngles = new Vector3(60f, 0f, 0f);
    }
}