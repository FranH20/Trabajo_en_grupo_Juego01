using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController obj;
    private float movHorizontanl;
    private float movVertical;

    public bool movimiento = false;

    //Estadisticas
    [Header("Estadistica del Jugador")]
    public Image barraVida;
    public float vidaMax;
    public float vida;
    public float score;
    public float velocitdad;

    [Header("Barra Vida del Jugador")]
    private bool inmune = false;
    private float inmunetiempocontinuo = 0f;
    public float inmunetiempo = 1f;

    private Rigidbody2D rb;
    //Animator anim;


    private void Awake(){ //primera funcion
        obj = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // anim = GetComponent<Animator>();
    }

    void Update()
    {
        MovimientoPlayer();
        VerificarInmunidad();
    }

    void VerificarInmunidad(){
        if (inmune){
            inmunetiempocontinuo -= Time.deltaTime;
            if(inmunetiempocontinuo <= 0){
                inmune = false;
            }
        }
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
                //anim.SetBool("estaCorriendo",true);
            }else{
             // anim.SetBool("estaCorriendo",false);
            }

    }
    private void flip(float _xValor){
        Vector3 xscalar = transform.localScale;
        if(_xValor < 0)
            xscalar.x =Mathf.Abs(xscalar.x)*-1;
        else if(_xValor > 0)
            xscalar.x =Mathf.Abs(xscalar.x);
        
        transform.localScale =xscalar;

    }

        public void getDamage(int daño)
    {
        //AudioManager.obj.playHit();

        //UIManager.obj.updateLives();
        if(inmune != true){
             vida = vida-daño;
             goInmune();

            //reduccion de la barra de vida
            if(vida < 0 ){
                //Debug.Log("vida1 : " + vida);
                barraVida.fillAmount=0; 
            } else{
                barraVida.fillAmount=vida/vidaMax; 
            }
        }

        //verificar si el juego es game over
        if (vida <= 0)
        {
                //FXManager.obj.showPop(transform.position);
                //Game.obj.gameOver();
                //this.gameObject.SetActive(false);
            SceneManager.LoadScene("GameOver");


        }

    }

    private void goInmune(){
            inmune = true;
            inmunetiempocontinuo = inmunetiempo;
    }

    public void addLive(int cantVida)
    {
        if((vida+cantVida) > vidaMax){
            vida=vidaMax;
        }else{
            vida = vida + cantVida;
        }
    }


    private void OnDestroy(){
        obj = null;
    }

}
