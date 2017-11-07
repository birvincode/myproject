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
        if (transform.root.tag.Equals("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("더미사용");
                this.transform.parent = ItemManager.Instance.itemFolder;

            }
        }
    }

    protected override void GetItem()
    {
        this.transform.SetParent(playerTr.Find("Model/EvilbearG/Root_M/Spine1_M"));
        this.transform.position = playerTr.forward;
    }
}
