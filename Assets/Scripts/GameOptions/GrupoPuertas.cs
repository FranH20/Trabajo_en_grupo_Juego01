using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrupoPuertas : MonoBehaviour
{
    public static GrupoPuertas objGp;
    public GameObject [] doors;

    public string Val ="a";

    private void Awake(){ //primera funcion
        objGp = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDestroy(){
        objGp = null;
    }
}
