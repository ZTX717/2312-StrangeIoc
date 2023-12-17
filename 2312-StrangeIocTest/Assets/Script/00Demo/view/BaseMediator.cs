using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMediator : EventMediator
{
    [Inject]
    public BaseView View { set; get; }
    public override void OnRegister()
    {
        dispatcher.AddListener(DemoMediatorEvent.显示player, Show);
        dispatcher.AddListener(DemoMediatorEvent.关闭player, Close);
        dispatcher.Dispatch(DemoMediatorEvent.关闭player);
    }
    public override void OnRemove()
    {
        dispatcher.RemoveListener(DemoMediatorEvent.显示player, Show);
        dispatcher.RemoveListener(DemoMediatorEvent.关闭player, Close);
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
