using System;
using System.Collections;
using System.Collections.Generic;
using TallboyBLL.Models;
using TallboyBLL.Presenter;
using UnityEngine;

public class MyGameManager : MonoBehaviour {
    Presenter presenter;

    GameObject titleTextField;
    GameObject descriptionTextField;
    GameObject taskTitleTextField;
    GameObject taskDescriptionTextField;

    bool tracked;

    ContainerPart currentContainerPart;
    public Material red;
    public Material green;

    public Transform containerPart;
    Dictionary<int, Renderer> containerPartMeshes;
    int currentElement;

    GameObject parent;

    Dictionary<int, GameObject> PCBparts;

    //TEST parameter
    int testcounter;

    void Start()
    {
        presenter = Presenter.GetPresenter();
        presenter.Start();

        tracked = false;
        titleTextField = GameObject.Find("Title");
        descriptionTextField = GameObject.Find("Description");
        taskTitleTextField = GameObject.Find("TaskTitle");
        taskDescriptionTextField = GameObject.Find("TaskDescription");
        containerPartMeshes = new Dictionary<int, Renderer>();
        PCBparts = new Dictionary<int, GameObject>();
        initPCBparts();

        testcounter = 0;
    }

    private void initPCBparts()
    {
        PCBparts.Add(1, GameObject.Find("IC"));
        PCBparts.Add(2, GameObject.Find("resistor1"));

        for(int i=1; i<PCBparts.Count+1; i++)
        {
            PCBparts[i].SetActive(false);
        }
        currentElement = 0;
    }

    private void Update()
    {
        if (tracked)
        {
            if (presenter.containerPartChanged)
            {
                UpdateDescriptionTextField(presenter.currentTaskElement.Description);
                UpdateTitleTextField(presenter.currentTaskElement.Name);
                if (currentContainerPart != null)
                {
                    containerPartMeshes[currentContainerPart.Id].material = green;
                }
                currentContainerPart = presenter.currentContainerPart;
                containerPartMeshes[currentContainerPart.Id].material = red;
                presenter.containerPartChanged = false;
            }
        }
        testcounter++;
        if(testcounter > 200)
        {
            OnNextButtonPressed();
            testcounter = 0;
        }
    }

    void OnNextButtonPressed()
    {
        presenter.TaskElementDone();

        if (PCBparts.ContainsKey(currentElement))
        {
            PCBparts[currentElement].SendMessageUpwards("StopMove", SendMessageOptions.DontRequireReceiver);
        }
        currentElement++;

        if (PCBparts.ContainsKey(currentElement))
        {
            PCBparts[currentElement].SetActive(true);
            PCBparts[currentElement].SendMessageUpwards("StartMove", SendMessageOptions.DontRequireReceiver);
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

    public void OnContainerFound(string targetName)
    {
        taskTitleTextField.GetComponent<TextMesh>().text = presenter.currentTask.Name;
        taskDescriptionTextField.GetComponent<TextMesh>().text = presenter.currentTask.Description;
        AddCubesToImageTarget(targetName);
        tracked = true;
    }

    public void TypeFound(string targetName)
    {
        presenter.TypeFound(targetName);
    }

    public void AddCubesToImageTarget(string s)
    {
        Debug.Log("Generate !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        if (s == "20ede1ea-44bc-4cc9-9000-94bdc66cc5b0")
        {
            List<ContainerPart> cplist = presenter.GetContainerParts(s);
            GameObject imageTargetObject = GameObject.Find(s);

            var qrSize = imageTargetObject.transform.localScale.x;

            parent = new GameObject("parent");
            parent.transform.parent = imageTargetObject.transform;
            parent.transform.localPosition = Vector3.zero;
            parent.transform.localRotation = Quaternion.identity;
            parent.transform.localScale = Vector3.one;

            foreach (ContainerPart cp in cplist)
            {

                float width = cp.Width / qrSize;
                float height = cp.Height / qrSize;

                float x = cp.XCoordinate;
                float y = cp.YCoordinate;

                var newPos = parent.transform.forward * (cp.YCoordinate + cp.Height / 2 - qrSize / 2) + parent.transform.right * (cp.XCoordinate + cp.Width / 2 - qrSize / 2) + parent.transform.position;
                //
                float transformX = x + parent.transform.position.x + cp.Width / 2 - qrSize / 2;
                float transformY = y + parent.transform.position.y + cp.Height / 2 - qrSize / 2;

                //create cube with the given transform coordinates
                Transform transform2 = Instantiate(containerPart, newPos, Quaternion.identity);  //GameObject.CreatePrimitive(PrimitiveType.Cube);

                //  transform2.up = parent.transform.forward;
                transform2.SetParent(parent.transform);
                transform2.localRotation = Quaternion.Euler(90f, 0f, 0f);
                // transform2.localRotation = Quaternion.identity;
                // transform2.localPosition = new Vector3(transformX, transformY, 0);

                //transform2.GetComponent<Renderer>().material
                //Debug.Log("Containerpart ID: " + cp.Id + " created");
                //Debug.Log("width : " + width);
                //Debug.Log("heigh: " + height);

                //Set the scale of the cube
                transform2.localScale = new Vector3(width, height, 0.005f);
                //transform.Rotate(new Vector3(1, 0, 0));

                //add to ContainerPartMesh
                containerPartMeshes.Add(cp.Id, transform2.GetComponent<Renderer>());
                presenter.containerPartChanged = true;
            }
            taskTitleTextField.transform.parent = parent.transform;
            taskTitleTextField.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
            taskTitleTextField.transform.localPosition = new Vector3(-3f, 0, 2.4f);

            taskDescriptionTextField.transform.parent = parent.transform;
            taskDescriptionTextField.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
            taskDescriptionTextField.transform.localPosition = new Vector3(-3.0f, 0, 2.0f);

            descriptionTextField.transform.parent = parent.transform;
            descriptionTextField.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
            descriptionTextField.transform.localPosition = new Vector3(3.5f, 0, 2.0f);

            titleTextField.transform.parent = parent.transform;
            titleTextField.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
            titleTextField.transform.localPosition = new Vector3(3.5f, 0, 2.4f);

            GameObject taskPlane = GameObject.Find("TaskPlane");
            GameObject plane = GameObject.Find("Plane");
            GameObject cylinder = GameObject.Find("Cylinder");

            taskPlane.transform.parent = parent.transform;
            taskPlane.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            taskPlane.transform.localPosition = new Vector3(4.3875f, -0.125f, 1.355f);

            plane.transform.parent = parent.transform;
            plane.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            plane.transform.localPosition = new Vector3(-2.425f, -0.125f, 1.355f);

            cylinder.transform.parent = parent.transform;
            cylinder.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
            cylinder.transform.localPosition = new Vector3(6.325f, 2.5f, -0.345f);

            parent.transform.parent = null;
        }
    }

}
