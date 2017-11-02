using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoSingleton<ItemManager>
{
    public delegate void delegate_Item();

    public event delegate_Item GetItemProcess;



    Item item;

    public Transform itemFolder;       // 아이템 담아둘 빈 오브젝트

    GameObject cloneItem;
    GameObject cloneBox;
    public List<GameObject> list_Item;

    public GameObject item1;       // 인벤토리의 1번 아이템
    public GameObject item2;       // 인벤토리의 2번 아이템

    GameObject[] checkPoint;

    int BoxCountPerPoint;           // 체크포인트 마다의 박스 개수

    int cloneItemCount;

    public bool getItem = false;

    public bool select1 = false;
    public bool select2 = false;


    void Awake()
    {
        itemFolder = new GameObject("Item").GetComponent<Transform>();      // 하이라키상 아이템폴더 만들기

        list_Item = new List<GameObject>();

        GameObject go = Resources.Load<GameObject>("Prefabs/Box/Box_Square");      // 박스 프리팹 로드

        checkPoint = GameObject.FindGameObjectsWithTag("CheckPoint");

        BoxCountPerPoint = 5;
        cloneItemCount = 10;


        for (int i = 0; i < checkPoint.Length; i++)
        {
            for (int j = 0; j < BoxCountPerPoint; j++)
            {
                cloneBox = Instantiate(go);
                cloneBox.transform.position = checkPoint[i].transform.position + checkPoint[i].transform.right * j * 5f;
                cloneBox.transform.SetParent(itemFolder);       // 하이라키상 아이템폴더에 넣기
            }
        }

        GameObject[] temp_go = Resources.LoadAll<GameObject>("Prefabs/Item");

        //클론 생성하고 아이템 리스트에 Add
        for (int i = 0; i < temp_go.Length; i++)
        {
                cloneItem = Instantiate(temp_go[i]);            // 클론생성
                cloneItem.transform.SetParent(itemFolder);      // 하이라키상 아이템 폴더에 넣기
                list_Item.Add(cloneItem);                       // 리스트에 추가
                cloneItem.SetActive(false);                     // 비활성화
        }
    }

    private void Start()
    {

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
