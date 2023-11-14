using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButton(0)) {
            transform.eulerAngles += Speed * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
       } 
    }

    void FixedUpdate() {
        transform.Translate(Vector3.forward * 2f * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
    }
}
