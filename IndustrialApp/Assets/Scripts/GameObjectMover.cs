using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectMover : MonoBehaviour {

    Vector3 startPosition;

	void StartMove () {
        startPosition = gameObject.transform.position;
        iTween.MoveBy(gameObject, iTween.Hash("y", 0.02f, "easeType", "easeInOutQuad", "loopType", "pingPong", "delay", .5));
    }
	
	void StopMove()
    {
        iTween.Stop();
        gameObject.transform.position = startPosition;
    }
}
