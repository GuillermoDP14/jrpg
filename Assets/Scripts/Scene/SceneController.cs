using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
   
    public void CambiarEscena(string nombre){
        print("Cambiando a la escena " + nombre);
        SceneManager.LoadScene(nombre);
    }

    
    public void Salir(){
        print("Cerrando juego ");
        Application.Quit();
    }

}
