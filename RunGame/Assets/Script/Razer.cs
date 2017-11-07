using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer : Item
{
    RaycastHit hit;

    Collider _razerCollider;
    public Collider razerCollider
    {
        get { return _razerCollider; }
    }


    private void Update()
    {
        UseRazer();
    }

    void UseRazer()
    {
        if (Input.GetMouseButtonDown(0) && transform.root.tag.Equals("Player"))

        {
            if (Input.GetMouseButtonDown(0))        // 마우스 왼쪽버튼 눌렀을 때
            {
                Physics.Raycast(playerTr.position, playerTr.forward, out hit, 100f, 1 << 11);       // 레이캐스트를 쏴서 Enemy만 걸러냄

                Debug.DrawRay(playerTr.position, playerTr.forward * 100f, Color.red, 10f);

                _razerCollider = hit.collider;

                this.gameObject.SetActive(false);
            }
        }
    }

    protected override void GetItem()
    {
        this.transform.SetParent(playerTr.Find("Model/EvilbearG/Root_M/Spine1_M/Chest_M/Scapula_R/Shoulder_R/Elbow_R/Wrist_R"));
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.Euler(-90f, -160f, 70f);
    }
}
