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
    public  static int ContadorEnemigosSalaActual;
    public int NumeroEnemigos;
    private bool FirstTimeEnter;

    void Start()
    {
        doors = GrupoPuertas.objGp.doors;
        VerificarPuertas();
    }

    private void Awake(){ //primera funcion
        obj = this;
    }

    void Update()
    {
         //VerificarEnemigosDead();
         
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

    public void RestarEnemigosDead(){
            ContadorEnemigosSalaActual = ContadorEnemigosSalaActual - 1;
            NumeroEnemigos = ContadorEnemigosSalaActual;
            Debug.Log(" enemigos restantes : " +ContadorEnemigosSalaActual);
            if(ContadorEnemigosSalaActual == 0){
                 AllDead = true;
                    open = true;
                    VerificarPuertas();
            }

              
            /*for(int i=0;i<enemigos.Length;i++){
                if(enemigos[i]==null){
                    AllDead = true;
                    open = true;
                }
            }*/
             



    }

    void OnTriggerExit2D(Collider2D collision)
    {           
        if (collision.gameObject.CompareTag("Player"))
        {   
            if(FirstTimeEnter == false){
                ContadorEnemigosSalaActual = enemigos.Length;
                NumeroEnemigos = enemigos.Length;
                Debug.Log(" enemigos en Sala : " +ContadorEnemigosSalaActual);    
                FirstTimeEnter = true;
                open= false;
                VerificarPuertas();
                //Debug.Log(" enemigos Sala : " +enemigos.Length); 
            }

        }
    } 



}
