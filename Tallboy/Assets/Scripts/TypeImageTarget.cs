using System.Collections;
using System.Collections.Generic;
using TallboyBLL.Presenter;
using UnityEngine;
using Vuforia;

public class TypeImageTarget : MonoBehaviour, ITrackableEventHandler{
    private TrackableBehaviour mTrackableBehaviour;
    private bool tracked;
    Presenter presenter;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED && !tracked)
        {
            Debug.Log("targetName: " + mTrackableBehaviour.TrackableName);
            Debug.Log("name: " + mTrackableBehaviour.name);
            presenter.TypeFound(mTrackableBehaviour.TrackableName);
        }
    }

    // Use this for initialization
    void Start () {
        mTrackableBehaviour = GetComponent<ImageTargetBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        presenter= Presenter.GetPresenter();
        tracked = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
