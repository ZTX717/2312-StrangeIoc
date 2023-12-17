using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;

public class DemoContext : MVCSContext
{
    public DemoContext(MonoBehaviour view) : base(view) { }

    protected override void mapBindings()//进行绑定映射
    {
        //manager
        injectionBinder.Bind<AudioManager>().To<AudioManager>().ToSingleton();

        //model
        //在这里绑定后，可以很方便的在框架中访问到，不需要自己去构造
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();

        //serivce
        //ToSingleton 表示在整个工程中只会生成一个
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();

        //command
        commandBinder.Bind(DemoCommandEvent.RequestScore).To<RequestScore>();
        commandBinder.Bind(DemoCommandEvent.UpdateScore).To<UpdateScoreCommand>();
        //mediator
        mediationBinder.Bind<CubeView>().To<CubeMediator>();//完成两个类的绑定
        mediationBinder.Bind<StartView>().To<StartMediator>();
        mediationBinder.Bind<BaseView>().To<BaseMediator>();

        //绑定开始事件，一个  开始命令 （ .onec 只执行一次）
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
