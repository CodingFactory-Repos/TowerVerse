using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable
{
    public GameObject door;

    public string GetDescription()
    {
        return "Open Door";
    }

    public void Interact()
    {
        // Turn door 90 degrees on the y axis
        door.transform.Rotate(0, -90, 0);

        // Move door to the left
        door.transform.position = new Vector3(door.transform.position.x - 1.5f, door.transform.position.y, door.transform.position.z);
    }
}
