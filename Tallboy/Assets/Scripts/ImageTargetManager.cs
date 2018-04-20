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

    GameObject titleTextField;
    GameObject descriptionTextField;

    bool tracked;
    string targetName;
    
    public Transform containerPart;

    // Use this for initialization
    void Start () {

        mTrackableBehaviour = GetComponent<ImageTargetBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        titleTextField = GameObject.Find("Title");
        descriptionTextField = GameObject.Find("Description");
        presenter = new Presenter();
    }
	
	// Update is called once per frame
	void Update () {
        if (tracked)
        {

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
        }
    }

    

    public void AddCubesToImageTarget(string s)
    {
        List<ContainerPart> cplist = presenter.GetContainerParts(s);
        GameObject gameObject = GameObject.Find(s);

        foreach (ContainerPart cp in cplist)
        {
            //change 46 to container.QRsize which is the size of the printed QRcode in the real world given in mm 
            var qrSize = 46.0f;
            float width = cp.Width / qrSize * gameObject.transform.localScale.x;
            float height = cp.Height / qrSize * gameObject.transform.localScale.z;

            float x= cp.XCoordinate / qrSize * gameObject.transform.localScale.x;
            float y= cp.YCoordinate / qrSize * gameObject.transform.localScale.z;

            //
            float transformX = x + (width/ 2) - gameObject.transform.localScale.x/2;
            float transformY= y + (height/ 2) - gameObject.transform.localScale.x / 2;

            //create cube with the given transform coordinates
            Transform transform = Instantiate(containerPart, new Vector3(transformX,-2,transformY), Quaternion.identity);  //GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            Debug.Log("x scale: " + transform.localScale.x);
            Debug.Log("width : " + width);
            Debug.Log("heigh: " + height);

            //Set the scale of the cube
            transform.localScale = new Vector3(width, 5.0f  ,height);
            transform.Rotate(new Vector3(1, 0, 0));
            
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
