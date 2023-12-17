using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMediator : EventMediator
{
    [Inject]//注入，可以赋值
    public CubeView View { get; set; }
    
    public override void OnRegister()
    {
        View.Init();
        dispatcher.AddListener(DemoMediatorEvent.ScoreChange, OnScoreChange);
        View.dispatcher.AddListener(DemoMediatorEvent.ClickDown,OnClickDown);
        //通过dispatcher 发起请求分数的命令
        dispatcher.Dispatch(DemoCommandEvent.RequestScore);

        dispatcher.AddListener(DemoMediatorEvent.显示Down, Show);
        dispatcher.AddListener(DemoMediatorEvent.关闭Down, Close);
        dispatcher.Dispatch(DemoMediatorEvent.关闭Down);
    }
    public override void OnRemove()
    {
        dispatcher.RemoveListener(DemoMediatorEvent.ScoreChange, OnScoreChange);
        View.dispatcher.RemoveListener(DemoMediatorEvent.ClickDown, OnClickDown);

        dispatcher.AddListener(DemoMediatorEvent.显示Down, Show);
        dispatcher.AddListener(DemoMediatorEvent.关闭Down, Close);
    }
    public void OnScoreChange(IEvent evt)
    {
        View.UpdateScore((int)evt.data);
    }
    public void OnClickDown()
    {
        dispatcher.Dispatch(DemoCommandEvent.UpdateScore);
    }
    void Show()
    {
        View.gameObject.SetActive(true);
    }
    void Close()
    {
        View.gameObject.SetActive(false);
    }
}
