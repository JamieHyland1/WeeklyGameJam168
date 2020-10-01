using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    
    void Update()
    {
          //Detect when the Return key is pressed down
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.GetComponent<LevelLoader>().LoadNextLevel();
        }
    }
}
