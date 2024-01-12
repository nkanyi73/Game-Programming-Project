using UnityEngine;

public class RotatingHallwayAntiClockwise : MonoBehaviour
{
    public GameObject hallway;
    public float rotationSpeed = 45f;

    private bool inTrigger = false;
    private float totalRotation = 0f;
    public AudioSource audioSource;
    private GameObject xrOrigin;
    private Transform xrInteractionSetup;

    private void Start()
    {
        xrOrigin = GameObject.FindGameObjectWithTag("Player");
        xrInteractionSetup = xrOrigin.transform.parent;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lever")
        {
            inTrigger = true;
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (inTrigger)
        {
            RotateObject();
        }
    }

    void RotateObject()
    {
        xrOrigin.transform.SetParent(hallway.transform);
        
        float rotationAmount = -rotationSpeed * Time.deltaTime;

        // Rotate the object
        hallway.transform.Rotate(0f, 0f, rotationAmount);

        // Update the total rotation
        totalRotation += Mathf.Abs(rotationAmount);

        // Check if the rotation has reached 90 degrees
        if (totalRotation >= 90f)
        {
            // Stop rotation
            inTrigger = false;
            totalRotation = 0f;
        }
        xrOrigin.transform.SetParent(xrInteractionSetup);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Lever")
    //    {
    //        inTrigger = false;
    //        totalRotation = 0f;
    //    }
    //}
}
