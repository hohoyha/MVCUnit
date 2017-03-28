using Karma.Metadata;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Karma;
using System;
using Zenject;

[Presenter(view)]
public class FieldPresenter : MVCPresenter {

    public const string view = "Field";
    public Transform Origin;

    public DiContainer container { get; private set; }
    public MVCPresenter app { get; private set; }

    [Inject]
    public void PostConstructor(DiContainer container, IGameApp app2)
    {
       
        this.container = container;
        this.app = (MVCPresenter)app2;
        Create();
        /*
        this.controller = controller2;

        controller.PostConstructor(this);

        RegisterOn(app, C.test, Test);

        RegisterOn(app, B.test, sample);
        */
    }

    public void Create()
    {
        //print("Creating cube");

         var player = container.Resolve<HeroPresenter>();
         //player.gameObject.AddComponent<PlayerController>();


         player.ResetTransformUnder(Origin);

        container.Resolve<CameraPresenter>();

      //  controller.UpdateNum(1);
    }

    public override void OnPresenterDestroy()
    {
        
    }



}
