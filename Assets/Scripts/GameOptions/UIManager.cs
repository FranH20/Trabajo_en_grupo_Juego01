using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager obj;
    public Text txt_score;
    public Text enemigosSala;
    //public Transform UIPanel;


    private void Awake()
    {
        obj = this;
    }
    public void updateScore()
    {   
        enemigosSala.text = "" + Src_room.obj.NumeroEnemigos;
        txt_score.text = "" + Game.obj.score;
    }
    public void startGame()
    {
        //AudioManager.obj.playGui();

        //Game.obj.gamePausa = true;
        //UIPanel.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        obj = null;
    }

}
