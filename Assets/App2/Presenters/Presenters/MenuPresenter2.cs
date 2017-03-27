using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Karma;
using System;
using Karma.Metadata;
using Zenject;

[Presenter(view)]
public class MenuPresenter2 : MVCPresenter {

    public const string view = "menu2";

    public IRouter router { get; private set; }

    [Inject]
    public void PostConstructor(IRouter router)
    {
        this.router = router;
    }

    public void GoToCubeCounterView()
    {
        router.GoTo(StagePresenter.view);
    }

    public override void OnPresenterDestroy()
    {

    }

}
