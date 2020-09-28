using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
  public Vector3 startPos;
  public Vector3 endPos;

  [Range(1f,10f)] public float moveSpeed =1f;

  void Awake(){
     StartCoroutine("Move");
  }




//An IEnumerator is like a loop that will give control back to unity at certain points, bassically this function
//runs forever, but everytime it hits the 'yield return null' it pauses itself for a little bit, and allows unity to 
//do other stuff such as update characters and whatnot
  IEnumerator Move(){
      while(true){
          //if the platform reaches its goal swap the end and start goal so it starts moving again
          if(Vector3.Distance(this.transform.position,endPos) < 0.001f){
              Vector3 temp = startPos;
              startPos = endPos;
              endPos = temp;
          }
          //Lerp towards the endPos at the desired speed
          if(Vector3.Distance(this.transform.position, endPos) > 0.0001f){
              Vector3 newPos = this.transform.position;
              newPos = Vector3.MoveTowards(newPos,endPos,moveSpeed*Time.deltaTime);
              
              transform.position = newPos;
          }
          yield return null;
      }
  }
}
