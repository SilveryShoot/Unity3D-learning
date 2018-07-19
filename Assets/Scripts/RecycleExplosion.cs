using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleExplosion : MonoBehaviour {

    public ExplosionFactory factory;

    public void startTimer(float time)
    {
        Invoke("recycleExplosion", time);
    }

    private void recycleExplosion()
    {
        factory.recycle(gameObject);
    }
}
