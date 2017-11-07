using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public GameObject belongItem;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Box"))
        {
            other.gameObject.SetActive(false);
            
            GameObject go =  ItemManager.Instance.GachaItem();

            belongItem = go;

            switch (go.tag)
            {
                case "StunGun":
                    {
                        go.transform.SetParent(transform.Find("Root2/Spine/Chest/r_clavicle/r_shoulder/r_elbow/r_wrist/r_hand"));
                        go.transform.localPosition = Vector3.zero;
                        go.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    }
                    break;

                case "Invisi":
                    {
                        go.transform.SetParent(transform.Find("Root2/Spine/Chest/r_clavicle/r_shoulder/r_elbow/r_wrist/r_hand"));
                        go.transform.localPosition = Vector3.zero;
                        go.transform.localRotation = Quaternion.Euler(Vector3.zero);
                        go.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    }
                    break;

                case "ExploTrap":
                    {
                        go.transform.SetParent(transform.Find("Root2/Spine"));
                        go.transform.localPosition = new Vector3(0f, 0f, -0.4f);
                        go.transform.localRotation = Quaternion.Euler(0f, -90f, 90f);
                        go.transform.localScale = new Vector3(3f, 3f, 3f);
                    }
                    break;
            }
        }
    }
}
