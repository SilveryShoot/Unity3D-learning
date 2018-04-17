using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class Ufo
    {
        private GameObject disk;
        public string id;
        private Vector3 size;
        private Color color;
        private float speed;
        private Vector3 direction;
       
        public void load()
        {
            disk = Object.Instantiate(Resources.Load("Prefabs/disk",typeof(GameObject)), Vector3.zero, Quaternion.identity,null) as GameObject;
            disk.SetActive(false);
        }

        public void setColor(Color tcolor)
        {
            color = tcolor;
            disk.GetComponent<Renderer>().material.color = tcolor;
        }

        public void setSpeed(float tspeed)
        {
            speed = tspeed;
        }

        public void setDirection(Vector3 tdirect)
        {
            direction = tdirect;
        }

        public void setPosition(Vector3 positon)
        {
            disk.transform.position = positon;
        }

        public Vector3 getDirection()
        {
            return direction;
        }

        public GameObject getGameObj()
        {
            return disk;
        }

        public void activation()
        {
            disk.SetActive(true);
        }

        public void setId()
        {
            id = disk.GetInstanceID().ToString();
        }

        public void inactivated()
        {
            disk.SetActive(false);
        }

        public Color getColor()
        {
            return color;
        }
    }
}
