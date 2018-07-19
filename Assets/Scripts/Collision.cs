using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    private FirstSceneController firstSceneController;

    private void Awake()
    {
        firstSceneController = Director.getInstance().sceneController as FirstSceneController;
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.transform.tag == "UFO")
        {
            firstSceneController.UFOHitGround(collision.gameObject.GetComponent<FindUFOController>().ctrl);
        }
    }
}
