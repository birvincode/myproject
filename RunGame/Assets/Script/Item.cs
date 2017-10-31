using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Transform playerTr;

    public int itemType = 0;

    //protected Enemy enemy;

    protected void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        //enemy = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Enemy>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("PLAYER") && (ItemManager.Instance.item1 == null || ItemManager.Instance.item2 == null))
        {
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
                        this.transform.SetParent(playerTr.Find("Model/EvilbearG/Root_M/Spine1_M/Chest_M/Scapula_R/Shoulder_R/Elbow_R/Wrist_R"));
                        this.transform.localPosition = new Vector3(-0.035f, 0.04f, 0.012f);
                        this.transform.localScale = new Vector3(1f, 1f, 1f);
                        this.transform.localRotation = Quaternion.Euler(180f, 180f, 180f);
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
            this.gameObject.SetActive(false);
        }
    }


}
