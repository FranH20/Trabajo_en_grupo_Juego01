using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController obj;
    public float velocitdad;
    private float movHorizontanl;
    private float movVertical;
    

    public bool movimiento = false;


    //public LayerMask tocarpisoLayer; //si toca el piso o no
    private Rigidbody2D rb;


    private void Awake(){ //primera funcion
        obj = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        MovimientoPlayer();
    
    }
    void FixedUpdate(){
        rb.velocity =new Vector2(movHorizontanl * velocitdad,movVertical * velocitdad );
    }

    void MovimientoPlayer(){
        movHorizontanl = Input.GetAxisRaw("Horizontal");
        movVertical = Input.GetAxisRaw("Vertical");
        movimiento =(movHorizontanl !=0f);
    }

    private void OnDestroy(){
        obj = null;
    }

}
