using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class FirstSceneController : MonoBehaviour,ISceneController,IUserAction
    {
        public FirstActionController action { get; set; }
        public ScoreRecorder score { get; set; }
        public Queue<GameObject> diskQueue { get; set;}
        private int diskNumber;
        UserGUI userGUI;
        private int currentRound = 0;
        public int round = 3;
        public float time = 0;
        private GameState gameState = GameState.START;

        private GameState state = GameState.START;

        private void Awake()
        {
            Director director = Director.getInstance();
            director.currentSceneControl = this;
            diskNumber = 10;
            this.gameObject.AddComponent<ScoreRecorder>();
            this.gameObject.AddComponent<UfoFactory>();
            score = Singleton<ScoreRecorder>.Instance;
            userGUI = gameObject.AddComponent<UserGUI>() as UserGUI;
            director.currentSceneControl.LoadResources();
        }

        private void Start()
        {
            action = GetComponent<FirstActionController>();
        }

        private void Update()
        {
            if (action.diskNumber == 0 && gameState == GameState.RUNNING)
            {
                gameState = GameState.ROUND_FINISH;

            }
            if (action.diskNumber == 0 && gameState == GameState.ROUND_START)
            {
                currentRound = (currentRound + 1) % round;
                NextRound();
                action.diskNumber = 10;
                gameState = GameState.RUNNING;
            }
            if (time > 1)
            {
                ThrowDisk();
                time = 0;
            }
            else
            {
                time += Time.deltaTime;
            }
        }

        private void NextRound()
        {
            UfoFactory df = Singleton<UfoFactory>.Instance;
            for (int i = 0; i < diskNumber; i++)
            {
                diskQueue.Enqueue(df.getUfo(currentRound).getGameObj());
            }
            action.StartThrow(diskQueue);

        }

        void ThrowDisk()
        {
            if (diskQueue.Count != 0)
            {
                Ufo disk = diskQueue.Dequeue().GetComponent<Ufo>();

                /** 
                 * 以下几句代码是随机确定飞碟出现的位置 
                 */

                Vector3 position = new Vector3(0, 0, 0);
                float y = UnityEngine.Random.Range(0f, 4f);
                position = new Vector3(-disk.getDirection().x * 7, y, 0);
                disk.setPosition(position);
                disk.activation();
            }
        }
        public void LoadResources()
        {            
        }

        public void GameOver()
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(700, 300, 400, 400), "GAMEOVER");

        }

        public int GetScore()
        {
            return score.score;
        }

        public GameState getGameState()
        {
            return gameState;
        }

        public void setGameState(GameState gs)
        {
            gameState = gs;
        }

        public void hit(Vector3 pos)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);

            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray);
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];

                if (hit.collider.gameObject.GetComponent<Ufo>() != null)
                {
                    score.Record(hit.collider.gameObject);

                    /** 
                     * 如果飞碟被击中，那么就移到地面之下，由工厂负责回收 
                     */

                    hit.collider.gameObject.transform.position = new Vector3(0, -5, 0);
                }

            }
        }

    }
}
