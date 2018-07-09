using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentReadySphere : MonoBehaviour {

    public Material red;

    public Material green;

	// Use this for initialization
	void Start () {
        gameObject.transform.GetComponent<Renderer>().material = red;
	}
	
    void SetMaterial(int material)
    {
        if(material == 0)
        {
            gameObject.transform.GetComponent<Renderer>().material = red;
        }
        if (material == 1)
        {
            gameObject.transform.GetComponent<Renderer>().material = green;
        }
    }
}
