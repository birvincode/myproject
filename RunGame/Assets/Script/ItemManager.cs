using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoSingleton<ItemManager>
{
    public Transform itemFolder;       // 아이템 담아둘 빈 오브젝트

    GameObject cloneItem;
    public List<GameObject> list_Item;

    public GameObject item1;       // 인벤토리의 1번 아이템
    public GameObject item2;       // 인벤토리의 2번 아이템

    public bool select1 = false;
    public bool select2 = false;


    void Awake()
    {
        itemFolder = new GameObject("Item").GetComponent<Transform>();

        list_Item = new List<GameObject>();

        GameObject[] go = Resources.LoadAll<GameObject>("Prefabs/Items");      // 아이템 프리펩 로드


        // 클론 생성하고 아이템 리스트에 Add
        for (int i = 0; i < (int)ItemType.ITEM_MAX; i++)
        {
            cloneItem = Instantiate(go[i]);
            cloneItem.SetActive(false);
            cloneItem.transform.SetParent(itemFolder);
            list_Item.Add(cloneItem);
        }
	}


    void Update()
    {
        ShowInven();
        SelectItem();
        Debug.Log(select1 + "  /  " + select2);
    }

    // 아이템을 인벤토리에 넣는 매소드
    public void AddItemToInven(GameObject _go)
    {
        if (item1 == null)
        {
            item1 = _go;
        }
        else if (item2 == null)
        {
            item2 = _go;
        }
    }

    // TestCode(아이템 목록 디버깅하는 매소드)
    void ShowInven()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            Debug.Log("item1 : " + item1 + "  /  " + "item2 : " + item2);
    }

    // 아이템 선택하는 매소드
    void SelectItem()
    {
        if (Input.GetKeyDown(KeyCode.F1) && item1 != null)
        {
            Debug.Log("1번 아이템 선택");
            item1.SetActive(!select1);

            select1 = !select1;
        }

        if (Input.GetKeyDown(KeyCode.F2) && item2 != null)
        {
            Debug.Log("2번 아이템 선택");
            item2.SetActive(!select2);

            select2 = !select2;
        }
    }

    // 아이템 사용 끝나면 버리는 매소드
    public void DiscardItem(GameObject _go)
    {
        if (ItemManager.Instance.item1 ==_go)
        {
            select1 = !select1;

            item1 = null;
        }
        else if (ItemManager.Instance.item2 == _go)
        {
            select2 = !select2;

            item2 = null;
        }
    }
}
