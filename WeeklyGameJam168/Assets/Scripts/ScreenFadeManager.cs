using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFadeManager : MonoBehaviour
{
   public GameObject firstScreen;
   public GameObject secondScreen;
   public void FlipScreens()
    {
           firstScreen.GetComponent<Animator>().SetTrigger("Fade");
           secondScreen.GetComponent<Animator>().SetTrigger("Fade");
   }
}
