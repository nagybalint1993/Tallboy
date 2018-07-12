using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonManager : MonoBehaviour {

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        GameObject.Find("GameManager").SendMessageUpwards("OnNextButtonPressed", SendMessageOptions.DontRequireReceiver);
    }
}
