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
        if (state.Agent.isStopped && Vector3.Distance(this.transform.position, state.Player.transform.position) <= state.Player.NavMeshObstacle.radius)
        {
            entityStateMachine.ChangeState(state.IdleState);
        }
    }

    public override void ExitState(Entity state)
    {
        Debug.Log("Exit Follow State");
    }
}
