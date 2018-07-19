using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Camera cam;
    private FirstSceneController sceneController;
    LayerMask layerMask;
    public GameObject muzzleFlash;
    bool muzzleFlashEnable = false;
    float muzzleFlashTimer = 0;
    const float muzzleFlashMaxTime = 0.1F;

    void Awake()
    {
        muzzleFlash.SetActive(false);
        layerMask = LayerMask.GetMask("UFO", "Ground");
    }

    void Start()
    {
        cam = Camera.main;
        sceneController = Director.getInstance().sceneController as FirstSceneController;
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.transform.gameObject.layer == 8)
                {
                    UFOController UFOCtrl = hit.transform.GetComponent<FindUFOController>().ctrl;
                    sceneController.UFOIsShot(UFOCtrl);
                }
                else if (hit.transform.gameObject.layer == 9)
                {
                    sceneController.GroundIsShot(hit.point);
                }
            }
            if (muzzleFlashEnable == false)
            {
                muzzleFlashEnable = true;
                muzzleFlash.SetActive(true);
            }
        }


        if (muzzleFlashEnable)
        {
            muzzleFlashTimer += Time.deltaTime;
            if (muzzleFlashTimer >= muzzleFlashMaxTime)
            {
                muzzleFlashEnable = false;
                muzzleFlash.SetActive(false);
                muzzleFlashTimer = 0;
            }
        }
    }
}
