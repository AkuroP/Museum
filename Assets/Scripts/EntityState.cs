using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class EntityState : MonoBehaviour
{
    Entity _entity;

    public abstract void EnterState(Entity entity);
    public abstract void UpdateState(Entity entity);
    public abstract void ExitState(Entity entity);
}
