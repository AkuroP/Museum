using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mascot : Entity
{
     // Start is called before the first frame update
    void Start()
    {
        //entre en idle state
        CurrentState = IdleState;

        CurrentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    private void ChangeState(EntityState state)
    {
        CurrentState.ExitState(this);

        CurrentState = state;
        CurrentState.EnterState(this);
    }

    public void StateChange(int ui)
    {
        if(ui == 0)ChangeState(IdleState);
        else if(ui == 1)ChangeState(FollowState);
    }
    
}
