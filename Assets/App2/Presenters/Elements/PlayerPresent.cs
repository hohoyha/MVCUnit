using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Karma;
using System;

using Karma.Metadata;
using Zenject;
using UnityEngine.EventSystems;

[Element(path)]
public class PlayerPresent : MVCPresenter, IPointerClickHandler
{
    public const string path = "player";

    public MVCPresenter app { get; private set; }
    
   
    [Inject] 
    public void PostConstructor(ICApp app2)
    {
        this.app = (MVCPresenter)app2;

        RegisterOn(app, B.clearCubes, this.SelfDestroy);
        RegisterOn(app, B.test, Test);
    }

    public void Test(object _ = null)
    {
        Destroy(gameObject);
    }
    
    public override void OnPresenterDestroy()
    {

    }

    public void SelfDestroy(object _ = null)
    {
        BroadcastOn(app, B.cubeDestroyed);
        Destroy(gameObject);
    }

 
    public void OnPointerClick(PointerEventData eventData)
    {
        SelfDestroy();
    }
}
