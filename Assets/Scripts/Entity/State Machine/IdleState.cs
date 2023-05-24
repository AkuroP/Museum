using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EntityState
{
    private MeshRenderer entityRenderer;
    public override void EnterState(Entity state)
    {
        //Debug.Log("Enter Idle State");
        entityRenderer = state.GetComponentInChildren<MeshRenderer>();
    }

    public override void UpdateState(Entity state)
    {
        if(Vector3.Distance(this.transform.position, state.Player.transform.position) > (state.Player.NavMeshAgent.radius + state.Agent.stoppingDistance))
        {
            entityStateMachine.ChangeState(state.FollowState);
        }
        /*
            - regarde le joueur s'il est visible
        if(entityRenderer.isVisible)this.transform.LookAt(state.Player.transform.position);
        */
    }

    public override void ExitState(Entity state)
    {
        //Debug.Log("Exit Idle State");
    }
}
