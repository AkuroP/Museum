using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EntityState
{
    public override void EnterState(Entity state)
    {
        Debug.Log("Enter Idle State");
    }

    public override void UpdateState(Entity state)
    {

    }

    public override void ExitState(Entity state)
    {
        Debug.Log("Exit Idle State");
    }
}
