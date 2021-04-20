using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_rotate : MonoBehaviour
{
    public static player_rotate obj;
    private Vector3 MousePosition,ObjetoPosition;
    private float angulo;


   // public GameObject Bala;
   // public float distancia;

    //GameObject Player;
    Vector3 Player;
    


    void Start()
    {
        Player = new Vector3(PlayerController.obj.transform.position.x,PlayerController.obj.transform.position.y,0f);
    }

    // Update is called once per frame
    void Update()
    {
        Player = new Vector2(PlayerController.obj.transform.position.x,PlayerController.obj.transform.position.y);
        transform.position = Player;
        MousePosition = Input.mousePosition;
        ObjetoPosition = Camera.main.WorldToScreenPoint(transform.position);
        angulo = Mathf.Atan2((MousePosition.y-ObjetoPosition.y),(MousePosition.x-ObjetoPosition.x))*Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angulo));
    }



}
