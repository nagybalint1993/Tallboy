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
    GameObject titleTextField;
    GameObject descriptionTextField;
    Interactor interactor;
    TallboyBLL.Models.Material currentMaterial;

    // Use this for initialization
    void Start () {
        cubes = GameObject.FindGameObjectsWithTag("Cube").OrderBy(go => go.name).ToArray<GameObject>();
        foreach(GameObject o in cubes){
            o.SetActive(false);
        }
        mTrackableBehaviour = GetComponent<ImageTargetBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        titleTextField = GameObject.Find("Title");
        descriptionTextField = GameObject.Find("Description");

        interactor = new Interactor();
    }
	
	// Update is called once per frame
	void Update () {
        if (tracked)
        {
            count++;
            if ( count >= 90)
            {
                cubes[cubeNumber].SetActive(false);
                cubeNumber++;
                if(cubeNumber >= cubes.Length)
                {
                    cubeNumber = 0;
                }
                cubes[cubeNumber].SetActive(true);
                UpdateTitleTextField("Fiok " + (cubeNumber +1).ToString());
                count = 0;
            }
        }
        UpdateDescriptionTextField(GetDescription());
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
            ImageFoundEvent.OnEvent();
            GetTasks();
        }
    }

    private void GetTasks()
    {
        interactor.TryToGetTasks();
    }

    private string GetDescription()
    {
        //currentMaterial = interactor.currentMaterial;
        //if (currentMaterial != null)
        //{     
        //    string s = currentMaterial.Name + "\n" + currentMaterial.Description;
        //    return s;
        //}
        //else
        //{
            return interactor.description;
        //}

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
