using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Karma;
using System;
using Karma.Metadata;

[Controller]
public class StageController : IController
{
    public StagePresenter presenter { get; private set; }
    private int total = 0;

    public void PostConstructor(StagePresenter presenter)
    {
        this.presenter = presenter;
    }

    public void UpdateNum(int delta)
    {
        if(delta != -999)
        {
            total += delta;
        }
        else
        {
            total = 0;
        }
       
        presenter.SetCount(total);
    }

    public void OnDestroy()
    {
        
    }

}

