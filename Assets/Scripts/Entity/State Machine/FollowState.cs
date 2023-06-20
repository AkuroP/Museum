using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : EntityState
{
    [SerializeField]
    private bool followPlayer = false;
    public bool FollowPlayer
    {
        get { return followPlayer; }
        set { followPlayer = value; }
    }
    [SerializeField]
    private Transform followTarget;
    public Transform FollowTarget
    {
        get { return followTarget; } 
        set { followTarget = value; }
    }

    public override void EnterState(Entity state)
    {
        state.agent.isStopped = false;
        //Debug.Log("Enter Follow State");
    }

    public override void UpdateState(Entity state)
    {
        state.agent.SetDestination(followTarget.position);
        //a voir avec le mouvement du rb ?
        //currentSpeed = Mathf.Lerp(currentSpeed, state.Agent.speed, currentSpeed * Time.deltaTime);
        
        state.Anim.SetFloat("Speed", state.agent.velocity.magnitude);

        //Debug.Log("1 : " + Vector3.Distance(this.transform.position, state.Player.transform.position));
        //Debug.Log("2 : " + state.Player.NavMeshAgent.radius + state.Agent.stoppingDistance);

        if (followPlayer && state.agent.remainingDistance <= .5f)
        {
            
            entityStateMachine.ChangeState(state.IdleState);
        }
    }

    public override void ExitState(Entity state)
    {
        state.agent.isStopped = true;
        state.Anim.SetFloat("Speed", 0);
        //Debug.Log("Exit Follow State");
    }
}
