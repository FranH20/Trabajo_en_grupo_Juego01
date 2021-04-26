using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacionArmas : MonoBehaviour
{

    private float angulo=0;
    private int vuelta=1;
    void Start()
    {
        //InvokeRepeating("rotando", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        rotando();
    }
    void rotando(){
       
        if(vuelta==1){
            if(angulo <= 45){
                angulo = angulo +5f;
                transform.rotation = Quaternion.Euler(new Vector3(0,0,angulo));
            }else{vuelta=-1;}
        }

        if(vuelta==-1){
            if(angulo >= -45){
                angulo = angulo -5f;
                transform.rotation = Quaternion.Euler(new Vector3(0,0,angulo));
            }else{vuelta=1;}
        }


        
    }

}
