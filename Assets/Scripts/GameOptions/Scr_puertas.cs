using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_puertas : MonoBehaviour
{
    public Sprite Locked,Unlocked;
    public bool locked;
    public BoxCollider2D b_coll;

    void Start()
    {
        
    }

    void Update()
    {
       //  Debug.Log("Lokecd= "+locked);
        if(locked == true){
            GetComponent<SpriteRenderer>().sprite = Locked;
            b_coll.enabled = true;
        }else if(locked == false){
            GetComponent<SpriteRenderer>().sprite = Unlocked;
            b_coll.enabled = false;
        }


    }
}
