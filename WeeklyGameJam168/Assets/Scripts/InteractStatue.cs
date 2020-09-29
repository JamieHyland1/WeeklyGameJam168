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
    public TorchSwitch TorchSwitch;
    private Animator anim; //create animator
    private Boolean playerTouching = false;
    private GameObject torch;
    private GameObject statue;
    private GameObject hero1;
    private GameObject hero2;

    void Awake()
    {
        anim = GetComponent<Animator>(); //set animator to parents animator
    }

    void Start()
    {
        hero1 = GameObject.Find("Hero");
        hero2 = GameObject.Find("Hero 2");
        statue = GameObject.Find("Statue");
        torch = GameObject.Find("Torch");
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.F) && playerTouching == true && torch.transform.parent == hero1.transform) //when f pressed.
        {
            // torch.transform.position = statue.transform.position + new Vector3(-.6f, .8f, 0);
            // torch.transform.parent = statue.transform;
           // TorchSwitch.SwitchTorchParent(hero1,this.gameObject);
            anim.SetTrigger("Rotating"); //activates rotating trigger in animator
            GetComponent<ScreenFadeManager>().FlipScreens();
        }

       if (Input.GetKeyDown(KeyCode.F) && playerTouching == true && torch.transform.parent == hero2.transform)
        {
            // torch.transform.position = statue.transform.position + new Vector3(-.6f, .8f, 0);
            // torch.transform.parent = statue.transform;
        //    TorchSwitch.SwitchTorchParent(hero2,this.gameObject);
            anim.SetTrigger("Rotating"); //activates rotating trigger in animator
            GetComponent<ScreenFadeManager>().FlipScreens();
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