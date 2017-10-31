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
        if ((ItemManager.Instance.select1 && ItemManager.Instance.item1 == gameObject) ||
            (ItemManager.Instance.select2 && ItemManager.Instance.item2 == gameObject))
        {
            if (Input.GetMouseButtonDown(0))        // 마우스 왼쪽버튼 눌렀을 때
            {
                Physics.Raycast(playerTr.position, playerTr.forward, out hit, 100f, 1 << 11);       // 레이캐스트를 쏴서 Enemy만 걸러냄

                Debug.DrawRay(playerTr.position, playerTr.forward * 100f, Color.red, 10f);

                _razerCollider = hit.collider;

                ItemManager.Instance.DiscardItem(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }

    }
}
