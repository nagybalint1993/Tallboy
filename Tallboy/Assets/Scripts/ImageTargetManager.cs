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
    Presenter presenter;
    List<string> imageTargets;

    GameObject titleTextField;
    GameObject descriptionTextField;

    bool tracked;
    string targetName;

    ContainerPart currentContainerPart;
    
    public Transform containerPart;
    List<ContainerPartMesh> containerPartMeshes;

    // Use this for initialization
    void Start () {
        mTrackableBehaviour = GetComponent<ImageTargetBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        tracked = false;
        titleTextField = GameObject.Find("Title");
        descriptionTextField = GameObject.Find("Description");
        presenter = new Presenter();
        presenter.Start();
        imageTargets = new List<String>();
        containerPartMeshes = new List<ContainerPartMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (tracked)
        {
            UpdateDescriptionTextField(presenter.currentTaskElement.Description);
            UpdateTitleTextField(presenter.currentTaskElement.Name);

            if (presenter.containerPartChanged)
            {
                currentContainerPart = presenter.currentContainerPart;
                containerPartMeshes.Where(cp => cp.ID == currentContainerPart.Id).FirstOrDefault();
                
            }
        }

	}

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if(newStatus == TrackableBehaviour.Status.TRACKED && !tracked)
        {
            targetName = mTrackableBehaviour.name;
            Debug.Log("targetName: "+ mTrackableBehaviour.TrackableName);
            Debug.Log("name: "+ mTrackableBehaviour.name);

            AddCubesToImageTarget(targetName);
            presenter.TypeFound(targetName);
            tracked = true;
        }
        if(newStatus == TrackableBehaviour.Status.TRACKED)
        {
            presenter.TypeFound(targetName);
        }
    }

    

    public void AddCubesToImageTarget(string s)
    {
        Debug.Log("Generate !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        if(s == "20ede1ea-44bc-4cc9-9000-94bdc66cc5b0")
        {
            List<ContainerPart> cplist = presenter.GetContainerParts(s);
            GameObject imageTargetObject = GameObject.Find(s);
        
            var qrSize = imageTargetObject.transform.localScale.x;

            GameObject parent = new GameObject("parent");
            parent.transform.parent = imageTargetObject.transform;
            parent.transform.localPosition = Vector3.zero;
            parent.transform.localRotation = Quaternion.identity;
            parent.transform.localScale = Vector3.one;

            foreach (ContainerPart cp in cplist)
            {
          
                float width = cp.Width / qrSize;
                float height = cp.Height / qrSize;

                float x= cp.XCoordinate;
                float y= cp.YCoordinate;

                var newPos = parent.transform.forward * (cp.YCoordinate + cp.Height / 2 - qrSize / 2) + parent.transform.right * (cp.XCoordinate + cp.Width / 2 - qrSize / 2) + parent.transform.position;
                //
                float transformX = x + parent.transform.position.x + cp.Width/2 - qrSize/2;
                float transformY= y + parent.transform.position.y + cp.Height/2 - qrSize/2;

                //create cube with the given transform coordinates
                Transform transform2 = Instantiate(containerPart, newPos, Quaternion.identity);  //GameObject.CreatePrimitive(PrimitiveType.Cube);

              //  transform2.up = parent.transform.forward;
                transform2.SetParent(parent.transform);
                transform2.localRotation = Quaternion.Euler(90f,0f,0f);

                // transform2.localRotation = Quaternion.identity;
                // transform2.localPosition = new Vector3(transformX, transformY, 0);

                //transform2.GetComponent<Renderer>().material


                //Debug.Log("Containerpart ID: " + cp.Id + " created");
                //Debug.Log("width : " + width);
                //Debug.Log("heigh: " + height);

                //Set the scale of the cube
                transform2.localScale = new Vector3(width,height, 0.005f);
                //transform.Rotate(new Vector3(1, 0, 0));

                //add to ContainerPartMesh
                containerPartMeshes.Add(new ContainerPartMesh(transform2, cp.Id));
            }
        }



    }

    private void GetTasks(List<TallboyBLL.Models.Task> tasks)
    {
        if(tasks!= null)
        {
            UpdateDescriptionTextField(tasks[0].Name + "\n" + tasks[0].Description);
        }
        else
        {
            UpdateDescriptionTextField("no task");
        }
    }

    private string GetDescription()
    {
        return "";
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
