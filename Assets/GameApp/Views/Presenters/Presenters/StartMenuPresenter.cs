using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Karma;
using System;
using Karma.Metadata;
using Zenject;

[Presenter(view)]
public class StartMenuPresenter : MVCPresenter {

    public const string view = "StartMenu";

    public IRouter router { get; private set; }

    [Inject]
    public void PostConstructor(IRouter router)
    {
        this.router = router;
    }

    public void GoToFieldView()
    {
        router.GoTo(FieldPresenter.view);
    }

    public override void OnPresenterDestroy()
    {
      
    }

   
}
