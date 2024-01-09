using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControl : MonoBehaviour
{
    public GameObject[] torches;
    // Start is called before the first frame update
    void Start()
    {
        //torches = GameObject.FindGameObjectsWithTag("Hallway Torch");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        //if (other.CompareTag("Torch"))
        {
            foreach (var item in torches)
            {
                item.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
