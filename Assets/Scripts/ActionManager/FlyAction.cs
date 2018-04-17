using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ActionManager
{
    public class FlyAction : SSAction
    {
        float acceleration;
        float horizontalSpeed;
        Vector3 direction;
        float time;

        public static FlyAction getAction(float ho,Vector3 di)
        {
            FlyAction action = ScriptableObject.CreateInstance<FlyAction>();
            action.horizontalSpeed = ho;
            action.direction = di;
            return action;
        }

        public override void Start()
        {
            enable = true;
            acceleration = 9.8f;
            time = 0;
        }

        public override void Update()
        {
            time += Time.deltaTime;
            transform.Translate(Vector3.down * acceleration * time * Time.deltaTime);
            transform.Translate(direction * horizontalSpeed * Time.deltaTime);
            if (this.transform.position.y < -4)
            {
                this.destroy = true;
                this.enable = false;
                callback.actionDone(this);
            }
        }

        public static FlyAction getSSAction()
        {
            FlyAction action = ScriptableObject.CreateInstance<FlyAction>();
            return action;
        }
    }
}
