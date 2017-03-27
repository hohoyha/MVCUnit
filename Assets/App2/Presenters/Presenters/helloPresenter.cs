using Karma;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Karma.Metadata;

[Presenter(view)]
public class helloPresenter : MVCPresenter
{
    public const string view = "hello";
    public override void OnPresenterDestroy()
    {
       
    }

   
}
