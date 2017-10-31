using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Vector3 moveDir;
    public Vector3 lookDir;

    public Ray ray;
    public RaycastHit hit;

    float playerSpeed;


    void Start()
    {
        playerSpeed = 15.0f;
    }



    void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * Time.deltaTime * playerSpeed;
        this.transform.position += moveDir;
        
 
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 500f);

        lookDir = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        transform.transform.LookAt(lookDir);
    }
}
