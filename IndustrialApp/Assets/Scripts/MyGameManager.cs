using System;
using System.Collections;
using System.Collections.Generic;
using IndustrialApp.Models;
using IndustrialApp.Presenter;
using UnityEngine;

public class MyGameManager : MonoBehaviour {
    Presenter presenter;

    GameObject titleTextField;
    GameObject descriptionTextField;
    GameObject taskTitleTextField;
    GameObject taskDescriptionTextField;
    GameObject readySphere;
    GameObject qrScanDialog;
    GameObject componentReadyParent;

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

        componentReadyParent = GameObject.Find("ComponentReadyParent");
        readySphere = GameObject.Find("ReadyRadialButton");
        titleTextField = GameObject.Find("SubtaskTitle");
        descriptionTextField = GameObject.Find("SubtaskDescription");
        taskTitleTextField = GameObject.Find("TaskTitle");
        taskDescriptionTextField = GameObject.Find("TaskDescription");
        containerPartMeshes = new Dictionary<int, Renderer>();
        PCBparts = new Dictionary<int, GameObject>();
        qrScanDialog = GameObject.Find("QRScanDialog");
        qrScanDialog.SetActive(false);
        initPCBparts();

        testcounter = 0;
    }

    private void initPCBparts()
    {
        PCBparts.Add(0, GameObject.Find("lapka"));
        PCBparts.Add(1, GameObject.Find("IC"));
        PCBparts.Add(2, GameObject.Find("capacitor1u"));
        PCBparts.Add(3, GameObject.Find("resistor474"));
        PCBparts.Add(4, GameObject.Find("polyfuse"));
        PCBparts.Add(5, GameObject.Find("capacitor100n"));
        PCBparts.Add(6, GameObject.Find("resistor220"));

        for (int i=1; i<PCBparts.Count; i++)
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
                OnContainerPartChanged();
            }
            if (presenter.TypeIsReady)
            {
                readySphere.SendMessageUpwards("SetMaterial", 1, SendMessageOptions.DontRequireReceiver);
            }
        }
        
        /*
        testcounter++;
        if(testcounter > 200)
        {
            OnNextButtonPressed();
            testcounter = 0;
            presenter.TypeIsReady = true;
        }
        */
    }

    public void OnContainerPartChanged()
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
        readySphere.SendMessageUpwards("SetMaterial", 0, SendMessageOptions.DontRequireReceiver);
        if(presenter.currentTaskElement.TypeId != 0)
        {
            componentReadyParent.SetActive(true);
        }
        else
        {
            componentReadyParent.SetActive(false);
            presenter.TypeIsReady = true;
        }
    }

    public void OnResetButtonPressed()
    {
        presenter.containerPartChanged = false;
        presenter.TypeIsReady = false;
        presenter.Start();
        for (int i = 1; i < PCBparts.Count; i++)
        {
            PCBparts[i].SetActive(false);
        }
        currentElement = 0;
    }

    public void OnNextButtonPressed()
    {
        if (presenter.TypeIsReady)
        {
            presenter.TaskElementDone();

            if (PCBparts.ContainsKey(currentElement))
            {
                PCBparts[currentElement].SendMessageUpwards("StopMove", SendMessageOptions.DontRequireReceiver);
            }

            //Aszinkronnál nem fog működni rendesen
            if(presenter.currentTaskElement.TypeId != 0)
            {
                currentElement++;
                if (PCBparts.ContainsKey(currentElement))
                {
                    PCBparts[currentElement].SetActive(true);
                    PCBparts[currentElement].SendMessageUpwards("StartMove", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        else
        {
            qrScanDialog.SetActive(true);
        }

    }

    public void OnBackButtonPressed()
    {
        presenter.DoPreviousTaskElement();
    }
        public void UpdateTitleTextField(string s)
    {
        titleTextField.GetComponent<TextMesh>().text = s;
    }

    public void UpdateDescriptionTextField(string s)
    {
        descriptionTextField.GetComponent<TextMesh>().text = SplitStringToLength(s,30);
    }

    public String SplitStringToLength(String s, int length)
    {
        String[] strings= s.Split(' ');
        string result = "";
        int counter = 0;
        foreach(String st in strings)
        {
            if(counter + st.Length < length)
            {
                result = result + st + " ";
                counter = counter + st.Length +1;
            }
            else
            {
                result = result + "\n" + st + " ";
                counter = st.Length +1;
            }
        }
        return result;
    }

    public void OnContainerFound(string targetName)
    {
        taskTitleTextField.GetComponent<TextMesh>().text = presenter.currentTask.Name;
        taskDescriptionTextField.GetComponent<TextMesh>().text = presenter.currentTask.Description;
        AddCubesToImageTarget(targetName);
        tracked = true;
    }

    public void UpdateContainer(string targetName)
    {
        if (targetName == "20ede1ea-44bc-4cc9-9000-94bdc66cc5b0")
        {
            GameObject imageTargetObject = GameObject.Find(targetName);
            parent.transform.parent = imageTargetObject.transform;
            parent.transform.localPosition = Vector3.zero;
            parent.transform.localRotation = Quaternion.identity;
            parent.transform.localScale = Vector3.one;
        }
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
            /*
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
            */
            GameObject taskPlane = GameObject.Find("TaskPlane");
            GameObject subtaskPlane = GameObject.Find("SubtaskPlane");
            GameObject cylinder = GameObject.Find("Cylinder");

            subtaskPlane.transform.parent = parent.transform;
            subtaskPlane.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            subtaskPlane.transform.localPosition = new Vector3(4.3875f, -0.125f, 0);

            taskPlane.transform.parent = parent.transform;
            taskPlane.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            taskPlane.transform.localPosition = new Vector3(-2.425f, -0.125f, 0);

            cylinder.transform.parent = parent.transform;
            cylinder.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
            cylinder.transform.localPosition = new Vector3(6.325f, 2.5f, -0.345f);

            parent.transform.parent = null;
        }
    }

}
