using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindUFOController : MonoBehaviour {

    public UFOController ctrl;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject g = transform.GetChild(i).gameObject;
            g.AddComponent<FindUFOController>().ctrl = ctrl;
        }
    }

}
