using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    private GameObject npc;
    private Rigidbody npcRd;
    private GameObject player;
    public ChaseState(GameObject npc, GameObject player)
    {
        stateID = StateID.Chase;
        this.npc = npc;
        this.player = player;
        npcRd = npc.GetComponent<Rigidbody>();
    }
    public override void DoBeforeEntering()
    {
    }
    public override void DoUpdate()
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) < 5)
        {
            npcRd.velocity = npc.transform.forward * 3;//定义刚体的速度
            Vector3 target = player.transform.position;
            target.y = npc.transform.position.y;
            npc.transform.LookAt(target);
        }
        else
        {
            fsm.PerformTransition(Transition.LostPlayer);
        }
    }
}
