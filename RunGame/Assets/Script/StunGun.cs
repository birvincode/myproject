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

        if (Input.GetMouseButtonDown(0) && transform.root.tag.Equals("Player"))
        {
            Physics.Raycast(playerTr.position, playerTr.forward, out hit, 100f);                // 레이를 쏴서 Enemy만 걸러냄

            Debug.DrawRay(playerTr.position, playerTr.forward * 100f, Color.red, 10f);

            _stunGunCollider = hit.collider;

            this.gameObject.SetActive(false);
        }
    }



    protected override void GetItem()
    {
        this.transform.SetParent(playerTr.Find("Root2/Spine/Chest/r_clavicle/r_shoulder/r_elbow/r_wrist/r_hand"));
    }

}