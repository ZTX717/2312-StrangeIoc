using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;
//1.挂载
public class Demo : ContextView
{
    private void Awake()
    {
        //绑定
        this.context = new DemoContext(this);
        //context.Start();//启动 StrangeIoc框架
    }
}
