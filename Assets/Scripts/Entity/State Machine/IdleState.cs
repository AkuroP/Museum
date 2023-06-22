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
    private float restartFollowDistance;

    private float timeChangeState;

    [SerializeField]
    private float timer = 0f;

    [SerializeField]
    private float speed = 2f;
    public override void EnterState(Entity state)
    {
        //Debug.Log("Enter Idle State");
        if(state.agent != null && state.agent.enabled)state.agent.isStopped = false;
        entityRenderer = state.GetComponentInChildren<MeshRenderer>();
        timeChangeState = Random.Range(0, maxTimeChangeState);
    }

    public override void UpdateState(Entity state)
    {
        LookAtPlayer(state.Player.transform.position);
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
        
        if (Vector3.Distance(this.transform.position, state.Player.transform.position) > restartFollowDistance + state.agent.stoppingDistance)
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

    private void LookAtPlayer(Vector3 playerPos)
    {
        /*Vector3 targetDir = playerPos - this.transform.position;
        targetDir.y = 0;
        Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetDir, speed * Time.deltaTime, 0f);
        this.transform.rotation = Quaternion.LookRotation(newDir);*/

        Quaternion quat = Quaternion.LookRotation(playerPos - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, quat, speed * Time.deltaTime);
    }

    public override void ExitState(Entity state)
    {
        //Debug.Log("Exit Idle State");
    }
}
