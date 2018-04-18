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
    GameObject[] cubes;
    int count;
    int cubeNumber;
    private TrackableBehaviour mTrackableBehaviour;
    bool tracked;
    bool initTime;
    GameObject titleTextField;
    GameObject descriptionTextField;
    string targetName;
    Presenter presenter;
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
        initTime = false;

        presenter = new Presenter();
        TaskController tc = new TaskController();
        tc.GetTasksAsync(GetTasks);
    }
	
	// Update is called once per frame
	void Update () {
        if (tracked)
        {
        //    if (initTime) {
        //        count++;
        //        if (count >= 150)
        //        {
        //            foreach (GameObject o in cubes)
        //            {
        //                o.SetActive(false);
        //            }
        //            initTime = false;
        //            count = 0;
        //        }
        //    }
        //    else
        //    {
        //        UpdateDescriptionTextField(GetDescription());
        //        count++;
        //        if (count >= 30)
        //        {
                    
                    
        //        }
        //    }
        }
        
	}

    private void ChangeCubeActive(int id)
    {
        if(cubes != null)
        {
            cubes[id].SetActive(!cubes[id].active);
        }
        
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if(newStatus == TrackableBehaviour.Status.TRACKED && !tracked)
        {
            targetName = mTrackableBehaviour.name;
            count = 0;
            cubeNumber = 0;
            Debug.Log("targetName: "+ mTrackableBehaviour.TrackableName);
            Debug.Log("name: "+ mTrackableBehaviour.name);
            AddCubesToImageTarget(targetName);
            /*
            cubes[0].SetActive(true);
            UpdateTitleTextField("Fiok " + (cubeNumber + 1).ToString());
            tracked = true;
            initTime = true;
            GetTasks();*/
        }
    }

    

    public void AddCubesToImageTarget(string s)
    {
        //List<ContainerPart> cplist = presenter.GetContainerParts(s);
        List<ContainerPart> cplist = new List<ContainerPart> {
                new ContainerPart{ Id=1, XCoordinate= 0, YCoordinate= 0, Height= 55, Width= 270 },
                new ContainerPart{ Id=2, XCoordinate= 0, YCoordinate= 66, Height= 55, Width= 130 },
                new ContainerPart{ Id=3, XCoordinate= 140, YCoordinate= 66, Height= 55, Width= 130 },
                new ContainerPart{ Id=4, XCoordinate= 0, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=5, XCoordinate= 55, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=6, XCoordinate= 110, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=7, XCoordinate= 165, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=8, XCoordinate= 220, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=9, XCoordinate= 0, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=10, XCoordinate= 55, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=11, XCoordinate= 110, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=12, XCoordinate= 165, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=13, XCoordinate= 220, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=14, XCoordinate= 0, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=15, XCoordinate= 55, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=16, XCoordinate= 110, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=17, XCoordinate= 165, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=18, XCoordinate= 220, YCoordinate= 240, Height= 35, Width= 45 },
                };
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
            transform.Rotate(new Vector3(5, 0, 0));
            
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
