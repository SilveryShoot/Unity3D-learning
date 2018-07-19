using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAction : ObjAction {

    public Vector3 target;
    public float speed;
    

    private MoveToAction() { }
    public static MoveToAction getAction(Vector3 target, float speed = 5F)
    {
        MoveToAction action = ScriptableObject.CreateInstance<MoveToAction>();
        action.target = target;
        action.speed = speed;
        return action;
    }

    public override void Update()
    {
        this.transform.position += target * Time.deltaTime * speed;
        if (this.transform.position == target)
        {
            this.destroy = true;
            this.whoToNotify.actionDone(this);
        }
    }

    public override void Start()
    {
        //
    }
}
