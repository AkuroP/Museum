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
        
    }

    public override void ExitState(Entity state)
    {
        Debug.Log("Exit Follow State");
    }
}
