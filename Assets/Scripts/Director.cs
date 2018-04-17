﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Director : System.Object
{

    /** 
     * currentSceneControl标志目前正在使用的场景 
     */

    public ISceneController currentSceneControl { get; set; }

    /** 
     * Director这个类是采用单例模式 
     */

    private static Director director;

    private Director()
    {

    }

    public static Director getInstance()
    {
        if (director == null)
        {
            director = new Director();
        }
        return director;
    }
}


