using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwaitState : FSMState
{
    public AwaitState()
    {
        stateID = StateID.Await;
    }
    public override void DoBeforeEntering()
    {
    }
    public override void DoBeforeLeaving()
    {
        num = 0;
    }
    float num;
    public override void DoUpdate()
    {
        num += Time.deltaTime;
        if(num >= 1.5)
        {
            fsm.PerformTransition(Transition.LostPlayer);
        }
    }
}
