using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMediator : EventMediator
{
    [Inject]
    public StartView view { get; set; }

    public override void OnRegister()
    {
        view.Init();
        view.dispatcher.AddListener(DemoMediatorEvent.开始点击, Play1);
        view.dispatcher.AddListener(DemoMediatorEvent.开始游戏, Play2);
    }
    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(DemoMediatorEvent.开始点击, Play1);
        view.dispatcher.RemoveListener(DemoMediatorEvent.开始游戏, Play2);
    }
    void Play1()
    {
        GameModel.Play();
        view.gameObject.SetActive(false);
        dispatcher.Dispatch(DemoMediatorEvent.显示Down);
    }
    void Play2()
    {
        GameModel.Play();
        view.gameObject.SetActive(false);
        dispatcher.Dispatch(DemoMediatorEvent.显示player);
    }
}
