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
        agent = this.GetComponent<NavMeshAgent>();
        IdleState.entityStateMachine = this.GetComponent<EntityStateMachine>();
        FollowState.entityStateMachine = this.GetComponent<EntityStateMachine>();
        WanderState.entityStateMachine = this.GetComponent<EntityStateMachine>();

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
