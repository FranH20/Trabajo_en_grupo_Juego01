using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaE : MonoBehaviour
{
    public GameObject Bala;
   // public float fireRate = 0.5f;
   // float nextFire = 0.0f;

    void Start()
    {

    }

    void Update(){

        if(Input.GetMouseButtonUp(0)){

            Instantiate(Bala,transform.position,transform.rotation);
        }
        //Debug.Log(movHorizontanl);

      /*  if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire  ){
            nextFire = Time.time + fireRate;
            fire();
        }
    */




    }
    void fire(){
        //Instantiate(Bala,transform.position,Quaternion.identity);
        //Instantiate(Bala,transform.position,transform.rotation);
    }

  /*  public void set_Distancia(float d){
        this.distancia = d;
    }*/


}
