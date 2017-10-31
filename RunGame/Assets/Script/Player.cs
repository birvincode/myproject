using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool _isRoomChanged; 
    public bool isRoomChanged       // 방이 바뀌었다는 신호의 bool값, isRoomChanged 프로퍼티
    {
        get { return _isRoomChanged; }
        set { _isRoomChanged = value; }
    }

    FadeOut fadeOut;


    void Start()
    {
        isRoomChanged = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        List<GameObject> list_LeftDoor = MapGenerator.Instance.list_LeftDoor;           // MapGenerator 클래스에서 Door리스트 받아옴
        List<GameObject> list_RightDoor = MapGenerator.Instance.list_RightDoor;
        List<GameObject> list_UpDoor = MapGenerator.Instance.list_UpDoor;
        List<GameObject> list_DownDoor = MapGenerator.Instance.list_DownDoor;

        if (other.tag.Equals("DOOR"))       // 플레이어와 충돌한게 Door일때
        {
            Debug.Log("Door와 충돌");

            isRoomChanged = true;           // 방이 바뀌었다고 알려줌
            
            // 충돌한 문이 어느쪽 문인지에 따라 Player의 position을 바꿔줌
            if (list_LeftDoor.Contains(other.gameObject))
            {
                int index = list_LeftDoor.IndexOf(other.gameObject);
                this.transform.position = list_RightDoor[index].transform.position + new Vector3(-5f, 0f, 0f);
            }
            
            else if (list_RightDoor.Contains(other.gameObject))
            {
                int index = list_RightDoor.IndexOf(other.gameObject);
                this.transform.position = list_LeftDoor[index].transform.position + new Vector3(5f, 0f, 0f);
            }

            else if (list_UpDoor.Contains(other.gameObject))
            {
                int index = list_UpDoor.IndexOf(other.gameObject);
                this.transform.position = list_DownDoor[index].transform.position + new Vector3(0f, 0f, -5f);
            }

            else if (list_DownDoor.Contains(other.gameObject))
            {
                int index = list_DownDoor.IndexOf(other.gameObject);
                this.transform.position = list_UpDoor[index].transform.position + new Vector3(0f, 0f, 5f);
            }
        }
    }


}
