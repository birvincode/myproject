using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Transform playerTr;

    public int itemType = 0;

    bool _getItem = false;
    public bool getItem
    {
        get { return _getItem; }
        set { _getItem = value; }
    }
    

    //protected Enemy enemy;

    protected void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //enemy = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Enemy>();
    }


    protected void GetItem()
    {
        if (ItemManager.Instance.item1 == null || ItemManager.Instance.item2 == null)
        {
            //itemType = Random.Range(0, (int)ItemType.ITEM_MAX);
            itemType = 1;

            switch (itemType)
            {
                case (int)ItemType.ITEM_RAZER:
                    {
                        this.transform.SetParent(playerTr.Find("Model/EvilbearG/Root_M/Spine1_M/Chest_M/Scapula_R/Shoulder_R/Elbow_R/Wrist_R"));
                        this.transform.localPosition = Vector3.zero;
                        this.transform.localRotation = Quaternion.Euler(-90f, -160f, 70f);
                    }
                    break;

                case (int)ItemType.ITEM_STUNGUN:
                    {
                        this.transform.SetParent(playerTr.Find("Root2/Spine/Chest/r_clavicle/r_shoulder/r_elbow/r_wrist/r_hand"));
                    }
                    break;

                case (int)ItemType.ITEM_INVISI:
                    {
                        this.transform.SetParent(playerTr.Find("Model/EvilbearG/Root_M/Spine1_M/Chest_M/Scapula_R/Shoulder_R/Elbow_R/Wrist_R"));
                        this.transform.localPosition = new Vector3(0f, 0f, 0f);
                    }
                    break;

                case (int)ItemType.ITEM_EXPLOTRAP:
                    {
                        this.transform.SetParent(playerTr.Find("Model/EvilbearG/Root_M/Spine1_M"));
                        this.transform.localPosition = new Vector3(0.02f, -0.1f, 0f);
                        this.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
                    }
                    break;

                case (int)ItemType.ITEM_DUMMYTRAP:          //ToDo 포지션 수정
                    {
                        this.transform.SetParent(playerTr.Find("Model/EvilbearG/Root_M/Spine1_M"));
                        this.transform.position = playerTr.forward;
                    }
                    break;
            }
            ItemManager.Instance.AddItemToInven(this.gameObject);
            getItem = false;
            this.gameObject.SetActive(false);
        }
    }

        
    


}
