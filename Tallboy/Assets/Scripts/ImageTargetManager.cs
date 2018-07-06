using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Vuforia;
using System;
using TallboyBLL;
using TallboyBLL.Models;
using TallboyBLL.Controllers;
using TallboyBLL.Presenter;

public class ImageTargetManager : MonoBehaviour, ITrackableEventHandler{
    private TrackableBehaviour mTrackableBehaviour;
    public Presenter presenter;

    bool tracked;
    string targetName;

    // Use this for initialization
    void Start () {
        tracked = false;
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
            GameObject myGameManager = GameObject.Find("GameManager");
            myGameManager.SendMessageUpwards("TypeFound", targetName, SendMessageOptions.DontRequireReceiver);
            myGameManager.SendMessageUpwards("OnContainerFound",targetName ,SendMessageOptions.DontRequireReceiver); 
        }
        if(newStatus == TrackableBehaviour.Status.TRACKED)
        {
            Debug.Log("targetName: " + mTrackableBehaviour.TrackableName);
            Debug.Log("name: " + mTrackableBehaviour.name);
        }
    }


    private string GetDescription()
    {
        return "";
    }


}
