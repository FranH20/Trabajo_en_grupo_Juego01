using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
  // public float velX;
  // public float velY=0;
   Rigidbody2D rb;
   public float velocidad_disparo;

   private Vector3 MousePosition,ObjetoPosition;
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

        //rb.velocity =new Vector2(velX,velY); 
        Destroy(gameObject,5f);
    }
}
