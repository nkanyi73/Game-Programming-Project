using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotatingHallway : MonoBehaviour
{
    public GameObject hallway;
    public float rotationSpeed = 30f; // Rotation speed in degrees per second
    public AudioSource audioSource;
    private GameObject xrOrigin;
    private Transform xrInteractionSetup;
    public bool isClockwise;

    private bool isRotating = false;
    private void Start()
    {
        xrOrigin = GameObject.FindGameObjectWithTag("Player");
        xrInteractionSetup = xrOrigin.transform.parent;
        Debug.Log("Starting Position:" + hallway.transform.eulerAngles);
    }
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
        xrOrigin.transform.SetParent(hallway.transform);
        audioSource.Play();
        isRotating = true;
        float currentAngle = hallway.transform.eulerAngles.y;
        currentAngle = (currentAngle + 360) % 360;

        float targetAngle = isClockwise
            ? (currentAngle + 90f) % 360f
            : (currentAngle - 90f + 360f) % 360f;

        Debug.Log("Target Angle:" + targetAngle);
        while (isClockwise ? (hallway.transform.eulerAngles.y < targetAngle) : (hallway.transform.eulerAngles.y > targetAngle))
        {
            float rotationAngle = rotationSpeed * Time.deltaTime * (isClockwise ? 1f : -1f);
            hallway.transform.Rotate(0f, 0f, rotationAngle);
            Debug.Log(hallway.transform.eulerAngles);
            yield return null; // Wait for the end of the frame
        }

        //hallway.transform.eulerAngles = new Vector3(0f, 0f, targetAngle);


        xrOrigin.transform.SetParent(xrInteractionSetup);
        isRotating = false;
    }
}
