using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsActionManager : MonoBehaviour {

    public void AddMoveToAction(GameObject obj)
    {
        if (obj.GetComponent<Rigidbody>())
        {
            obj.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            obj.AddComponent<Rigidbody>();
            obj.AddComponent<ConstantForce>().force = new Vector3(0, -1, 10);
        }
        
    }

    public void RemoveMoveToAction(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
    }

}
