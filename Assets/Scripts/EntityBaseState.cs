using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity
{
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void SwitchState();
    public abstract void InitSubState();
}
