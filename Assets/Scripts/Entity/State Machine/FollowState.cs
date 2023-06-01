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

    public override void EnterState(Entity state)
    {
        state.Agent.isStopped = false;
        //Debug.Log("Enter Follow State");
    }

    public override void UpdateState(Entity state)
    {
        state.Agent.SetDestination(state.Player.transform.position);
        //a voir avec le mouvement du rb ?
        //currentSpeed = Mathf.Lerp(currentSpeed, state.Agent.speed, currentSpeed * Time.deltaTime);
        
        state.Anim.SetFloat("Speed", state.Agent.velocity.magnitude);

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
        state.Agent.isStopped = true;
        state.Anim.SetFloat("Speed", 0);
        //Debug.Log("Exit Follow State");
    }
}
