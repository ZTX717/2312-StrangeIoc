using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartView : View
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }
    

    private Button play1But;
    private Button play2But;
     

    public void Init()
    {
        play1But = GameObject.Find("开始1").GetComponent<Button>();
        play1But.onClick.AddListener(PlayGame);
        play2But = GameObject.Find("开始2").GetComponent<Button>();
        play2But.onClick.AddListener(PlayDown);
    }

    void Update()
    {
        
    }
    void PlayGame()
    {
        dispatcher.Dispatch(DemoMediatorEvent.开始点击);
    }
    void PlayDown()
    {
        dispatcher.Dispatch(DemoMediatorEvent.开始游戏);
    }

}
