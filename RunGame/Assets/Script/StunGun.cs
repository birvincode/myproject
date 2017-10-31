using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGun : Item
{
    RaycastHit hit;

    Collider _stunGunCollider;
    public Collider stunGunCollider
    {
        get { return _stunGunCollider; }
    }


    private void Update()
    {
        UseStunGun();
    }

    void UseStunGun()
    {
        if ((ItemManager.Instance.select1 && ItemManager.Instance.item1 == gameObject) ||
            (ItemManager.Instance.select2 && ItemManager.Instance.item2 == gameObject))
        {
            if (Input.GetMouseButtonDown(0))        // 마우스 왼쪽버튼 눌렀을 때
            {

                //QueryTriggerInteraction
                Physics.Raycast(playerTr.position, playerTr.forward, out hit, 100f);        // 레이캐스트를 쏴서 Enemy만 걸러냄

                Debug.DrawRay(playerTr.position, playerTr.forward * 100f, Color.red, 10f);

                _stunGunCollider = hit.collider;

                ItemManager.Instance.DiscardItem(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }
    }
}