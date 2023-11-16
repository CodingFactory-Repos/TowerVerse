using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public float weaponDamage = 10;
    public Collider weaponCol;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.gameObject);
        if (other.tag == "enemies")
        {
            Debug.Log("hit -10hp");
        }
    }
}
