using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController {
    GameObject UFO;
    FindUFOController ctrl;

    public UFOController(GameObject obj)
    {
        UFO = obj;
        ctrl = obj.AddComponent<FindUFOController>();
        ctrl.ctrl = this; 
    }

    public void appear()
    {
        UFO.SetActive(true);
    }

    public void disappear()
    {
        UFO.SetActive(false);
    }

    public GameObject getUFO()
    {
        return UFO;
    }
}
