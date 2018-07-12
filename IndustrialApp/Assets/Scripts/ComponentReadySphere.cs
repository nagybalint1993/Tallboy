using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentReadySphere : MonoBehaviour {

    public Material red;

    public Material green;

    Vector3 initScale;

	// Use this for initialization
	void Start () {
        gameObject.transform.GetComponent<Renderer>().material = red;
        initScale = gameObject.transform.localScale;
	}
	
    void SetMaterial(int material)
    {
        if(material == 0)
        {
            gameObject.transform.GetComponent<Renderer>().material = red;
            //iTween.ScaleBy(gameObject, iTween.Hash( "amount", new Vector3(0.5f, 0.5f, 0.5f), "time", 0.5, "looptype", "pingPong"));
        }
        if (material == 1)
        {
            gameObject.transform.GetComponent<Renderer>().material = green;
            
            //  gameObject.transform.localScale = initScale;
        }
    }
}
