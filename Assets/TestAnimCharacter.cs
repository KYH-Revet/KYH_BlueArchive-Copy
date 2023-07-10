using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAnimCharacter : MonoBehaviour
{
    public enum State
    {
        IDLE,
        MOVE,
        SHOOT,
        RELOAD,
        SKILL,
        DEAD
    }
    public State state;
    State prevState;

    Animator animator;

    //Shoot variables
    float shootDelay = 1f;
    float shootTimer = 1f;

    //Ammo varialbes
    int ammoCur;
    int ammoMax = 10;

    //Unity Function
    void Start()
    {
        //Set State
        state = State.IDLE;
        prevState = state;

        //Delegate
        AddDelegate_State();

        //Get Animator
        animator = GetComponent<Animator>();

        //Set Ammo
        ammoCur = ammoMax;
    }
    void Update()
    {
        StateMachine();
    }

    //State Machine
    void StateMachine()
    {
        //Any state
        anyStateGate();

        switch (state)
        {
            case State.IDLE:
                idleGate();
                break;
            case State.MOVE:
                moveGate();
                break;
            case State.SHOOT:
                shootGate();
                break;
            case State.RELOAD:
                reloadGate();
                break;
            case State.SKILL:
                skillGate();
                break;
            case State.DEAD:
                deadGate();
                break;
        }
    }

    delegate void State_AnyState(); State_Idle anyStateGate;
    delegate void State_Idle();     State_Idle idleGate;
    delegate void State_Move();     State_Move moveGate;
    delegate void State_Shoot();    State_Move shootGate;
    delegate void State_Reload();   State_Move reloadGate;
    delegate void State_Skill();    State_Move skillGate;
    delegate void State_Dead();     State_Move deadGate;

    //Delegate Function
    void AddDelegate_State()
    {
        //Any State
        anyStateGate += Changer_Skill;  //Skill
        anyStateGate += Changer_Dead;   //Dead

        //Idle
        idleGate += Changer_Move;       //Move
        idleGate += Changer_Shoot;      //Shoot

        //Move
        moveGate += Changer_Idle;       //Idle
        moveGate += Changer_Shoot;      //Shoot

        //Shoot
        shootGate += Shooting;          //Shooting Action
        shootGate += Changer_Idle;      //Idle
        shootGate += Changer_Move;      //Move
        shootGate += Changer_Reload;    //Reload

        //Reload
        reloadGate += AnimEnd_Reloading;//Reload animation end 

        //Skill
        skillGate += AnimEnd_Skill;     //Skill animation end 

        //Dead
        deadGate += AnimEnd_Dead;       //Dead animation end
    }

    //State Functions
    void Changer_Idle()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            ChangeState(State.IDLE);
        }
    }
    void Changer_Move()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ChangeState(State.MOVE);
        }
    }
    void Changer_Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ChangeState(State.SHOOT);
        }
    }
    void Changer_Reload()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            ChangeState(State.RELOAD);
            animator.SetTrigger("RELOAD");

            //Reload ammo
            ammoCur = ammoMax;
        }
    }
    void Changer_Skill()
    {
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (state == State.RELOAD)
                state = State.SHOOT;

            if (state != State.DEAD)
            {
                ChangeState(State.SKILL);
                animator.SetTrigger("SKILL");
            }
        }
    }
    void Changer_Dead()
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            ChangeState(State.DEAD);
            animator.SetTrigger("DEAD");
        }
    }

    //Action
    void Shooting()
    {
        //Shooting Gun
        shootTimer += Time.deltaTime;
        if (shootTimer > shootDelay)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    //Check end of animation
    void AnimEnd_Reloading()
    {
        if (AnimationEnd("Reload"))
        {
            ChangeState(prevState);
        }
    }
    void AnimEnd_Skill()
    {
        if (AnimationEnd("Skill"))
        {
            ChangeState(prevState);
        }
    }
    void AnimEnd_Dead()
    {
        if (AnimationEnd("Dead"))
        {
            Invoke("Dead", 3f);
        }
    }

    //State Changer
    void ChangeState(State next)
    {
        //State Machine
        prevState = state;
        state = next;

        //Animator
        animator.SetInteger("STATE", (int)state);
    }

    //Animation Function
    bool AnimationEnd(string name)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(name))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.75f)
            {
                return true;
            }
        }
        return false;
    }

    //Action's Function
    void Shoot()
    {
        ammoCur -= 1;
        Debug.Log("leftAmmo : " + ammoCur);

        if (ammoCur <= 0)
        {
            ammoCur = ammoMax;
            animator.SetTrigger("RELOAD");
            ChangeState(State.RELOAD);
        }
    }
    void Dead()
    {
        Destroy(gameObject);
    }
}
