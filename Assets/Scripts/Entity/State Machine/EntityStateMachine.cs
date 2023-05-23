using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateMachine : MonoBehaviour
{
    private Entity entity;
    // Start is called before the first frame update
    void Start()
    {
        entity = this.GetComponent<Entity>();
    }

    public void ChangeState(EntityState state)
    {
        entity.CurrentState.ExitState(entity);

        entity.CurrentState = state;
        entity.CurrentState.EnterState(entity);
    }
}
