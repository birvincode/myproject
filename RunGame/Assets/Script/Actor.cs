using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public GameObject invenItem; // Actor가 가지고 있는 아이템

    Item item;
    BaseAI baseAI;

	void Start ()
    {

    }
	
	void Update ()
    {
        ClearInven();
	}

    // 박스와 충돌시 아이템 먹기
    private void OnTriggerEnter(Collider other)
    {
        if (invenItem == null && other.tag.Equals("Box"))
        {
            ItemManager.Instance.list_Box.Remove(other.gameObject);
            other.gameObject.SetActive(false);

            invenItem = ItemManager.Instance.GachaItem();
            item = invenItem.GetComponent<Item>();

            switch (invenItem.tag)
            {
                case "StunGun":
                    {
                        invenItem.transform.SetParent(transform.Find("Root2/Spine/Chest/r_clavicle/r_shoulder/r_elbow/r_wrist/r_hand"));
                        invenItem.transform.localPosition = Vector3.zero;
                        invenItem.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    }
                    break;

                case "Invisi":
                    {
                        invenItem.transform.SetParent(transform.Find("Root2/Spine/Chest/r_clavicle/r_shoulder/r_elbow/r_wrist/r_hand"));
                        invenItem.transform.localPosition = Vector3.zero;
                        invenItem.transform.localRotation = Quaternion.Euler(Vector3.zero);
                        invenItem.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    }
                    break;

                case "ExploTrap":
                    {
                        invenItem.transform.SetParent(transform.Find("Root2/Spine"));
                        invenItem.transform.localPosition = new Vector3(0f, 0f, -0.4f);
                        invenItem.transform.localRotation = Quaternion.Euler(0f, -90f, 90f);
                        invenItem.transform.localScale = new Vector3(3f, 3f, 3f);
                    }
                    break;
            }
            Debug.Log(invenItem);

        }
    }
    
    void ClearInven()
    {
        if(item != null && item.isItemUsed)
        {
            invenItem = null;
            item.isItemUsed = false;
        }

    }
}
