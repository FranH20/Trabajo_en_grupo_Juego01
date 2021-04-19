using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBalls : MonoBehaviour
{
	public ParticleSystem fireBalls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.Space))
    	{
            ToggleFireballs();
        }
    }

    public void ToggleFireballs()
    {
    	if(fireBalls.isPlaying)
    	{
    		fireBalls.Stop();

    	}else{
    		fireBalls.Play();
    	}
    }
}
