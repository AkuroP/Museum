using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : EntityState
{
    public override void EnterState(Entity state)
    {
        Debug.Log("Enter Follow State");
    }

    public override void UpdateState(Entity state)
    {
        state.Agent.SetDestination(state.Player.transform.position);
        //Debug.Log("1 : " + Vector3.Distance(this.transform.position, state.Player.transform.position));
        //Debug.Log("2 : " + state.Player.NavMeshAgent.radius + state.Agent.stoppingDistance);
        if (Vector3.Distance(this.transform.position, state.Player.transform.position) <= (state.Player.NavMeshAgent.radius + state.Agent.stoppingDistance))
        {
            Debug.Log("STPOP");
            entityStateMachine.ChangeState(state.IdleState);
        }
    }

    public override void ExitState(Entity state)
    {
        Debug.Log("Exit Follow State");
    }
}
