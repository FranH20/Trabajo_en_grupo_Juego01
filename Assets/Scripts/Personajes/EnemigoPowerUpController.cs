using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPowerUpController : MonoBehaviour
{
    public static EnemigoPowerUpController objEnemy;
    public float vida;
    public float vidaMax;


    
    private void Awake(){ //primera funcion
        objEnemy = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            vida=vida-10;
            if(vida<= 0){
                //Room.GetComponent<Src_room>().VerificarEnemigosDead();
              //  gameObject.SetActive(false);
                //Src_room.obj.VerificarEnemigosDead();
                Destroy(gameObject);
            }

        }
    } 


}
