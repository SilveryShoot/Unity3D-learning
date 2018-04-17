using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.ActionManager;

namespace Assets.Scripts
{
    public class FirstActionController : SSActionManager {
        public List<FlyAction> Fly;
        public int diskNumber = 0;
        private List<SSAction> used = new List<SSAction>();
        private List<SSAction> free = new List<SSAction>();

        SSAction GetSSAction()
        {
            SSAction action;
            if (free.Count > 0)
            {
                action = free[0];
                free.Remove(free[0]);
            }
            else
            {
                action = ScriptableObject.Instantiate<FlyAction>(Fly[0]);
            }

            used.Add(action);
            return action;
        }

        public void FreeSSAction(SSAction action)
        {
            SSAction tmp = null;
            foreach (SSAction i in used)
            {
                if (action.GetInstanceID() == i.GetInstanceID())
                {
                    tmp = i;
                }
            }
            if (tmp != null)
            {
                tmp.reset();
                free.Add(tmp);
                used.Remove(tmp);
            }
        }

        public void StartThrow(Queue<GameObject> diskQueue)
        {
            foreach (GameObject tmp in diskQueue)
            {
                this.addAction(tmp, GetSSAction(), this);
            }
        }


    }

}
