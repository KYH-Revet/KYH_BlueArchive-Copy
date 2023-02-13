using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPosTest : MonoBehaviour
{
    enum State
    { 
        IDLE,
        SHOOT
    }
    State state= State.IDLE;

    Animator animator;
    public Transform gun;
    Transform originTr;

    void Start()
    {
        animator = GetComponent<Animator>();
        originTr = gun.transform;
        StateChanger();
    }

    private void Update()
    {
        if(animator != null)
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                state = state == State.IDLE ? State.SHOOT : State.IDLE;
                animator.SetInteger("STATE", (int)state);
                StateChanger();
            }
        }
        
    }

    void StateChanger()
    {
        Vector3 pos = originTr.localPosition;
        Vector3 rot = originTr.localRotation.eulerAngles;
        switch (state)
        {
            case State.IDLE:
                pos = new Vector3(-0.1f, 0, 0.02f);
                rot = new Vector3(-4, 88, 90);
                break;
            case State.SHOOT:
                pos = new Vector3(-0.06f, -0.02f, -0.06f);
                rot = new Vector3(-10, 60, 90);
                break;
        }
        gun.transform.localRotation = Quaternion.Euler(rot);
        gun.transform.localPosition = pos;
    }
}
