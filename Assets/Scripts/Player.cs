using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 5f;
	Vector2 targetPosition;
	Vector2 direction;
	Rigidbody2D rb;
	Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GestionarMovimiento();
        GestionarOrientacion();
    }

    void GestionarMovimiento()
    {
    	if(Input.GetMouseButton(0))
    	{
    		Debug.Log("Pressed left click.");
    		targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    		direction = new Vector2(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y);
    		direction.Normalize();

    		Vector2 velocity = direction * velocidad;

    		rb.velocity = velocity;
    		//animator.SetBool("isMoving", true);
    	}
    	else
    	{
    		rb.velocity = Vector2.zero;    	
    	}
    }

    void GestionarOrientacion()
    {
    	Debug.Log("This is the direction " + direction.x);
    	transform.localScale = new Vector2(direction.x > 0 ? 1 : -1, transform.localScale.y);
    }
}
