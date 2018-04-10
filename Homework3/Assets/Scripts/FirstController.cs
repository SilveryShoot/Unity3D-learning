﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class FirstController : MonoBehaviour, SceneController, UserAction
{

    readonly Vector3 water_pos = new Vector3(0, 0.5F, 0);


    UserGUI userGUI;

    public CoastController fromCoast;
    public CoastController toCoast;
    public BoatController boat;
    private MyCharacterController[] characters;
    private FirstActionController actionManager;

    void Awake()
    {
        Director director = Director.getInstance();
        director.currentSceneController = this;
        userGUI = gameObject.AddComponent<UserGUI>() as UserGUI;
        characters = new MyCharacterController[6];
        loadResources();
    }

    void Start()
    {
        actionManager = GetComponent<FirstActionController>();
    }

    public void loadResources()
    {
        GameObject water = Instantiate(Resources.Load("Prefab/Water", typeof(GameObject)), water_pos, Quaternion.identity, null) as GameObject;//生成水的资源
        water.name = "water";

        fromCoast = new CoastController("from");
        toCoast = new CoastController("to");
        boat = new BoatController();

        loadCharacter();
    }

    private void loadCharacter()
    {
        for (int i = 0; i < 3; i++)
        {
            MyCharacterController cha = new MyCharacterController("priest");
            cha.setName("priest" + i);
            cha.setPosition(fromCoast.getEmptyPosition());
            cha.getOnCoast(fromCoast);
            fromCoast.getOnCoast(cha);

            characters[i] = cha;
        }

        for (int i = 0; i < 3; i++)
        {
            MyCharacterController cha = new MyCharacterController("devil");
            cha.setName("devil" + i);
            cha.setPosition(fromCoast.getEmptyPosition());
            cha.getOnCoast(fromCoast);
            fromCoast.getOnCoast(cha);

            characters[i + 3] = cha;
        }
    }//加载多个人物


    public void moveBoat()
    {
        if (boat.isEmpty())
            return;
        actionManager.toggleBoat(boat);
        userGUI.status = check_game_over();
    }//移动船

    public void characterIsClicked(MyCharacterController characterCtrl)
    {
        if (characterCtrl.isOnBoat())
        {
            CoastController whichCoast;
            if (boat.get_to_or_from() == -1)
            { // 判断船只在哪边来决定角色下船到哪个岸边
                whichCoast = toCoast;
            }
            else
            {
                whichCoast = fromCoast;
            }

            boat.GetOffBoat(characterCtrl.getName());
            actionManager.moveCharacter(characterCtrl.getInstance(), whichCoast.getEmptyPosition());
            characterCtrl.getOnCoast(whichCoast);
            whichCoast.getOnCoast(characterCtrl);

        }//如果有两个人物在船上那么船会动
        else
        {                                   
            CoastController whichCoast = characterCtrl.getCoastController();

            if (boat.getEmptyIndex() == -1)
            {       // boat is full
                return;
            }

            if (whichCoast.get_to_or_from() != boat.get_to_or_from())   // boat is not on the side of character
                return;

            whichCoast.getOffCoast(characterCtrl.getName());
            actionManager.moveCharacter(characterCtrl.getInstance(), boat.getEmptyPosition());
            characterCtrl.getOnBoat(boat);
            boat.GetOnBoat(characterCtrl);
        }//否则船不会动
        userGUI.status = check_game_over();
    }

    int check_game_over()
    {   // 0->not finish, 1->lose, 2->win
        int from_priest = 0;
        int from_devil = 0;
        int to_priest = 0;
        int to_devil = 0;

        int[] fromCount = fromCoast.getCharacterNum();
        from_priest += fromCount[0];
        from_devil += fromCount[1];

        int[] toCount = toCoast.getCharacterNum();
        to_priest += toCount[0];
        to_devil += toCount[1];

        if (to_priest + to_devil == 6)      // win
            return 2;

        int[] boatCount = boat.getCharacterNum();
        if (boat.get_to_or_from() == -1)
        {   // boat at toCoast
            to_priest += boatCount[0];
            to_devil += boatCount[1];
        }
        else
        {   // boat at fromCoast
            from_priest += boatCount[0];
            from_devil += boatCount[1];
        }
        if (from_priest < from_devil && from_priest > 0)
        {       // lose
            return 1;
        }
        if (to_priest < to_devil && to_priest > 0)
        {
            return 1;
        }
        return 0;           // not finish
    }

    public void restart()
    {
        boat.reset();
        fromCoast.reset();
        toCoast.reset();
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].reset();
        }
        if(boat.get_to_or_from() == -1)
            actionManager.toggleBoat(boat);
    }//重新开始
}