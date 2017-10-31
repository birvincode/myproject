using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Shop : MonoBehaviour
{
    GameObject cloneShopObject;     // 상점방에 있을 오브젝트의 클론

    void Start()
    {
        GameObject go =  Resources.Load("Prefabs/Shop/Table") as GameObject;       // 상점에 필요한 리소스 프리팹 로드

        // 클론 생성
        cloneShopObject = Instantiate(go);
        cloneShopObject.transform.position = this.transform.position;

        // 임시의 int값 2개 생성(상점에 들어갈 아이템 2개 고르기 위함)
        int itemIndex1;
        int itemIndex2;

        // 랜덤값 뽑아냄
        do
        {
            itemIndex1 = Random.Range(0, (int)ItemType.ITEM_MAX);
            itemIndex2 = Random.Range(0, (int)ItemType.ITEM_MAX);
        }
        while (itemIndex1 == itemIndex2);     // 두 값이 같으면 다를때 까지 뽑아냄

        // 아이템 2개 활성화 하고 상점위치에 배치함
        ItemManager.Instance.list_Item[itemIndex1].SetActive(true);
        ItemManager.Instance.list_Item[itemIndex1].transform.position = this.transform.position + new Vector3(-1f, 2f, 0f);

        ItemManager.Instance.list_Item[itemIndex2].SetActive(true);
        ItemManager.Instance.list_Item[itemIndex2].transform.position = this.transform.position + new Vector3(1f, 2f, 0f);
    }
}
