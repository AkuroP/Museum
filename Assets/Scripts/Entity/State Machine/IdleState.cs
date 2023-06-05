using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EntityState
{
    private MeshRenderer entityRenderer;
    [SerializeField]
    private bool isAnimal;
    [Range(0, 10)]
    [SerializeField]
    private float maxTimeChangeState;
    [SerializeField]
    private float plusValueRange;

    private float timeChangeState;

    [SerializeField]
    private float timer = 0f;
    public override void EnterState(Entity state)
    {
        //Debug.Log("Enter Idle State");
        if(state.Agent.enabled)state.Agent.isStopped = true;
        entityRenderer = state.GetComponentInChildren<MeshRenderer>();
        timeChangeState = Random.Range(0, maxTimeChangeState);
    }

    public override void UpdateState(Entity state)
    {
        CheckPlayerDistance(state);
        WaitBeforeChangingState(state);
        /*
            - regarde le joueur s'il est visible
        if(entityRenderer.isVisible)this.transform.LookAt(state.Player.transform.position);
        */
    }

    private void CheckPlayerDistance(Entity state)
    {
        if (!state.FollowState.FollowPlayer) return;
        if (Vector3.Distance(this.transform.position, state.Player.transform.position) > (state.Player.NavMeshAgent.radius + state.Agent.stoppingDistance + plusValueRange))
        {
            state.FollowState.FollowTarget = state.Player.transform;
            entityStateMachine.ChangeState(state.FollowState);
        }
    }

    private void WaitBeforeChangingState(Entity state)
    {
        if (!isAnimal) return;
        if(timer >= timeChangeState)
        {
            entityStateMachine.ChangeState(state.WanderState);
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public override void ExitState(Entity state)
    {
        //Debug.Log("Exit Idle State");
    }
}
