using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Boolean playerTouching = false;
    private GameObject hero;

    void Start()
    {
        hero = GameObject.Find("Hero");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerTouching == true) //when f pressed.
        {
            Debug.Log("Pickup");
            this.transform.position = hero.transform.position + new Vector3(1f, 1f, 0f);
            this.transform.parent = hero.transform;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        playerTouching = true;
        Debug.Log("Enter");
    }

    void OnTriggerExit(Collider other)
    {
        playerTouching = false;
        Debug.Log("Exit");
    }
}
