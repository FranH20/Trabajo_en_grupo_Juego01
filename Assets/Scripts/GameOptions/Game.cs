using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game obj;
    public bool gamePausa = false;
    public int score = 0;


    void Awake()
    {
        obj = this;
    }
    void Start()
    {
        gamePausa = false;
        UIManager.obj.startGame();
    }

    public void addScore(int scoreGive)
    {
       score += scoreGive;
       UIManager.obj.updateScore();
    }

    public void gameOver()
    {
      //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

        void OnDestroy()
    {
        obj = null;
    }

}
