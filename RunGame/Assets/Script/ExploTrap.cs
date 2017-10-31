using System.Collections;
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


    private void Update()
    {
        UseExploTrap();
    }


    void UseExploTrap()
    {
        if ((ItemManager.Instance.select1 && ItemManager.Instance.item1 == gameObject) ||
            (ItemManager.Instance.select2 && ItemManager.Instance.item2 == gameObject))
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                this.transform.parent = ItemManager.Instance.itemFolder;
                this.transform.position = playerTr.forward;
                this.transform.localRotation = Quaternion.Euler(90f, -90f, 0f);

                ItemManager.Instance.DiscardItem(this.gameObject);
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
