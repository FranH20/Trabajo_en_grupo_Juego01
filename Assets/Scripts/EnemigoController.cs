using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{   
    //rango de vision y de ataque para realizar las acciones hacia el Player

    public static EnemigoController objEnemy;
    public float radioVision;
    public float radioAtaque;
    public float velocidad;
    Vector3 initialPosition; //posicion a donde volvera cuando este en reposo
    GameObject Player;
    Rigidbody2D rb;
    Animator anim; 


    //
    private float movHorizontanl;

    public bool movimiento = false;


    private void Awake(){ //primera funcion
        objEnemy = this;
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        initialPosition = transform.position;
    }

    void Update()
    {
        MovimientoPlayer();

    }

     void MovimientoPlayer(){
        movHorizontanl = Input.GetAxisRaw("Horizontal");
        //movVertical = Input.GetAxisRaw("Vertical");
        movimiento =(movHorizontanl !=0f);

        //por defecto el enemigo volvera a su posicion inicial cuando no este en persecucion del player
        Vector3 target = initialPosition;

        //
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Player.transform.position - transform.position,
            radioVision,
            1 << LayerMask.NameToLayer("Default")
            //Pone al enemigo en un layer distinto a Default para evitar el raycast
            //tambien pone al objeto ataque y al prefab slash un layer attack
            //sino los detectara como entornos y se mueve atras al hacer ataques
        );
        Vector3 forward = transform.TransformDirection(Player.transform.position - transform.position);
        Debug.DrawRay(transform.position,forward,Color.red);

        //si  el raycast encuentra el Player lo ponemos de target
        //si hay una pared en medio no lo vera
        if(hit.collider != null){
            if(hit.collider.tag == "Player"){
                target = Player.transform.position;
            }
        }



        //calculamos la distancia del Objeto enemigo con la posicion del juegador(tag player)
        //float distancia = Vector3.Distance(Player.transform.position, transform.position);
        //Calculamos la distancia y direccion actual hasta el target
        float distancia = Vector3.Distance(target,transform.position);
        Vector3 dir = (target - transform.position).normalized;

        

        //si es el enemigo y esta en el rango de ataque nos paramos y le atacamos
        if(target != initialPosition && distancia < radioAtaque){
            //aqui le atacariamos pero por ahora simplemente cambiamos la animacion
           // anim.SetFloat("movX",dir.x);
           // anim.SetFloat("movY",dir.y);
           // anim.Play("Enemigo1_caminar",-1,0);//congela la animacion de andar
          
           anim.SetBool("Enemy1_isCaminando",false);
        }else{
            rb.MovePosition(transform.position + dir * velocidad * Time.deltaTime);

            //al movernos establecemos la animacion de movimiento
            // Debug.Log("regresa");
           // anim.speed = 1;
           // anim.SetFloat("movX",dir.x);
           // anim.SetFloat("movY",dir.y);
           // anim.SetBool("Enemigo1_caminar",true);
           flip(movHorizontanl);//mover izquierda derecha y escala
           anim.SetBool("Enemy1_isCaminando",true);

        }

        //una ultima comprobacion para evitar busg forzando la posicion inicial
        if(target == initialPosition && distancia < 0.02f){
            transform.position = initialPosition;
            //y cambiamos la animacion de nuevo a idIn
            //anim.SetBool("Enemigo1_caminar",false);
            anim.SetBool("Enemy1_isCaminando",false);
        }

        //El enemigo se mueve en direccion al target
//        float fixedVelocidad = velocidad * Time.deltaTime;
//        transform.position =  Vector3.MoveTowards(transform.position ,target ,fixedVelocidad);

        // debug la persecucion , creara una linea en direccion al jugador
        Debug.DrawLine(transform.position, target, Color.green);


     }



    //permirira dibujar el radio de vision sobre la scena  , dibujara una sphera
    void OnDrawGizmos(){
        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireSphere(transform.position , radioVision);
        Gizmos.DrawWireSphere(transform.position , radioAtaque);
    }


    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, Player.transform.position) <= range;
    }



    private void flip(float _xValor){
        Vector3 xscalar = transform.localScale;
        if(_xValor < 0)
            xscalar.x =Mathf.Abs(xscalar.x)*-1;
        else if(_xValor > 0)
            xscalar.x =Mathf.Abs(xscalar.x);
        
        transform.localScale =xscalar;

    }

    private void OnDestroy(){
        objEnemy = null;
    }



}
