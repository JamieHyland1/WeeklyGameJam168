using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedPlatform : MonoBehaviour
{
   
  
  Animator animator;
  public Animator heroAnimator;


  [Range(0f,5f)]  public float secondsTillFlipToSpikes = 1f;
  [Range(0,5f)]    public float secondsTillFlipToFloor = 1f;
  void Awake()
    {
        animator = this.GetComponent<Animator>();
        StartCoroutine("Rotate");
  }

  IEnumerator Rotate(){
        while(true){
             yield return new WaitForSeconds(secondsTillFlipToSpikes);
            animator.SetBool("platformFlipped",true);
            yield return new WaitForSeconds(secondsTillFlipToFloor);
            animator.SetBool("platformFlipped",false);
        }
  }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<MoveController>().registerHit();
        }
  }
}
