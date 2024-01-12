using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControl : MonoBehaviour
{
    public GameObject[] torches;
    public GameObject[] hallway;
    // Start is called before the first frame update
    void Start()
    {
        //torches = GameObject.FindGameObjectsWithTag("Hallway Torch");
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform.parent);
        //if (other.CompareTag("Torch"))
        {
            foreach (var item in torches)
            {
                item.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var item in torches)
        {
            item.SetActive(false);
        }
    }

  
}
