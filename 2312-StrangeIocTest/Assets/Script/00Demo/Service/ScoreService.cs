using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreService : IScoreService
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void OnReceiveScore()
    {
        int score = Random.Range(0, 100);
        dispatcher.Dispatch(DemoServiceEvent.RequestScore,score);
    }

    public void RequestScore(string url)
    {
        OnReceiveScore();
    }

    public void UpdateScore(string url, int score)
    {
    }

}
