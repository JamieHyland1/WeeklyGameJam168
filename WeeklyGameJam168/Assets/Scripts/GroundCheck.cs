using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public int numChecks = 3;
    public int checkCounter = 0;
    void OnCollisionEnter2D(Collision2D col){
       
        checkCounter++;
        if(checkCounter == numChecks)this.GetComponentInParent<MoveController>().onGround = true;
    }
    void OnCollisionExit2D(Collision2D col){
        checkCounter--;
        if(checkCounter <= 1)this.GetComponentInParent<MoveController>().onGround = false;
    }
}
