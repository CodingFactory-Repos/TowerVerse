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
            else if (MainHolder.instance.currentScene == 2)
            {
                MainHolder.instance.startStage(3);
            }
            else if (MainHolder.instance.currentScene == 3)
            {
                MainHolder.instance.startStage(4);
            }
        }
    }
}
