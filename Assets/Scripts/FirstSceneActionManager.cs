using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstSceneActionManager : ActionManager
{
    public void AddMoveToAction(GameObject obj, float speed)
    {
        Vector3 right = Vector3.forward;

        MoveToAction action1 = MoveToAction.getAction(right, speed);

        addAction(obj, action1, this);
    }
}
