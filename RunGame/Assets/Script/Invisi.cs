using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisi : Item
{
    RaycastHit hit;

    public float invisiTime = 3f;
    float stackTime = 0f;

    bool _onInvisi = false;          // 투명상태인지 아닌지
    public bool onInvisi
    {
        get { return _onInvisi; }
        set { _onInvisi = value; }
    }

    private void Update()
    {
        UseInvisi();
    }

    void UseInvisi()        // ToDo 최적화 필요
    {
        if (transform.root.tag.Equals("Player"))
        {
            stackTime += Time.deltaTime;

            SkinnedMeshRenderer playerMesh = playerTr.Find("Character_2_geometry1").GetComponent<SkinnedMeshRenderer>();

            if (Input.GetKeyDown(KeyCode.Alpha1) && onInvisi == false)     // 마우스 왼쪽버튼 눌렀을 때
            {
                Debug.Log("투명망토 사용");
                stackTime = 0f;
                onInvisi = true;
                playerMesh.material.color = new Color(playerMesh.material.color.r, playerMesh.material.color.g, playerMesh.material.color.b, 0.3f);
                this.transform.localScale = Vector3.zero;
            }

            // 제한시간 끝나면 되돌리고 아이템 빼기
            if (stackTime >= invisiTime && onInvisi)
            {
                playerMesh.material.color = new Color(playerMesh.material.color.r, playerMesh.material.color.g, playerMesh.material.color.b, 1f);
                onInvisi = false;

                this.gameObject.SetActive(false);
            }
        }
    }


}
