using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaEn : MonoBehaviour
{
    public GameObject Bala;
    public float velocidadBala;
    public float tiempoVida;

    void Start()
    {
        InvokeRepeating("fire", 3.0f, 2.0f);
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
