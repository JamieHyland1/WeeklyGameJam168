using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public bool besideTorch = false;
    public bool besideTikiTorch = false;
    public bool besideStatue = false;
    public bool besideBlock = false;
    public bool besideKey = false;
    public bool besideDoor = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
       if(other.gameObject.name == "Torch")besideTorch = true;
       if (other.gameObject.tag == "Key") besideKey = true;
       if (other.gameObject.name == "TikiTorch" || other.gameObject.name == "TikiTorchLeft" || other.gameObject.name == "TikiTorchRight")besideTikiTorch = true;
       if(other.gameObject.name == "Statue")besideStatue = true;
       if(other.gameObject.name == "door")besideDoor = true;
       if(other.gameObject.tag == "Spike"){
          this.GetComponent<PlayerHit>().registerHit();
       }
        if (other.gameObject.tag == "Block")
        {
            besideBlock = true;
            other.gameObject.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionX;
        }
    }
   private void OnTriggerExit2D(Collider2D other)
    {
       if(other.gameObject.name == "Torch")besideTorch = false;
        if (other.gameObject.tag == "Key") besideKey = false;
        if (other.gameObject.name == "TikiTorch" || other.gameObject.name == "TikiTorchLeft" || other.gameObject.name == "TikiTorchRight")besideTikiTorch = false;
       if(other.gameObject.name == "Statue")besideStatue = false;
        if(other.gameObject.name == "door")besideDoor = false;
        if (other.gameObject.tag == "Block")
        {
            besideBlock = false;
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
