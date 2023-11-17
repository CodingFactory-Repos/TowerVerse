using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDoor : MonoBehaviour
{

    void Start(){


    }

    private void OnTriggerEnter(Collider other) {
       Debug.Log("Collision" + other.gameObject.tag); 
       SceneManager.LoadScene("SampleScene");
    }
}
