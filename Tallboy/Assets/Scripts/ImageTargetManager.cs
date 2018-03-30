using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Vuforia;
using System;
using TallboyBLL;

public class ImageTargetManager : MonoBehaviour, ITrackableEventHandler{
    GameObject[] cubes;
    int count;
    int cubeNumber;
    private TrackableBehaviour mTrackableBehaviour;
    bool tracked;
    bool initTime;
    GameObject titleTextField;
    GameObject descriptionTextField;
    Interactor interactor;
    TallboyBLL.Models.Material currentMaterial;

    // Use this for initialization
    void Start () {
        cubes = GameObject.FindGameObjectsWithTag("Cube").OrderBy(go => go.name).ToArray<GameObject>();
        //foreach(GameObject o in cubes){
        //    o.SetActive(false);
        //}
        mTrackableBehaviour = GetComponent<ImageTargetBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        titleTextField = GameObject.Find("Title");
        descriptionTextField = GameObject.Find("Description");
        initTime = false;
        interactor = new Interactor();
    }
	
	// Update is called once per frame
	void Update () {
        if (tracked)
        {
            if (initTime) {
                count++;
                if (count >= 150)
                {
                    foreach (GameObject o in cubes)
                    {
                        o.SetActive(false);
                    }
                    initTime = false;
                    count = 0;
                }
            }
            else
            {
                UpdateDescriptionTextField(GetDescription());
                count++;
                if (count >= 30)
                {
                    ChangeCubeActive(interactor.currentMaterial.LocationId);
                    count = 0;
                }
            }
        }
        
	}

    private void ChangeCubeActive(int id)
    {
        cubes[id].SetActive(!cubes[id].active);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if(newStatus == TrackableBehaviour.Status.TRACKED && !tracked)
        {
            count = 0;
            cubeNumber = 0;
            cubes[0].SetActive(true);
            UpdateTitleTextField("Fiok " + (cubeNumber + 1).ToString());
            tracked = true;
            initTime = true;
            GetTasks();
        }
    }

    private void GetTasks()
    {
        interactor.TryToGetTasks();
    }

    private string GetDescription()
    {
        if (interactor.currentMaterial != null)
        {
            string s = interactor.currentMaterial.Name + "\n" + interactor.currentMaterial.Description;
            return s;
        }
        else
        {
            return interactor.description;
        }

    }

    public void UpdateTitleTextField(string s)
    {
        titleTextField.GetComponent<TextMesh>().text = s;
    }

    public void UpdateDescriptionTextField(string s)
    {
        descriptionTextField.GetComponent<TextMesh>().text = s;
    }
}
