using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotatingHallway : MonoBehaviour
{
    public GameObject hallway;
    public float rotationSpeed = 30f; // Rotation speed in degrees per second
    public AudioSource audioSource;

    private bool isRotating = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hallway Collision");
        if (!isRotating)
        {
            StartCoroutine(RotateCoroutine());
        }

    }
    IEnumerator RotateCoroutine()
    {
        audioSource.Play();
        isRotating = true;

        float targetAngle = hallway.transform.eulerAngles.y + 90f;

        while (hallway.transform.eulerAngles.y < targetAngle)
        {
            float rotationAngle = rotationSpeed * Time.deltaTime;
            hallway.transform.Rotate(0f, 0f, rotationAngle);
            Debug.Log(hallway.transform.eulerAngles);
            yield return null; // Wait for the end of the frame
        }

        isRotating = false;
    }
}
