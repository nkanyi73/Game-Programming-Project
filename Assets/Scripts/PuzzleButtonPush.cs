using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtonPush : MonoBehaviour
{
    public ButtonPressCheck buttonPressCheck;
    public void Push(int buttonID)
    {
        buttonPressCheck.buttonOrder.Add(buttonID);
    }
}
