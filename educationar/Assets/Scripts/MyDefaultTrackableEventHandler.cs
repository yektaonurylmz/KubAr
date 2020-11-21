using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MyDefaultTrackableEventHandler : DefaultTrackableEventHandler
{

    public GameObject TerrainGameObject;

    protected override void OnTrackingFound() {
        base.OnTrackingFound();
        TerrainGameObject.SetActive(true);


    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();
        TerrainGameObject.SetActive(false);
    }


}
