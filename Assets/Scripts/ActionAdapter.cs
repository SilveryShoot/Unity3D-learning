using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAdapter : MonoBehaviour {

    private int mode;
    private FirstSceneActionManager translateManager;
    private PhysicsActionManager physicsManager;

    public void Awake()
    {
        mode = 0;
        translateManager = gameObject.AddComponent<FirstSceneActionManager>();
        physicsManager = gameObject.AddComponent<PhysicsActionManager>();
    }

    public void ChangeMode()
    {
        if (mode == 0)
            mode = 1;
        else
            mode = 0;
    }

    public void AddMovement(GameObject obj, float speed)
    {
        if(mode == 0)
        {
            translateManager.AddMoveToAction(obj, speed);
        }
        else
        {
            physicsManager.AddMoveToAction(obj);
        }
    }

    public void removeMovement(GameObject obj)
    {
        if(mode == 0)
        {
            translateManager.removeActionOf(obj);
        }
        else
        {
            physicsManager.RemoveMoveToAction(obj);
        }
    }
}
