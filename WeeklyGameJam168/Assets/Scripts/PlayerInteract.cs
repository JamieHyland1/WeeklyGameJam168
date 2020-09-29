using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public bool besideTorch = false;
    public bool besideTikiTorch = false;
    public bool besideStatue = false;

   private void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.name == "Torch")besideTorch = true;
       if(other.gameObject.name == "TikiTorch")besideTikiTorch = true;
       if(other.gameObject.name == "Statue")besideStatue = true;
   }
   private void OnTriggerExit2D(Collider2D other) {
       if(other.gameObject.name == "Torch")besideTorch = false;
       if(other.gameObject.name == "TikiTorch")besideTikiTorch = false;
       if(other.gameObject.name == "Statue")besideStatue = false;
   }
}
