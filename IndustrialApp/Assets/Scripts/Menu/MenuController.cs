using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    GameObject camera;

    public void Start()
    {
        camera = GameObject.Find("MixedRealityCamera");
    }
    public void OnPCBButtonPressed()
    {
        SceneManager.LoadScene("FirstScene", LoadSceneMode.Single);
    }

    private void Update()
    {
        gameObject.transform.localPosition = camera.transform.localPosition;
    }
}
