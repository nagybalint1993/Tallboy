using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPartMesh : MonoBehaviour{
    Material[] materials;
    Renderer rend;
    public Transform transform;
    public int ID;

    public ContainerPartMesh(Transform t, int id)
    {
        transform = t;
        ID = id;
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
    }
}
