﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 4f;

    Animator anim;

    Rigidbody2D rb2d;
    Vector2 mov;

    public VectorValue startingPosition;

    // Start is called before the first frame update
    void Start() {

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();     
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update() {

        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical"));

        if(mov != Vector2.zero) {
            anim.SetFloat("movX", mov.x);
            anim.SetFloat("movY", mov.y);
            anim.SetBool("walking", true);
        } else {
            anim.SetBool("walking", false);
        }


        /*
        Vector3 mov = new Vector3(
            Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical"),0);

        transform.position = Vector3.MoveTowards(
            transform.position, 
            transform.position + mov, 
            speed * Time.deltaTime
        );
        */

                
    }

    void FixedUpdate () {

        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
}
