using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHolder : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(MainHolder.instance.currentScene == 1)
            {
                MainHolder.instance.startStage(2);
            }
   
        }
    }
}
