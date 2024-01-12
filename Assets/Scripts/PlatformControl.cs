using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    public GameObject leftGate;
    public GameObject rightGate;
    private List<Vector3> leftPositions = new List<Vector3>();
    private List<Vector3> rightPositions = new List<Vector3>();
    private int numberOfBarrels;
    public AudioSource source;

    private void Start()
    {
        leftPositions.Add(leftGate.transform.position);
        rightPositions.Add(rightGate.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    Debug.Log("Player detected");
        //}
        if (other.CompareTag("Barrel"))
        {
            if(numberOfBarrels == 0)
            {

            }
            numberOfBarrels++;
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                source.Play();
                // Access the mass property of the Rigidbody
                float mass = rb.mass;
                leftGate.transform.position -= new Vector3(0f, 0f, mass * 5.0f) * 0.2f * Time.deltaTime;
                leftPositions.Add(leftGate.transform.position);  
                rightGate.transform.position += new Vector3(0f, 0f, mass * 5.0f) * 0.2f * Time.deltaTime;
                rightPositions.Add(rightGate.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Barrel"))
        {
            source.Play();
            if (numberOfBarrels == 1)
            {
                leftGate.transform.position = leftPositions[numberOfBarrels - 1];
                rightGate.transform.position = rightPositions[numberOfBarrels - 1];
                leftPositions.RemoveAt(numberOfBarrels);
                rightPositions.RemoveAt(numberOfBarrels);
            }
            else
            {

                leftGate.transform.position = leftPositions[numberOfBarrels - 2];
                rightGate.transform.position = rightPositions[numberOfBarrels - 2];
                leftPositions.RemoveAt(numberOfBarrels - 1);
                rightPositions.RemoveAt(numberOfBarrels - 1);
            }
            
            numberOfBarrels--;
        }
    }
}
