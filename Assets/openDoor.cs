using UnityEngine;

public class openDoor : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject doorLeft;
    public GameObject doorRight;
    private Collider detectPlayer;
    public Vector3 moveDirectionR = Vector3.right;
    public Vector3 moveDirectionL = Vector3.left;
    public bool resetDoor = false;
    // public float distance = 2f;


    void Start()
    {
        detectPlayer = GetComponent<Collider>();
    }

    private void Update()
    {
        if (resetDoor)
        {
            if (doorLeft.transform.position.x > -23.1)
            {
                Vector3 targetPositionR = doorLeft.transform.position + moveDirectionL;
                Vector3 targetPositionL = doorRight.transform.position + moveDirectionR;
                doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, targetPositionR, Time.deltaTime);
                doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, targetPositionL, Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 targetPositionR = doorLeft.transform.position + moveDirectionR;
        Vector3 targetPositionL = doorRight.transform.position + moveDirectionL;
        if (other.tag == "Player")
        {
            if (doorLeft.transform.position.x < -20)
            {
                doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, targetPositionR, Time.deltaTime);
                doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, targetPositionL, Time.deltaTime);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
        resetDoor = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            resetDoor = false;
        }
    }


}
