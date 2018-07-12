using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Vuforia;
using System;
using IndustrialApp.Presenter;

public class ImageTargetManager : MonoBehaviour, ITrackableEventHandler{
    private TrackableBehaviour mTrackableBehaviour;
    public Presenter presenter;

    bool tracked;
    string targetName;
    GameObject myGameManager;
    // Use this for initialization
    void Start () {
        tracked = false;
        myGameManager = GameObject.Find("GameManager");
        mTrackableBehaviour = GetComponent<ImageTargetBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }



    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if(newStatus == TrackableBehaviour.Status.TRACKED && !tracked)
        {
            targetName = mTrackableBehaviour.name;
            Debug.Log("targetName: "+ mTrackableBehaviour.TrackableName);
            Debug.Log("name: "+ mTrackableBehaviour.name);

            
            tracked = true;
            
            myGameManager.SendMessageUpwards("TypeFound", targetName, SendMessageOptions.DontRequireReceiver);
            myGameManager.SendMessageUpwards("OnContainerFound",targetName ,SendMessageOptions.DontRequireReceiver); 
        }
        if(newStatus == TrackableBehaviour.Status.TRACKED)
        {
            Debug.Log("targetName: " + mTrackableBehaviour.TrackableName);
            Debug.Log("name: " + mTrackableBehaviour.name);
            myGameManager.SendMessageUpwards("UpdateContainer", targetName, SendMessageOptions.DontRequireReceiver);
        }
    }


    private string GetDescription()
    {
        return "";
    }


}
