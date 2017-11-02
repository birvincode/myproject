using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") || other.tag.Equals("Enemy"))
        {
            Debug.Log("아이템박스 충돌");

            ItemManager.Instance.getItem = true;

            gameObject.SetActive(false);
        }
    }
}
