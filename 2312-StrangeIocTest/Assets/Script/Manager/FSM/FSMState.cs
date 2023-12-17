using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//转换条件
public enum Transition
{
    NullTransition = 0,
    LookPlayer,//看到主角
    LostPlayer,//看不到主角
    ReachPoint,//等待
}
//状态ID ， 是每个状态的唯一表示，一个状态有一个固定的，不可跟其他状态重复
public enum StateID
{
    NullStateID = 0,
    patrol,//巡逻
    Chase,//追逐
    Await,//等待
}
//抽象类，方便继承，来使用其中的方法，或者重写
public abstract class FSMState
{
    protected StateID stateID;
    public StateID ID
    {
        get { return stateID; }
    }
    //根据条件，找到状态
    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();

    public FSMSystem fsm;
    
    /// <summary>
    /// 向状态机中添加
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="id"></param>
    public void AddTransition( Transition trans, StateID id)
    {
        if(trans == Transition.NullTransition|| id == StateID.NullStateID)
        {
            Debug.LogWarning("当前转换或状态为空");
            return;
        }
        if (map.ContainsKey(trans))
        {
            Debug.LogWarning("当前转换已经存在了");
            return;
        }
        map.Add(trans, id);
    }
    /// <summary>
    /// 从状态机中移除
    /// </summary>
    /// <param name="trans"></param>
    public void DeleteTransition(Transition trans)
    {
        if (map.ContainsKey(trans))
        {
            map.Remove(trans);
        }
        else
        {
            Debug.Log(trans + "状态不存在");
        }
    }
    public StateID GetOutputState(Transition trans)
    {
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }
        return StateID.NullStateID;
    }
    //进入状态前，需要做的事情
    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    public abstract void DoUpdate();//在状态机处于当前状态的时候，会一直调用
}
