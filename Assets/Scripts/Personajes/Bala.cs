using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
   Rigidbody2D rb;
   public float velocidad_disparo;
   public float tiempoVida = 1f;
   

   //private Vector3 MousePosition,ObjetoPosition;
   private Vector3 positionPasada;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * velocidad_disparo;
        positionPasada = transform.position;
    }
    

    void Update()
    {
        if(positionPasada != transform.position){
            transform.right = transform.position - positionPasada;
            positionPasada = transform.position;
        }
        Destroy(gameObject,tiempoVida);
    }
}
