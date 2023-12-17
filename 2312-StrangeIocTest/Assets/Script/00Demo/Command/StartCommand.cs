using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//开始命令
public class StartCommand : Command
{
    [Inject]
    public AudioManager audioManager { set; get; }
    //当命令执行的时候，默认会调用Execute方法
    public override void Execute()
    {
        audioManager.Init();
        GameModel.Sotp();
    }
}
