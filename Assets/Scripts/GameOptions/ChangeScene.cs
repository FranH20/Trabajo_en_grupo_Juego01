using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
 
    public void CarmbiarNivel(string nombreScena){
        
        SceneManager.LoadScene(nombreScena);

        /*if( nivel == 0 ){
            SceneManager.LoadScene(0);
        }else{
            SceneManager.LoadScene("Nivel"+ nivel);
        }*/
    }

}
