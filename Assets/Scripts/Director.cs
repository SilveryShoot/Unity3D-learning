﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : System.Object {
    private static Director instance;
    public SceneController sceneController;

    public static Director getInstance()
    {
        if (instance == null)
        {
            instance = new Director();
        }
        return instance;
    }
}
