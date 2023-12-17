using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcControl : MonoBehaviour
{
    private FSMSystem fsm;
    private GameObject player;
    public Transform[] waypoints;
    
    //创建状态机，控制其状态
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InitFSM();
    }
   
    private void Update()
    {
        if (GameModel.IsPlay)
            return;
        fsm.CurrentState.DoUpdate();
    }
    /// <summary>
    /// 初始化状态机
    /// </summary>
    void InitFSM()
    {
        fsm = new FSMSystem();

        PatrolState patrolState = new PatrolState(waypoints,gameObject,player);
        patrolState.AddTransition(Transition.LookPlayer, StateID.Chase);
        patrolState.AddTransition(Transition.ReachPoint, StateID.Await);
        AwaitState awaitState = new AwaitState();
        awaitState.AddTransition(Transition.LostPlayer, StateID.Chase);

        ChaseState chaseState = new ChaseState(gameObject,player);
        chaseState.AddTransition(Transition.LostPlayer, StateID.patrol);
       
        fsm.AddState(patrolState);
        fsm.AddState(chaseState);
        fsm.AddState(awaitState);
        //
        fsm.Start(StateID.patrol);
    }
}
