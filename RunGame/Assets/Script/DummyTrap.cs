using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTrap : Item
{
    private void Update()
    {
        UseDummyTrap();
    }


    void UseDummyTrap() // ToDo 좌표수정
    {
        if ((ItemManager.Instance.select1 && ItemManager.Instance.item1 == gameObject) ||
            (ItemManager.Instance.select2 && ItemManager.Instance.item2 == gameObject))
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("더미사용");
                this.transform.parent = ItemManager.Instance.itemFolder;

                ItemManager.Instance.DiscardItem(this.gameObject);
            }
        }
    }
}
