using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Src_room : MonoBehaviour
{
    public static Src_room obj;
    GameObject [] doors;
    public static bool open; //static para todas las habitaciones
    private bool openDoors;

    public GameObject[] enemigos;
    public  bool AllDead;
    public static int ContadorEnemigosSalaActual = 1;
    private bool FirstTimeEnter;

    void Start()
    {
        doors = GrupoPuertas.objGp.doors;
        VerificarEnemigosDead();
    }

    private void Awake(){ //primera funcion
        obj = this;
    }

    void Update()
    {
         //VerificarEnemigosDead();
         VerificarPuertas();
    }

    void VerificarPuertas(){

        openDoors = doors[0].GetComponent<Scr_puertas>().locked;
        
    
        if(open == false && openDoors == false){
            foreach(GameObject Door in doors){
                Door.GetComponent<Scr_puertas>().locked = true;
                 
                //Debug.Log(" PuertasA : " + GrupoPuertas.objGp.Val);       
            }
        }else if(open == true && openDoors == true){
            foreach(GameObject Door in doors){
                Door.GetComponent<Scr_puertas>().locked = false;
                 //Debug.Log(" PuertasC : " +open);     
            }
        }

    }

    public void VerificarEnemigosDead(){

            ContadorEnemigosSalaActual = ContadorEnemigosSalaActual - 1;
            if(ContadorEnemigosSalaActual == 0){
                 AllDead = true;
                    open = true;
            }

           // Debug.Log(" enemigos Sala : " +enemigos.Length);     
            /*for(int i=0;i<enemigos.Length;i++){
                if(enemigos[i]==null){
                    AllDead = true;
                    open = true;
                }
            }*/
             



    }

    void OnTriggerExit2D(Collider2D collision)
    {   
        ContadorEnemigosSalaActual = enemigos.Length;
        Debug.Log(" enemigos Sala : " +ContadorEnemigosSalaActual);     
        if (collision.gameObject.CompareTag("Player"))
        {   
            if(FirstTimeEnter == false){
                FirstTimeEnter = true;
                open= false;
                //Debug.Log(" enemigos Sala : " +enemigos.Length); 
            }

        }
    } 



}
