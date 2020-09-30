using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
   public PlayerInteract player1;
   public PlayerInteract player2;
   public CheckTorches checkTorches;

   private void Update(){
       
       if(player1.besideDoor && player2.besideDoor){
           if(checkTorches.BothTorchesLit()){
               this.GetComponent<LevelLoader>().LoadNextLevel();
           }
       }
   }
}
