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
                new ContainerPart{ Id=1, XCoordinate= 0, YCoordinate= 0, Height= 12, Width= 100 },
                new ContainerPart{ Id=2, XCoordinate= 0, YCoordinate= 13, Height= 12, Width= 45 },
                new ContainerPart{ Id=3, XCoordinate= 50, YCoordinate= 13, Height= 12, Width= 15 },
                new ContainerPart{ Id=4, XCoordinate= 0, YCoordinate= 26, Height= 10, Width= 10 },
                new ContainerPart{ Id=5, XCoordinate= 12, YCoordinate= 26, Height= 10, Width= 10 },
                new ContainerPart{ Id=6, XCoordinate= 24, YCoordinate= 26, Height= 10, Width= 10 },
                new ContainerPart{ Id=7, XCoordinate= 36, YCoordinate= 26, Height= 10, Width= 10 },
                new ContainerPart{ Id=8, XCoordinate= 48, YCoordinate= 26, Height= 10, Width= 10 },
                new ContainerPart{ Id=9, XCoordinate= 0, YCoordinate= 40, Height= 30, Width= 100 }
                };
        GameObject gameObject = GameObject.Find(s);
        
        
        foreach (ContainerPart cp in cplist)
        {
            GameObject cube = new GameObject("ContainerPartMesh"); //GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = gameObject.transform;
            cube.transform.position = gameObject.transform.position + new Vector3(cp.XCoordinate *5 ,0, cp.YCoordinate *5 );
            cube.transform.localScale = new Vector3(0.1f * cp.Width, 0.01f, 0.1f *cp.Height);
            cube.SetActive(true);
            
        }
    }

    private void GetTasks()
    {
        
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
