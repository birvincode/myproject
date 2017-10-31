using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

    MeshRenderer meshRenderer;
    Player player;

    float _stackTime;
    public float stackTime
    {
        get { return _stackTime; }
        set { _stackTime = value; }
    }

	void Start ()
    {
        meshRenderer = GetComponent<MeshRenderer>();    // 자신의 MeshRenderer 컴포넌트 가져옴

        meshRenderer.material.color = Color.clear;      // 처음 색깔은 투명(Clear)

        player = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Player>();     // Player 스크립트 가져옴

        stackTime = 0f;     // RunFadeOut 함수에서 시간을 체크
	}
	
	void Update ()
    {
        // 방이 바뀌면 RunFadeOut 함수 실행
        if (player.isRoomChanged == true)
            RunFadeOut();

	}

    void RunFadeOut()       // Fade-out과 Fade-in 실행하는 함수
    {
        stackTime += Time.deltaTime;

        //if (stackTime <= 1f)
        //    meshRenderer.material.color = Color.Lerp(Color.clear, Color.black, stackTime);      // 투명에서 블랙으로


        if (stackTime <= 2f)
            meshRenderer.material.color = Color.Lerp(Color.black, Color.clear, stackTime * 0.5f);      // 다시 블랙에서 투명으로


        // Fade-in이 끝나면 함수가 더이상 실행되지 않도록 isRoomChanged false로 변경하고 stackTime은 0으로 변경
        if (stackTime > 2f)
        {
            player.isRoomChanged = false;
            stackTime = 0f;
        }
    }


}
