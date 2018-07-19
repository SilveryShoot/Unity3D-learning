using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstSceneController : MonoBehaviour, SceneController
{
    Director director;
    UFOFactory UFOfactory;
    ExplosionFactory explosion;
    RuleController ruleController;
    FirstCharacterController firstCharacterController;
    ActionAdapter actionManager;
    Scorer scorer;
    public float pauseTime = 3f;
    public float count = 3f;
    List<UFOController> record;
    private int miss = 0;
    private Text missText;
    private Text overText;

    void Awake()
    {
        director = Director.getInstance();
        director.sceneController = this;

        UFOfactory = UFOFactory.getInstance();
        explosion = ExplosionFactory.getInstance();
        scorer = Scorer.getInstance();

        ruleController = gameObject.AddComponent<RuleController>();
        actionManager = gameObject.AddComponent<ActionAdapter>();

        record = new List<UFOController>();

        missText = (GameObject.Instantiate(Resources.Load("ShowMiss")) as GameObject).transform.Find("Num").GetComponent<Text>();
        missText.text = "" + miss;

        overText = (GameObject.Instantiate(Resources.Load("ShowOver")) as GameObject).transform.Find("Over").GetComponent<Text>();
        overText.text = "";

        LoadResources();
    }

    public void LoadResources()
    {
        firstCharacterController = new FirstCharacterController();
        Instantiate(Resources.Load("Terrain"));
    }

    private void Update()
    {
        if(miss > 15)
        {
            clear();
            overText.text = "Game Over\n Press R To Go On";
            if (Input.GetKeyDown("r"))
            {
                miss = 0;
                missText.text = "" + miss;
                scorer.ResetScore();
                ruleController.Reset();
                overText.text = "";
            }
        }
        else
        {
            if (count > 0)
            {
                count -= Time.deltaTime;
            }
            else
            {
                ruleController.IncreaseLevelByScore(scorer.GetScore());
                clear();
                int number = Random.Range(1, 5);
                actionManager.ChangeMode();
                for (int i = 0; i < number; i++)
                {
                    UFOController UFO = UFOfactory.CreateUFO();
                    UFO.appear();
                    UFO.getUFO().transform.position = new Vector3(Random.Range(-10, 10), Random.Range(10, 20), 20);
                    UFO.getUFO().transform.rotation = new Quaternion(0, 0, 0, 0);
                    actionManager.AddMovement(UFO.getUFO(), ruleController.GetSpeed());
                    record.Add(UFO);
                }
                count = pauseTime;
            }
        }  
    }

    void clear()
    {
        int number = record.Count;
        miss += number;
        missText.text = "" + miss;
        for (int i = 0; i < number; i++)
        {
            UFOController temp = record[0];
            actionManager.removeMovement(temp.getUFO());
            UFOfactory.ReuseUFO(temp);
            record.Remove(temp);
        }
    }

    public void UFOIsShot(UFOController UFO)
    {
        UFOfactory.ReuseUFO(UFO);
        record.Remove(UFO);
        explosion.explodeAt(UFO.getUFO().transform.position);
        scorer.AddScore(ruleController.GetLevel());
        actionManager.removeMovement(UFO.getUFO());
    }

    public void UFOHitGround(UFOController UFO)
    {
        UFOfactory.ReuseUFO(UFO);
        explosion.explodeAt(UFO.getUFO().transform.position);
        actionManager.removeMovement(UFO.getUFO());
    }

    public void GroundIsShot(Vector3 pos)
    {
        explosion.explodeAt(pos);
    }
}
