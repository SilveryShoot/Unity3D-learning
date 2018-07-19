using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFactory : System.Object {
    private static ExplosionFactory instance;
    private static List<GameObject> appear;
    private static Queue<GameObject> disappear;

    public static ExplosionFactory getInstance()
    {
        if(instance == null)
        {
            instance = new ExplosionFactory();
            appear = new List<GameObject>();
            disappear = new Queue<GameObject>();
        }
        return instance;
    }

    public void explodeAt(Vector3 pos)
    {
        GameObject Explosion;
        if (disappear.Count == 0)
        {
            Explosion = GameObject.Instantiate(Resources.Load("Explosion", typeof(GameObject))) as GameObject;
            Explosion.AddComponent<RecycleExplosion>().factory = this;
        }
        else
        {
            Explosion = disappear.Dequeue();
        }
        appear.Add(Explosion);

        RecycleExplosion selfRecycle = Explosion.GetComponent<RecycleExplosion>();
        selfRecycle.startTimer(1.2F);

        Explosion.SetActive(true);
        Explosion.transform.position = pos;
    }

    public void recycle(GameObject explosion)
    {
        explosion.SetActive(false);
        appear.Remove(explosion);
        disappear.Enqueue(explosion);
    }
}
