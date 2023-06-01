using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

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
    [SerializeField]
    private WanderingState wanderState;
    [SerializeField]
    private Animator anim;
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
    public WanderingState WanderState
    {
        get{return wanderState;}
        set{wanderState = value;}
    }
    public Animator Anim
    {
        get{return anim;}
        set{anim = value;}
    }
    #endregion

    #region EntityParameter
    [SerializeField]
    protected Player player;
    protected NavMeshAgent agent;

    public Player Player { get { return player;} set {  player = value;} }
    public NavMeshAgent Agent { get { return agent;} set {  agent = value;} }

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
