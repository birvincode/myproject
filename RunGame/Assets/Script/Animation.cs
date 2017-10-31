using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoSingleton<Animation>
{
    Animator PlayerAnim;
    Animator EnemyAnim;

    int animationOrder_Player = (int)PlayerAnimation.IDLE;

    //나중에 플레이어스크립트에서 받아올거지만 일단사용함
    bool playerDie = false;
    bool getAnimFin = false;

    void Start ()
    {
        StartCoroutine("GetAnimator");
        //PlayerAnim = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Animator>();
        //EnemyAnim = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Animator>();
    }

    public void SetAnimationOrder(int _selectAnim, bool _order)
    {
        if (!getAnimFin)
            return;

        animationOrder_Player = _selectAnim;

        switch (animationOrder_Player)
        {
            case (int)PlayerAnimation.IDLE:
                {
                    break;
                }
            case (int)PlayerAnimation.RUN:
                {
                    if (!playerDie)
                    {
                        PlayerAnim.SetBool("IsRun", _order);
                    }
                    break;
                }
            case (int)PlayerAnimation.DIE:
                {
                    break;
                }
        }
    }

    IEnumerator GetAnimator()
    {

        while (true)
        {

                PlayerAnim = GameObject.FindGameObjectWithTag("ANIM").GetComponent<Animator>();
                getAnimFin = true;
                StopCoroutine("GetAnimator");

            yield return new WaitForSeconds(0.1f);
        }
    }
}
