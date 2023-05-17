using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("States")]
    #region States
    [SerializeField]
    private EntityState currentState;
    [SerializeField]   
    private IdleState idleState;
    [SerializeField]
    private FollowState followState;
    public EntityState CurrentState
    {
        get{return currentState;}
        set{currentState = value;}
    }


    public IdleState IdleState
    {
        get{return idleState;}
        set{idleState = value;}
    }

    public FollowState FollowState
    {
        get{return followState;}
        set{followState = value;}
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
