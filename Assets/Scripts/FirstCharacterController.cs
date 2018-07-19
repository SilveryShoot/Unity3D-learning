using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCharacterController
{
    GameObject firstCharacter;
    public FirstCharacterController()
    {
        firstCharacter = GameObject.Instantiate(Resources.Load("RigidBodyFPSController", typeof(GameObject))) as GameObject;
    }
    public Transform getTransform()
    {
        return firstCharacter.transform;
    }
}
