using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    Animator animator;
    public Transform respawnPoint;

    private void Awake() {
        animator = this.GetComponent<Animator>();    
    }
 public void registerHit(){
        animator.SetTrigger("hitBySpike");
        Debug.Log("registering hit");
        animator.SetTrigger("hitBySpike");
        this.transform.position = respawnPoint.position;
    }
}
