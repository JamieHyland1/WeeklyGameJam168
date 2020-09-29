using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SwitchChar : MonoBehaviour
{
    private GameObject hero1;
    private GameObject hero2;

    void Start()
    {
        hero1 = GameObject.Find("Hero");
        hero2= GameObject.Find("Hero 2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hero1.GetComponent<MoveController>().enabled == true)
        {
            hero1.GetComponent<MoveController>().enabled = false;
            hero2.GetComponent<MoveController>().enabled = true;
            hero1.GetComponent<SwitchChar>().enabled = false;
            hero2.GetComponent<SwitchChar>().enabled = true;
        }

        else if (Input.GetKeyDown(KeyCode.E) && hero2.GetComponent<MoveController>().enabled == true)
        {
            hero2.GetComponent<MoveController>().enabled = false;
            hero1.GetComponent<MoveController>().enabled = true;
            hero2.GetComponent<SwitchChar>().enabled = false;
            hero1.GetComponent<SwitchChar>().enabled = true;
        }
    }

}
