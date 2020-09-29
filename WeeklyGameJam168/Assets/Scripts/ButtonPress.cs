using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public bool blockOnButton = false;
    private Animator anim;

    void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (blockOnButton == true)
        {
            anim.SetBool("isPressed",true);
            Debug.Log("pressed");
        }

        else
        {
            anim.SetBool("isPressed",false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block" || other.gameObject.tag == "Player")
        {
            blockOnButton = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block" || other.gameObject.tag == "Player")
        {
            blockOnButton = false;
        }
    }
}
