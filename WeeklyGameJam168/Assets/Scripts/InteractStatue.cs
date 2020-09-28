using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class InteractStatue : MonoBehaviour
{
    private Animator anim; //create animator
    private Boolean playerTouching = false;
    private GameObject torch;
    private GameObject statue;
    private GameObject hero;

    void Awake()
    {
        anim = GetComponent<Animator>(); //set animator to parents animator
        hero = GameObject.Find("Hero");
        statue = GameObject.Find("Statue");
        torch = GameObject.Find("Torch");
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.F) && playerTouching == true) //when f pressed.
        {
            if (torch.transform.IsChildOf(hero.transform))
            {
                torch.transform.position = statue.transform.position + new Vector3(-2.7f, +3.1f, 0);
                torch.transform.parent = statue.transform;
                anim.SetTrigger("Rotating"); //activates rotating trigger in animator
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        playerTouching = true;
    }

    void OnTriggerExit(Collider other)
    {
        playerTouching = false;
    }
}