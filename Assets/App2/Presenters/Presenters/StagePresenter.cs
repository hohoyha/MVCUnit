using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Karma;
using Karma.Metadata;
using System;
using Zenject;
using UnityEngine.UI;

[Presenter(view)]

public class StagePresenter : MVCPresenter {

    public const string view = "stage";
    public Transform cubeOrigin;
    public Text numberOfCubes;

    public DiContainer container { get; private set; }
    public MVCPresenter app { get; private set; }
    public StageController controller { get; private set; }

    [Inject]
    public void PostConstructor( DiContainer container, ICApp app2, StageController controller2)
    {
        this.container = container;
        this.app = (MVCPresenter)app2;
        this.controller = controller2;

        controller.PostConstructor(this);

        RegisterOn(app, C.test, Test);

        RegisterOn(app, B.test, sample);
    }

    public void Test( object _ = null)
    {
        Debug.Log(C.cubeDestroyed);
    }

    public override void OnPresenterDestroy()
    {
           
    }

    public void CreateCube()
    {
        print("Creating cube");

        var cube = container.Resolve<PlayerPresent>();
        cube.ResetTransformUnder(cubeOrigin);

        controller.UpdateNum(1);
    }


    public void ClearCubes()
    {
        Person test = new Person();
        test.name = "hoho";
        test.pos = new Vector3(20, 10, 8);

        BroadcastOn(app, B.test, test);
        controller.UpdateNum(-999);
    }

    public void sample(object _)
    {
        Debug.Log("Test");

   
        Person ps = (Person)_;

        Debug.Log(ps.name + ": " + ps.pos);
    }

    public void SetCount(int num)
    {
        numberOfCubes.text = "Count:" + num;
    }

    /*
    public void ClearCubes2()
    {
        BroadcastOn(app, B.clearCubes);
    }
    */
}
