using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTrap : Item
{


    protected override void UseItem() // ToDo 좌표수정
    {
        if (transform.root.tag.Equals("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                this.transform.parent = ItemManager.Instance.itemFolder;

                isItemUsed = true;
            }
        }
    }

}
