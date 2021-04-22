using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player0 : MonoBehaviour
{
    private Rigidbody2D rb;

    public float velocidad = 5f;
    public float movhor;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
         rb.velocity =new Vector2(movhor * velocidad,rb.velocity.y);
    }

    private void flip(float _xValor){
        Vector3 xscalar = transform.localScale;
        if(_xValor < 0)
            xscalar.x =Mathf.Abs(xscalar.x)*-1;
        else if(_xValor > 0)
            xscalar.x =Mathf.Abs(xscalar.x);
        
        transform.localScale =xscalar;

    }


    void Update()
    {
        

        movhor = Input.GetAxisRaw("Horizontal");

        flip(movhor);//mover izquierda derecha y escala


    }
}
