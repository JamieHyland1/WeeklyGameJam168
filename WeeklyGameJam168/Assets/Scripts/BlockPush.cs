using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPush : MonoBehaviour
{
    public Animator anim; //create animator
    private Boolean playerTouching = false;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        //anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {
        if ((Input.GetKey("left") || Input.GetKey("right"))&&playerTouching == true) //when right pressed.
        {
            anim.SetBool("Pushing", true);
            rigid.constraints = ~RigidbodyConstraints2D.FreezePositionX;
            Debug.Log("Push");
        }
        else
        {
            anim.SetBool("Pushing",false);
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        { 
            playerTouching = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerTouching = false;
        }
    }
}
