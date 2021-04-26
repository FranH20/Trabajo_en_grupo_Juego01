using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaBoss : MonoBehaviour
{
    public static SalaBoss obj;
    private bool FirstTimeEnter;
    public GameObject BossFinal;
    public bool EstadoSala = false;

    public GameObject CameraCinematica1;

    private void Awake(){ //primera funcion
        obj = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    IEnumerator returne(){
        yield return new WaitForSeconds(5.2f);
        CameraCinematica1.SetActive(false);
        Debug.Log("s");
        
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {   
            if(FirstTimeEnter == false){
                BossFinal.SetActive(true);
                FirstTimeEnter = true;
                EstadoSala = true; //activamos para que ahora no cuente los enemigos invocados como enemigos de sala
                Src_room.obj.cerrarPuertas();
                Src_room.obj.VerificarPuertas();

                CameraCinematica1.SetActive(true);
                StartCoroutine ("returne");
               
            }

        }



    } 


}
