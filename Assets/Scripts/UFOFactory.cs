using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFactory : System.Object {
    private static UFOFactory instance;
    private static List<UFOController> appear;
    private static Queue<UFOController> disappear;
    public  RuleController ruleController;

    public static UFOFactory getInstance()
    {
        if(instance == null)
        {
            instance = new UFOFactory();
            appear = new List<UFOController>();
            disappear = new Queue<UFOController>();
        }
        return instance;
    }

    public UFOController CreateUFO()
    {
        UFOController UFO;
        if (disappear.Count == 0)
        {
            GameObject obj = GameObject.Instantiate(Resources.Load("UFO", typeof(GameObject))) as GameObject;
            UFO = new UFOController(obj);
        }
        else
        {
            UFO = disappear.Dequeue();
        }
        SetAttribute(UFO.getUFO());
        appear.Add(UFO);
        UFO.appear();
        return UFO;
    }

    public void ReuseUFO(UFOController ctrl)
    {
        appear.Remove(ctrl);
        disappear.Enqueue(ctrl);
        ctrl.disappear();
    }

    private void SetAttribute(GameObject obj)
    {
        obj.transform.localScale = obj.transform.localScale * ruleController.GetScale();
        obj.GetComponent<Renderer>().material.color = ruleController.GetColor();
    }
}
