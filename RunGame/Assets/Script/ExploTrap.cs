﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploTrap : Item
{
    bool _isExploTrapHit = false;
    public bool isExploTrapHit
    {
        get { return _isExploTrapHit; }
        set { _isExploTrapHit = value; }
    }




    protected override void UseItem()
    {
        if (transform.root.tag.Equals("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                this.transform.parent = ItemManager.Instance.itemFolder;
                this.transform.position = transform.root.position + new Vector3(0f, 0f, -1f);
                this.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

                isItemUsed = true;
            }
        }
        else if(transform.root.tag.Equals("Enemy"))
        {
            if (baseAI.curAIType == (int)AIType.USEITEM)
            {
                this.transform.parent = ItemManager.Instance.itemFolder;
                this.transform.position = transform.root.position + new Vector3(0f, 0f, -1f);
                this.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

                isItemUsed = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //if(other==enemy.gameObject)
        {
            isExploTrapHit = true;
            this.gameObject.SetActive(false);
        }
    }

}
