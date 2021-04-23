using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaP : MonoBehaviour
{
    public GameObject Bala;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetMouseButtonUp(0)){

            Instantiate(Bala,transform.position,transform.rotation);
        }
    }
}
