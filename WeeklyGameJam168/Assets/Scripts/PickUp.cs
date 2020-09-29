using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject hero1;
    private GameObject hero2;
    private Boolean playerTouching = false;

    void Start()
    {
        hero1 = GameObject.Find("Hero");
        hero2 = GameObject.Find("Hero 2");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerTouching == true && this.transform.parent != hero1.transform) //when f pressed.
        {
            Debug.Log("Pickup1");
            this.transform.position = hero1.transform.position + new Vector3(.2f, .2f, 0f);
            this.transform.parent = null;
            this.transform.parent = hero1.transform;
        }
 
        if (Input.GetKeyDown(KeyCode.F) && playerTouching == true && hero2.GetComponent<MoveController>().enabled == true && this.transform.parent != hero2.transform) //when f pressed.
        {
             Debug.Log("Pickup2" + this.transform.parent);
            this.transform.position = hero2.transform.position + new Vector3(.2f, .2f, 0f);
            this.transform.parent = null;
            this.transform.parent = hero2.transform;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
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
