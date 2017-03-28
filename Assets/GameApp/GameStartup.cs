using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Karma;
using System;
using SocketIO;

public class GameStartup : App, IGameApp
{

    private SocketIOComponent socket;

    public override void Configure(IApplication app, DiContainer container)
    {
        container.Bind<IGameApp>().FromInstance(this);
    }

    public override void Init(IRouter router, DiContainer container)
    {
      //  print("go Hello");
        router.GoTo(StartMenuPresenter.view);
        //router.GoTo(MenuPresenter2.view);

      //  GameObject go = GameObject.Find("SocketIO");
       // socket = go.GetComponent<SocketIOComponent>();
    }

    public override void OnPresenterDestroy()
    {

    }


}


public interface IGameApp
{

}