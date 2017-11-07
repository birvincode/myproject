using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Transform playerTr;

    public int itemType = 0;

    protected void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //enemy = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Enemy>();
    }


    protected virtual void GetItem()
    {
        //if (ItemManager.Instance.item1 == null || ItemManager.Instance.item2 == null)
        {
            //itemType = Random.Range(0, (int)ItemType.ITEM_MAX);
            itemType = 1;

            //ItemManager.Instance.AddItemToInven(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}