using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressCheck : MonoBehaviour
{
    private List<int> correctButtonOrder = new List<int> {2, 0, 1};
    public List<int> buttonOrder = new List<int>();
    public List<GameObject> gameObjects = new List<GameObject>();
    public Animator rightDoorAnimator;
    public Animator leftDoorAnimator;
    public AudioSource slidingDoor;
    public GameObject lever;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(buttonOrder.Count == 3)
    //    {
    //        List<int> tempButtonOrder = new List<int>(buttonOrder);
    //        buttonOrder.Clear();
    //        // Check each element to see if they match
    //        for (int i = 0; i < correctButtonOrder.Count; i++)
    //        {
    //            if (correctButtonOrder[i] != tempButtonOrder[i])
    //            {
    //                Debug.Log("Not successful");
    //                foreach (var item in gameObjects)
    //                {
    //                    item.SetActive(false);
    //                }
    //                break;
    //                //buttonOrder.Clear();
    //            }
    //        }
    //        Debug.Log("Successful");
    //        foreach (var item in gameObjects)
    //        {
    //            item.SetActive(false);
    //        }
    //        //buttonOrder.Clear();
    //    }
    //}

    void Update()
    {
        if (buttonOrder.Count == 3)
        {
            // Check if lists match in the Update loop
            bool listsMatch = AreListsEqual(correctButtonOrder, buttonOrder);

            // Output result
            if (listsMatch)
            {
                Debug.Log("Successful");
                foreach (var item in gameObjects)
                {
                    item.SetActive(false);
                }
                rightDoorAnimator.Play("RightDoorSlide");
                leftDoorAnimator.Play("LeftDoorSlide");
                slidingDoor.Play();
                lever.SetActive(true);
                buttonOrder.Clear();
            }
            else
            {
                Debug.Log("Not successful");
                foreach (var item in gameObjects)
                {
                    item.SetActive(false);
                }
                buttonOrder.Clear();
            }
        }
    }

    bool AreListsEqual(List<int> list1, List<int> list2)
    {
        // Check if lists have the same number of elements
        if (list1.Count != list2.Count)
        {
            return false;
        }

        // Check each element to see if they match
        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
            {
                return false;
            }
        }

        // If all elements match, return true
        return true;
    }
}
