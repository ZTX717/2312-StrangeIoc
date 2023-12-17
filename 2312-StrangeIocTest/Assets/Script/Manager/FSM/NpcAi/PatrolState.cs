using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{

    public Transform[] waypoints;
    private GameObject npc;
    private Rigidbody npcRd;
    private GameObject player;
    private int targetWaypoint;
    public PatrolState( Transform[] points,GameObject npc,GameObject player)
    {
        stateID = StateID.patrol;
        waypoints = points;
        this.npc = npc;
        this.player = player;
        npcRd = npc.GetComponent<Rigidbody>();
        targetWaypoint = 0;
    }

    public override void DoBeforeEntering()
    {
    }

    public override void DoUpdate()
    {
        CheckTransition();
        patrolMove();
    }

    private void CheckTransition()
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) < 5) 
        {
            fsm.PerformTransition(Transition.LookPlayer);
        }
    }

    private void patrolMove()
    {
        npcRd.velocity = npc.transform.forward * 3;//定义刚体的速度
        Transform targetTrans = waypoints[targetWaypoint];//获得到目标组件
        Vector3 targetPosition = targetTrans.position;//目标位置
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);
        if (Vector3.Distance(npc.transform.position, targetPosition) < 0.1f)
        {
            targetWaypoint++;
            targetWaypoint %= waypoints.Length;
            fsm.PerformTransition(Transition.ReachPoint);
        }
    }
}
