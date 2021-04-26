using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaEn : MonoBehaviour
{
    public GameObject Bala;
    public float velocidadBala;
    public float tiempoVida;
    public float velocidadInvocacion=0;

    void Start()
    {
        if(velocidadInvocacion==0f){velocidadInvocacion=2.0f;}//por defecto
        InvokeRepeating("fire", 3.0f, velocidadInvocacion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void fire(){
        Bala.GetComponent<Bala>().velocidad_disparo = velocidadBala;
        Bala.GetComponent<Bala>().tiempoVida = tiempoVida;
        Instantiate(Bala,transform.position,transform.rotation);
        //Instantiate(Bala,transform.position,Quaternion.identity);
        //Instantiate(Bala,transform.position,transform.rotation);
     //   Instantiate(Bala,transform.position,transform.rotation);
    }
    


}
