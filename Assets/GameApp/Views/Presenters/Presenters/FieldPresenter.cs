using Karma.Metadata;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Karma;
using System;
using Zenject;

[Presenter(view)]
public class FieldPresenter : MVCPresenter {

    public const string view = "MainGame";
    public Transform Origin;
    public Transform Camera;

    public DiContainer container { get; private set; }
    public MVCPresenter app { get; private set; }
    public IRouter router { get; private set; }

    [Inject]
    public void PostConstructor(DiContainer container, IGameApp app2, IRouter router2)
    {
       
        this.container = container;
        this.app = (MVCPresenter)app2;
        this.router = router2;
        Create();
        /*
        this.controller = controller2;

        controller.PostConstructor(this);

        RegisterOn(app, C.test, Test);

        RegisterOn(app, B.test, sample);
        */
    }

    public void GotoMenu() {
        router.GoTo(StartMenuPresenter.view);
    }

    public void Create()
    {
        //print("Creating cube");

         var player = container.Resolve<HeroPresenter>();
         //player.gameObject.AddComponent<PlayerController>();

         player.ResetTransformUnder(Origin);
         
        var cam =  container.Resolve<CameraPresenter>();
        cam.ResetTransformUnder(Camera);

        cam.gameObject.GetComponent<CameraController>().followTarget = player.gameObject;

        var map = container.Resolve<MapPresenter>();
        map.ResetTransformUnder(Origin);

        GameObject find =  GameObject.Find("StartPosition");

        if(find)
        {
            player.transform.Translate(find.transform.localPosition.x, find.transform.localPosition.y, 0);
        }

        var mon = container.Resolve<MonsterPresenter>();
        mon.ResetTransformUnder(Origin);

        GameObject find2 = GameObject.Find("StartPositionMon");

        if (find2)
        {
            mon.transform.Translate(find2.transform.localPosition.x, find2.transform.localPosition.y, 0);
        }

    }

    public override void OnPresenterDestroy()
    {
        
    }



}
