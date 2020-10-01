using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRayCheck : MonoBehaviour
{
   public GameObject magicRay;
   private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Player"){
           if(other.GetComponent<MoveController>().holdingTorch){Debug.Log("Torch entered");
           magicRay.GetComponent<Animator>().SetTrigger("Fade");}
       }
   }
   private void OnTriggerExit2D(Collider2D other) {
       if(other.tag == "Player"){
           if(other.GetComponent<MoveController>().holdingTorch){Debug.Log("Torch Left");
           magicRay.GetComponent<Animator>().SetTrigger("Fade");}
       }
   }
}
