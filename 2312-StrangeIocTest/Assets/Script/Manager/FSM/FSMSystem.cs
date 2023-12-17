using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 状态管理类，有限状态类
/// </summary>
public class FSMSystem 
{
    private Dictionary<StateID, FSMState> states;
    //当前状态
    private FSMState currentState;
    public FSMState CurrentState
    { 
        get { return currentState; }
    }
    public FSMSystem()
    {
        states = new Dictionary<StateID, FSMState>();
    }
    public void AddState(FSMState state)
    {
        if(state == null)
        {
            Debug.LogWarning("当前状态是空");
        }
        else if (states.ContainsKey(state.ID))
        {
            Debug.LogWarning("存在当前状态");
        }
        else
        {
            state.fsm = this;
            states.Add(state.ID, state);
        }
    }
    public void DeleteState(FSMState state)
    {
        if (state == null)
        {
            Debug.LogWarning("当前状态是空");
        }
        else if (states.ContainsKey(state.ID))
        {
            states.Remove(state.ID);
        }
        else
        {
            Debug.LogWarning("不存在当前状态");
        }
    }
    public void PerformTransition(Transition trans)
    {
        if(trans == Transition.NullTransition)
        {
            Debug.Log("空条件不能用来转换");
        }
        StateID id = CurrentState.GetOutputState(trans);
        if (id == StateID.NullStateID)
        {
            Debug.Log("转换不会发生，没有符合条件的");
            return;
        }
        FSMState state;
        states.TryGetValue(id, out state);
        currentState.DoBeforeLeaving();
        currentState = state;
        currentState.DoBeforeEntering();
    }

    public void Start(StateID id)
    {
        FSMState state;
        var isGet = states.TryGetValue(id, out state);
        if (isGet)
        {
            state.DoBeforeEntering();
            currentState = state;
        }
        else
        {
            Debug.LogWarning("不包含这个状态:"+id+",请检查");
        }
    }
}
