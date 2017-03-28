using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Karma;
using System;
using Karma.Metadata;
using Zenject;

[Element(path)]

public class HeroPresenter : MVCPresenter {

    public const string path = "player";

    public MVCPresenter app { get; private set; }

    [Inject]
    public void PostConstructor(IGameApp app2)
    {
        this.app = (MVCPresenter)app2;

        //RegisterOn(app, B.clearCubes, this.SelfDestroy);
       // RegisterOn(app, B.test, Test);
    }

    public override void OnPresenterDestroy()
    {
       
    }

   
}
