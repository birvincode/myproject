using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoSingleton<ItemManager>
{


    public Transform itemFolder;       // 아이템 담아둘 빈 오브젝트


    GameObject cloneItem;
    GameObject cloneBox;
    
    GameObject[] checkPoint;

    int BoxCountPerPoint = 5;           // 체크포인트 마다의 박스 개수

    int cloneItemCount = 10;

    Dictionary<int, Queue<GameObject>> dic_Item = new Dictionary<int, Queue<GameObject>>();

    public Queue<GameObject> list_StunGun = new Queue<GameObject>();
    public Queue<GameObject> list_Invisi = new Queue<GameObject>();
    public Queue<GameObject> list_ExploTrap = new Queue<GameObject>();
    public Queue<GameObject> list_DummyTrap = new Queue<GameObject>();


    void Awake()
    {
        itemFolder = new GameObject("Item").GetComponent<Transform>();      // 하이라키상 아이템폴더 만들기

        checkPoint = GameObject.FindGameObjectsWithTag("CheckPoint");

        LoadItemBox();

        LoadItem();
    }


    void LoadItemBox()
    {
        GameObject go = Resources.Load<GameObject>("Prefabs/Box/Box_Square");      // 박스 프리팹 로드

        // 아이템 박스 생성
        for (int i = 0; i < checkPoint.Length; i++)
        {
            for (int j = 0; j < BoxCountPerPoint; j++)
            {
                cloneBox = Instantiate(go);
                cloneBox.transform.position = checkPoint[i].transform.position + checkPoint[i].transform.right * j * 5f;
                cloneBox.transform.SetParent(itemFolder);       // 하이라키상 아이템폴더에 넣기
            }
        }
    }


    void LoadItem()
    {
        dic_Item.Add((int)ItemType.ITEM_STUNGUN, list_StunGun);
        dic_Item.Add((int)ItemType.ITEM_INVISI, list_Invisi);
        dic_Item.Add((int)ItemType.ITEM_DUMMYTRAP, list_DummyTrap);
        dic_Item.Add((int)ItemType.ITEM_EXPLOTRAP, list_ExploTrap);



        GameObject go = Resources.Load<GameObject>("Prefabs/Item/StunGun");

        for (int i = 0; i < cloneItemCount; i++)
        {
            cloneItem = Instantiate(go);
            cloneItem.transform.SetParent(itemFolder);
            dic_Item[(int)ItemType.ITEM_STUNGUN].Enqueue(cloneItem);
            cloneItem.SetActive(false);
        }

        go = Resources.Load<GameObject>("Prefabs/Item/Invisi");

        for (int i = 0; i < cloneItemCount; i++)
        {
            cloneItem = Instantiate(go);
            cloneItem.transform.SetParent(itemFolder);
            dic_Item[(int)ItemType.ITEM_INVISI].Enqueue(cloneItem);
            cloneItem.SetActive(false);
        }

        go = Resources.Load<GameObject>("Prefabs/Item/ExploTrap");

        for (int i = 0; i < cloneItemCount; i++)
        {
            cloneItem = Instantiate(go);
            cloneItem.transform.SetParent(itemFolder);
            dic_Item[(int)ItemType.ITEM_EXPLOTRAP].Enqueue(cloneItem);
            cloneItem.SetActive(false);
        }

        //go = Resources.Load<GameObject>("Prefabs/Item/DummyTrap");

        //for (int i = 0; i < cloneItemCount; i++)
        //{
        //    cloneItem = Instantiate(go);                                                
        //    cloneItem.transform.SetParent(itemFolder);                                  
        //    dic_Item[(int)ItemType.ITEM_DUMMYTRAP].Enqueue(cloneItem);                      
        //    cloneItem.SetActive(false);                                                                         
        //}
    }



    public GameObject GachaItem()
    {
        int temp = Random.Range(0, 3);

        GameObject go =  dic_Item[temp].Dequeue();

        go.SetActive(true);

        return go;
    }
}
