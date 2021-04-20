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

    //Estadisticas

    //public float vidaMax;
   // public float vida;
   // public float score;
    




    //public LayerMask tocarpisoLayer; //si toca el piso o no
    private Rigidbody2D rb;
    Animator anim;


    private void Awake(){ //primera funcion
        obj = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
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



        flip(movHorizontanl);//mover izquierda derecha y escala

            if(movimiento){
                anim.SetBool("estaCorriendo",true);
            }else{
              anim.SetBool("estaCorriendo",false);
            }


    }
    private void flip(float _xValor){
        Vector3 xscalar = transform.localScale;
        if(_xValor < 0)
            xscalar.x =Mathf.Abs(xscalar.x)*-1;
        else if(_xValor > 0)
            xscalar.x =Mathf.Abs(xscalar.x);
        
        transform.localScale =xscalar;
       // player_rotate.obj._flip(1f);


    }

    private void OnDestroy(){
        obj = null;
    }

}
