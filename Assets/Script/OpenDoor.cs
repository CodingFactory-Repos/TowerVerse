using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        // Turn door 90 degrees on the y axis
        door.transform.Rotate(0, 90, 0);

        // Move door to the right
        door.transform.position = new Vector3(door.transform.position.x + 1.5f, door.transform.position.y, door.transform.position.z);
    }
}
