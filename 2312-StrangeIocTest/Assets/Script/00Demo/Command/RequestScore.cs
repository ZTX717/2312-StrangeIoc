using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScore : EventCommand
{
    [Inject]
    public IScoreService score { get; set; }
    [Inject]
    public ScoreModel scoreModel { get; set; }

    public override void Execute()
    {
        Retain();//表示当前方法先不销毁
        score.dispatcher.AddListener(DemoServiceEvent.RequestScore, OnComplete);
        score.RequestScore("http://xxx/xx");
    }
    public void OnComplete(IEvent evt)
    {
        scoreModel.Score = (int)evt.data;
        dispatcher.Dispatch(DemoMediatorEvent.ScoreChange, evt.data);
        score. dispatcher.RemoveListener(DemoServiceEvent.RequestScore, OnComplete);
        Release();//销毁当前对象
    }
}
