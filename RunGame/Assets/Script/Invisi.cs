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

    SkinnedMeshRenderer actorMesh;

    protected override void Start()
    {
        base.Start();

        actorMesh = transform.root.Find("Character_2_geometry1").GetComponent<SkinnedMeshRenderer>();
    }



    protected override void UseItem()        // ToDo 최적화 필요
    {
        if (transform.root.tag.Equals("Player"))
        {
            stackTime += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Alpha1) && onInvisi == false)     // 마우스 왼쪽버튼 눌렀을 때
            {
                stackTime = 0f;
                onInvisi = true;
                actorMesh.material.color = new Color(actorMesh.material.color.r, actorMesh.material.color.g, actorMesh.material.color.b, 0.3f);
                this.transform.localScale = Vector3.zero;
            }

            // 제한시간 끝나면 되돌리고 아이템 빼기
            if (stackTime >= invisiTime && onInvisi)
            {
                actorMesh.material.color = new Color(actorMesh.material.color.r, actorMesh.material.color.g, actorMesh.material.color.b, 1f);
                onInvisi = false;

                isItemUsed = true;

                this.gameObject.SetActive(false);
            }
        }
        else if (transform.root.tag.Equals("Enemy"))
        {
            stackTime += Time.deltaTime;

            if (baseAI.curAIType == (int)AIType.USEITEM && onInvisi == false)     // 마우스 왼쪽버튼 눌렀을 때
            {
                stackTime = 0f;
                onInvisi = true;
                actorMesh.material.color = new Color(actorMesh.material.color.r, actorMesh.material.color.g, actorMesh.material.color.b, 0.3f);
                this.transform.localScale = Vector3.zero;
            }

            // 제한시간 끝나면 되돌리고 아이템 빼기
            if (stackTime >= invisiTime && onInvisi)
            {
                actorMesh.material.color = new Color(actorMesh.material.color.r, actorMesh.material.color.g, actorMesh.material.color.b, 1f);
                onInvisi = false;

                isItemUsed = true;

                this.gameObject.SetActive(false);
            }
        }
    }


}