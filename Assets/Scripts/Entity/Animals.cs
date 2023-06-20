using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animals : Entity
{
    
     // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        //Debug.Log(player.name);
        if(agent == null)agent = this.GetComponent<NavMeshAgent>();
        if(IdleState != null)IdleState.entityStateMachine = this.GetComponent<EntityStateMachine>();
        if (FollowState != null) FollowState.entityStateMachine = this.GetComponent<EntityStateMachine>();
        if (WanderState != null) WanderState.entityStateMachine = this.GetComponent<EntityStateMachine>();
        Anim = this.GetComponent<Animator>();
        //entre en idle state
        //CurrentState = IdleState;
        CurrentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }
    
}
