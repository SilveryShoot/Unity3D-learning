using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public Texture2D img;
    private int turn = 1;
    private int[,] state = new int[3, 3];

    // Use this for initialization
    void Start () {
        reset();
	}
	
	void reset()
    {
        turn = 1;
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                state[i, j] = 0;
            }
        }
    }

    void OnGUI()
    {
        GUIStyle mystyle = new GUIStyle();
        mystyle.normal.background = img;
        GUIStyle fontstyle = new GUIStyle();
        fontstyle.fontSize = 30;
        fontstyle.normal.textColor = new Color(255, 255, 255);
        fontstyle.alignment = TextAnchor.MiddleCenter;
        fontstyle.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(0, 0, 1280, 800), "", mystyle);
        if (GUI.Button(new Rect(400, 600, 100, 50), "Reset"))
            reset();
        int result = check();  // 返回0代表游戏没有结束，1代表圈圈赢，2代表叉叉赢。  
        if (result == 1)
        {
            GUI.Label(new Rect(400, 500, 100, 50), "O wins!",fontstyle);
        }
        else if (result == 2)
        {
            GUI.Label(new Rect(400, 500, 100, 50), "X wins!",fontstyle);
        }
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                if (state[i, j] == 1)
                    GUI.Button(new Rect(300+i * 100, 50+j * 100, 100, 100), "O",fontstyle);
                if (state[i, j] == 2)
                    GUI.Button(new Rect(300+i * 100, 50+j * 100, 100, 100), "X", fontstyle);
                if (GUI.Button(new Rect(300+i * 100, 50+j * 100, 100, 100), ""))
                {
                    if (result == 0)
                    {
                        if (turn == 1)
                            state[i, j] = 1;
                        else
                            state[i, j] = 2;
                        turn = -turn;
                    }
                }
            }
        }
    }

    int check()
    {
        // 横向连线  
        for (int i = 0; i < 3; ++i)
        {
            if (state[i, 0] != 0 && state[i, 0] == state[i, 1] && state[i, 1] == state[i, 2])
            {
                return state[i, 0];
            }
        }
        //纵向连线  
        for (int j = 0; j < 3; ++j)
        {
            if (state[0, j] != 0 && state[0, j] == state[1, j] && state[1, j] == state[2, j])
            {
                return state[0, j];
            }
        }
        //斜向连线  
        if (state[1, 1] != 0 &&
            state[0, 0] == state[1, 1] && state[1, 1] == state[2, 2] ||
            state[0, 2] == state[1, 1] && state[1, 1] == state[2, 0])
        {
            return state[1, 1];
        }
        return 0;
    }

    //虽然借鉴师兄的代码写的，代码可能会重复但是绝对不是复制粘贴下来的，是自己一步步跟着打下来的
}

