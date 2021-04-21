using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Src_room : MonoBehaviour
{
   public GameObject [] doors;
   public bool open;
   private bool openDoors;

    public GameObject[] enemigos;
    public bool AllDead;
    private bool FirstTimeEnter;

    void Start()
    {
        
    }

    void Update()
    {
        openDoors = !doors[0].GetComponent<Scr_puertas>().locked;

        if(open == false && openDoors == true){
            foreach(GameObject Door in doors){
                Door.GetComponent<Scr_puertas>().locked = true;
             
            }
        }else if(open == true && openDoors == false){
            foreach(GameObject Door in doors){
                Door.GetComponent<Scr_puertas>().locked = false;
            }
        }
        VerificarEnemigosDead();
        if(AllDead){
            open = true;
        }

       // Debug.Log("open= "+open+"  openDoor "+openDoors );

    }

    public void VerificarEnemigosDead(){
        
        for(int i=0;i<enemigos.Length;i++){
            if(enemigos[i]!=null){
                AllDead = false;
            }else{ AllDead = true;}
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //collision.gameObject.CompareTag("Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            if(FirstTimeEnter == false){
                FirstTimeEnter = true;
                open= false;
            }

        }
    } 



}
