﻿using System.Collections;
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


    protected override void UseItem()
    {
        if (Input.GetMouseButtonDown(0) && transform.root.tag.Equals("Player"))
        {
            Physics.Raycast(transform.position, transform.forward, out hit, 100f);                // 레이를 쏴서 Enemy만 걸러냄

            Debug.DrawRay(transform.position, transform.forward * 100f, Color.red, 10f);

            _stunGunCollider = hit.collider;

            _stunGunCollider.GetComponent<BaseAI>().isStunned = true;

            isItemUsed = true;

            this.gameObject.SetActive(false);
        }
        else if (baseAI.curAIType == (int)AIType.USEITEM && transform.root.tag.Equals("Enemy"))
        {
            Physics.Raycast(transform.position, baseAI.targetActor.transform.position, out hit, 100f);

            Debug.DrawRay(transform.position, baseAI.targetActor.transform.position, Color.blue, 10f);

            _stunGunCollider = hit.collider;

            _stunGunCollider.GetComponent<BaseAI>().isStunned = true;

            isItemUsed = true;
        }
    }
}