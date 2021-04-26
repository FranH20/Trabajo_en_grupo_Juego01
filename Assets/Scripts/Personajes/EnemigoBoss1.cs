using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoBoss1 : MonoBehaviour
{
    public static EnemigoBoss1 objEnemy;
    public float vida;
    public float vidaMax;

    public float rangox1;
    public float rangox2;
    public float rangoy1;
    public float rangoy2;
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    public float TiempoRandomInvocacion;
    private int number=0;
    public GameObject BossActivo;
    public Scrollbar barraVida;
    //public Text txt_nombre;


    private void Awake(){ //primera funcion
        objEnemy = this;
    }
    void Start()
    {
        InvokeRepeating("NumeroRandom", 2.0f, TiempoRandomInvocacion);
    }
    void Update()
    {   
        barraVida.size=vida;
        //txt_nombre.text = "aya"; 
        //VerificarVida();
    }

    void VerificarVida(){
        //barraVida.size=vida;

    }


    void NumeroRandom(){
        number = Random.Range(10, 60);

        if(number==10){
            invocarEnemigos(enemigo1);
        }
        if(number==30){
            invocarEnemigos(enemigo2);
        }
        if(number==60){
            invocarEnemigos(enemigo3);
        }
    }

    
    void invocarEnemigos(GameObject enemigoDeInvocacion){

        var position1 = transform.position;
        var position = new Vector3(Random.Range(transform.position.x+rangox1, transform.position.x+rangox2),
        Random.Range(transform.position.y+rangoy1,transform.position.y+rangoy2), 0);
        Instantiate(enemigoDeInvocacion, position, Quaternion.identity);
    


    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            vida=vida-0.03f;
            if(vida <= 0f){
                Debug.Log("ss");
                Game.obj.addScore(100);
                Src_room.obj.RestarEnemigosDead();
                BossActivo.SetActive(false);
                Destroy(gameObject);
            }

        }
    } 
        private void OnDestroy(){
        objEnemy = null;
    }



}
