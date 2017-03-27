using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Karma;
using System;
using SocketIO;

public class Startup2 : App , ICApp
{

    private SocketIOComponent socket;

    public override void Configure(IApplication app, DiContainer container)
    {
        container.Bind<ICApp>().FromInstance(this);
    }

    public override void Init(IRouter router, DiContainer container)
    {
        print("go Hello");
        router.GoTo(MenuPresenter2.view);

        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
    }

    public override void OnPresenterDestroy()
    {
        
    }

  
}


public interface IApp
{

}