using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

 
public class MapGenerator : MonoSingleton<MapGenerator>
{
    Transform roomFolder;   // Room과 Door 담아둘 빈 오브젝트
 
    int currStage;          // 현재 스테이지 
    Vector2 StageSize;      // 스테이지별 맵 사이즈(가로, 세로) 

    float gapBetweenRoom = 100f;   // 방 사이의 갭(거리)
   
    // Room List
    public List<GameObject> list_RoomBattle;

    public GameObject cloneRoomStart;
    public GameObject cloneRoomBattle;
    public GameObject cloneRoomShop;
    public GameObject cloneRoomEvent;
    public GameObject cloneRoomExit;

    // TODO: Stage가 바뀐'시점'에 false로 꼭 복귀!!
    bool FinCreateMap = false;

    public List<GameObject> list_LeftDoor;     // 왼쪽 Door List
    public List<GameObject> list_RightDoor;    // 오른쪽 Door List
    public List<GameObject> list_UpDoor;       // 위쪽 Door List
    public List<GameObject> list_DownDoor;     // 아래쪽 Door List


    
    void Awake()
    {
        roomFolder = new GameObject("Room_Door").GetComponent<Transform>();

        // 리스트 동적 할당
        list_LeftDoor = new List<GameObject>();
        list_RightDoor = new List<GameObject>();
        list_UpDoor = new List<GameObject>();
        list_DownDoor = new List<GameObject>();

        list_RoomBattle = new List<GameObject>();
        


        currStage = StageManager.Instance.GetCurrStage();           // StageManager 클래스에서 현재 스테이지 정보 받아옴 
        StageSize = StageData.Instance.GetStageSize(currStage);     // StageData 클래스에서 현재 스테이지 사이즈 받아옴 


        CreateMap();
        FinCreateMap = true;
    } 

    void CreateMap()            // 맵 만드는 메소드 
    {
        GameObject cloneDoor;           // 문 클론

        GameObject go;          // 임시 게임오브젝트 


        int shopIndex;
        int EventIndex;

        do
        {
            shopIndex = Random.Range(1, (int)(StageSize.x * StageSize.y - 1));       // 상점방을 할당할 랜덤 인덱스값 하나 생성
            EventIndex = Random.Range(1, (int)(StageSize.x * StageSize.y - 1));       // 이벤트방을 할당할 랜덤 인덱스값 하나 생성
        }
        while (shopIndex == EventIndex);            // 이벤트방 인덱스가 상점방 인덱스와 같으면 다를때까지 다시 생성




        int count = -1;  // for문 카운트 할 int 하나 생성


        go = Resources.Load("Prefabs/Rooms/Room_TypeBattle") as GameObject; // 배틀방 오브젝트 로드

        // 클론 생성 후 list_Room에 Add

        if(currStage != 1)      // 현재 스테이지가 1이 아니면(일단 주석)
        {
            for (int i = 0; i < (int)StageSize.x; i++)
            {
                for (int j = 0; j < (int)StageSize.y; j++)
                {
                    count++;

                    // count가 0(시작점)이거나 shopIndex거나 마지막 인덱스(출구가 들어갈 잍덱스)면 continue
                    if (count == 0 || (currStage != 1 && count == shopIndex) || count == EventIndex || count == StageSize.x * StageSize.y - 1)
                        continue;

                    cloneRoomBattle = Instantiate(go);
                    cloneRoomBattle.transform.position = new Vector3(i * gapBetweenRoom, 0f, -j * gapBetweenRoom);
                    cloneRoomBattle.transform.SetParent(roomFolder);

                    list_RoomBattle.Add(cloneRoomBattle);
                }
            }
        }

        go = Resources.Load("Prefabs/Rooms/Room_TypeStart") as GameObject;

        cloneRoomStart = Instantiate(go);
        cloneRoomStart.transform.position = Vector3.zero;
        cloneRoomStart.transform.SetParent(roomFolder);

        if (currStage != 1)
        {
            go = Resources.Load("Prefabs/Rooms/Room_TypeShop") as GameObject; // 상점방 오브젝트 로드

            cloneRoomShop = Instantiate(go);
            cloneRoomShop.transform.position = new Vector3((int)(shopIndex / StageSize.x) * gapBetweenRoom, 0f, -(int)(shopIndex % StageSize.x) * gapBetweenRoom);
            cloneRoomShop.transform.SetParent(roomFolder);
        }



        go = Resources.Load("Prefabs/Rooms/Room_TypeEvent") as GameObject; // 이벤트방 오브젝트 로드

        cloneRoomEvent = Instantiate(go);
        cloneRoomEvent.transform.position = new Vector3((int)(EventIndex / StageSize.x) * gapBetweenRoom, 0f, -(int)(EventIndex % StageSize.x) * gapBetweenRoom);
        cloneRoomEvent.transform.SetParent(roomFolder);



        go = Resources.Load("Prefabs/Rooms/Room_TypeExit") as GameObject; // 이벤트방 오브젝트 로드

        cloneRoomExit = Instantiate(go);
        cloneRoomExit.transform.position = new Vector3((StageSize.x - 1) * gapBetweenRoom, 0f, -(StageSize.y - 1) * gapBetweenRoom);
        cloneRoomExit.transform.SetParent(roomFolder);






        go = Resources.Load("Prefabs/Rooms/Door") as GameObject; // Room 오브젝트 로드

        // RightDoor
        for (int i = 0; i < StageSize.x - 1; i++)
        {
            for (int j = 0; j < StageSize.y; j++)
            {
                cloneDoor = Instantiate(go);
                cloneDoor.transform.position = new Vector3(i * gapBetweenRoom + 37.5f, 0.1f, -j * gapBetweenRoom);
                cloneDoor.transform.SetParent(roomFolder);

                list_RightDoor.Add(cloneDoor);
            }
        }

        // LeftDoor
        for (int i = 0; i < StageSize.x - 1; i++)
        {
            for (int j = 0; j < StageSize.y; j++)
            {
                cloneDoor = Instantiate(go);
                cloneDoor.transform.position = new Vector3((i + 1) * gapBetweenRoom - 37.5f, 0.1f, -j * gapBetweenRoom);
                cloneDoor.transform.SetParent(roomFolder);

                list_LeftDoor.Add(cloneDoor);
            }
        }

        // UpDoor
        for (int i = 0; i < StageSize.x; i++)
        {
            for (int j = 0; j < StageSize.y - 1; j++)
            {
                cloneDoor = Instantiate(go);
                cloneDoor.transform.position = new Vector3(i * gapBetweenRoom, 0.1f, -j * gapBetweenRoom - 37.5f);
                cloneDoor.transform.SetParent(roomFolder);

                list_UpDoor.Add(cloneDoor);
            }
        }

        // DownDoor
        for (int i = 0; i < StageSize.x; i++)
        {
            for (int j = 0; j < StageSize.y - 1; j++)
            {
                cloneDoor = Instantiate(go);
                cloneDoor.transform.position = new Vector3(i * gapBetweenRoom, 0.1f, -(j + 1) * gapBetweenRoom + 37.5f);
                cloneDoor.transform.SetParent(roomFolder);

                list_DownDoor.Add(cloneDoor);
            }
        }
    }

    /* Pseudo Code
     * 
     * Plane 오브젝트를 2차원 배열로 만든다(int)
     * 빈공간 0, Road 1, Plane 2
     * [i][j] i, j 가 홀수인 인덱스에는 0을 넣음(Road도 아니고 Plane도 아니고 막힌길도 아니고 아무것도 없음)
     * 
     * 3 x 3의 경우
     * 
     * 2 1 1 2 1 1 2
     * 1 0 0 1 0 0 1
     * 1 0 0 1 0 0 1
     * 2 1 1 2 1 1 2
     * 1 0 0 1 0 0 1
     * 1 0 0 1 0 0 1
     * 2 1 1 2 1 1 2
     * 
     * 4 x 4의 경우
     * 
     * 2 1 1 2 1 1 2 1 1 2
     * 1 0 0 1 0 0 1 0 0 1
     * 1 0 0 1 0 0 1 0 0 1
     * 2 1 1 2 1 1 2 1 1 2
     * 1 0 0 1 0 0 1 0 0 1
     * 1 0 0 1 0 0 1 0 0 1
     * 2 1 1 2 1 1 2 1 1 2
     * 1 0 0 1 0 0 1 0 0 1
     * 1 0 0 1 0 0 1 0 0 1
     * 2 1 1 2 1 1 2 1 1 2
     * 
     * 
     * 
     * 여기서 Road가 없는 인덱스에는 1대신 0을 넣는다
     * Road 배치가 끝나면 무인도 검사시작
     * 
     * 
     */



    public List<GameObject> GetList_RoomBattle()
    {
        return list_RoomBattle;
    }   

    public bool GetFinCreateMap()
    {
        return FinCreateMap;
    }
}
