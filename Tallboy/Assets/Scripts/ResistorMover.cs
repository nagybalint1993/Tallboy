using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistorMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject gameObject = GameObject.Find("resistor1");
        iTween.MoveBy(gameObject, iTween.Hash("y", 0.02f, "easeType", "easeInOutQuad", "loopType", "pingPong", "delay", .5));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
