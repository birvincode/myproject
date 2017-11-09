using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Transform playerTr;

    public int itemType = 0;

    protected Actor actor;

    public bool isItemUsed = false;

    protected void Start()
    {
        actor = transform.root.GetComponent<Actor>();
    }
    
    void Update()
    {
        UseItem();
    }


    protected virtual void UseItem()
    {

    }

}