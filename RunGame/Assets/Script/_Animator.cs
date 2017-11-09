using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Animator : MonoBehaviour
{
    Animator animator;
    



    void Start ()
    {
        animator = GetComponent<Animator>();
    }

    void SetAnimator()
    {


        animator.SetInteger("State", (int)AIType.IDLE);

    }


}
