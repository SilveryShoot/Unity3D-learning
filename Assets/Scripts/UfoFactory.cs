using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    class UfoFactory:MonoBehaviour
    {        
        private List<Ufo> occupied  = new List<Ufo>();
        private List<Ufo> ready = new List<Ufo>();

        private void Awake()
        {
        }

        public Ufo getUfo(int round)
        {
            Ufo newDisk;
            if (ready.Count > 0)
            {
                newDisk = ready[0];
                ready.Remove(ready[0]);
            }
            else
            {
                newDisk = new Ufo();
            }
            newDisk.load();
            int start = 0;
            if (round == 1) start = 100;
            if (round == 2) start = 250;
            int selectedColor = Random.Range(start, round * 499);

            if (selectedColor > 500)
            {
                round = 2;
            }
            else if (selectedColor > 300)
            {
                round = 1;
            }
            else
            {
                round = 0;
            }
            switch (round)
            {
                case 0:
                    {
                        newDisk.setColor(Color.yellow);
                        float RanX = UnityEngine.Random.Range(-1f, 1f) < 0 ? -1 : 1;
                        newDisk.setDirection(new Vector3(RanX, 1, 0));
                        newDisk.setSpeed(4.0f);
                        break;
                    }
                case 1:
                    {
                        newDisk.setColor(Color.red);
                        float RanX = UnityEngine.Random.Range(-1f, 1f) < 0 ? -1 : 1;
                        newDisk.setDirection(new Vector3(RanX, 1, 0));
                        newDisk.setSpeed(6.0f);
                        break;
                    }
                case 2:
                    {
                        newDisk.setColor(Color.black);
                        float RanX = UnityEngine.Random.Range(-1f, 1f) < 0 ? -1 : 1;
                        newDisk.setDirection(new Vector3(RanX, 1, 0));
                        newDisk.setSpeed(8.0f);
                        break;
                    }
            }
            occupied.Add(newDisk);
            newDisk.setId();
            return newDisk;
        }

        public void FreeUfo(Ufo disk)
        {
            Ufo temp = null;
            foreach(Ufo i in occupied)
            {
                if (i.id == disk.id)
                    temp = disk;
            }
            if(temp != null)
            {
                temp.inactivated();
                ready.Add(temp);
                occupied.Remove(temp);
            }
        }
    }
}
