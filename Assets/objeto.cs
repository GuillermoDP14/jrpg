using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class objeto : MonoBehaviour
{

    [SerializeField]
    private Text textoRecogido;
    private bool sePuedeRecojer;

    
    
        void Start()
    {
        textoRecogido.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sePuedeRecojer && Input.GetKeyDown(KeyCode.J)){
            Recoger();
            Invoke("dissapearText", 2);

        }

      

    }


    private void Recoger(){
        Destroy(gameObject);
        textoRecogido.gameObject.SetActive(true);
        

    }

    void dissapearText() {
        textoRecogido.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D colision){
        if(colision.gameObject.name.Equals("Player")){
            sePuedeRecojer = true;
        }
    }


    private void OnTriggerExit2D(Collider2D colision){
        if(colision.gameObject.name.Equals("Player")){
           

            sePuedeRecojer = false;
           
        }
    }
}
