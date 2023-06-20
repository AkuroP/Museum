using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class WanderingState : EntityState
{
    private MeshRenderer entityRenderer;

    [Range(0, 5)]
    [SerializeField]
    private float timeBtweenWandering;
    [SerializeField]
    private float timer = 0f;
    [SerializeField]
    private float entityRange;
   
    [SerializeField]
    private Transform wanderZone;
    public override void EnterState(Entity state)
    {
        //Debug.Log("Enter Idle State");
        state.agent.enabled = true;

        entityRenderer = state.GetComponentInChildren<MeshRenderer>();
        state.agent.isStopped = false;
        Vector3 newPos = RandomNavSphere(wanderZone.position, entityRange, -1);
        state.agent.SetDestination(newPos);
    }

    public override void UpdateState(Entity state)
    {
        if(timer >= timeBtweenWandering)
        {
            entityStateMachine.ChangeState(state.IdleState);
            timer = 0f;
        }
        else
        {
            if(state.Anim != null) state.Anim.SetFloat("Speed", state.agent.speed);
            timer += Time.deltaTime;

        }
    }

    public override void ExitState(Entity state)
    {
        state.agent.isStopped = true;
        state.agent.enabled = false;
        //Debug.Log(state.Agent.destination);
        //Debug.Log("Exit Idle State");
    }


    private Vector3 RandomNavSphere(Vector3 origin, float distance, int layerMask)
    {
        Vector3 randomDir = Random.insideUnitCircle * distance;
        randomDir += origin;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDir, out hit, distance, layerMask);

        return hit.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(wanderZone.position, entityRange);
    }
}
