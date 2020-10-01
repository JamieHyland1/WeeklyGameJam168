using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public bool blockOnButton = false;
    private Animator anim;
    private GameObject hiddenPlat;

    void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (blockOnButton == true)
        {
            anim.SetBool("isPressed",true);
            hiddenPlat = GameObject.Find("Hidden Platform");
            hiddenPlat
        }

        else
        {
            anim.SetBool("isPressed",false);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block")
        {
            blockOnButton = true;
            anim.SetBool("isPressed", true);
            hiddenPlat = GameObject.Find("Hidden Platform");
            hiddenPlat.GetComponent<SpriteRenderer>().enabled = true;
            hiddenPlat.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block")
        {
            blockOnButton = false;
            anim.SetBool("isPressed", false);
            hiddenPlat = GameObject.Find("Hidden Platform");
            hiddenPlat.GetComponent<SpriteRenderer>().enabled = false;
            hiddenPlat.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
