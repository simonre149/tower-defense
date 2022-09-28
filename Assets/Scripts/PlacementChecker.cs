using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementChecker : MonoBehaviour
{
    public Material validMaterial, invalidMaterial;
    public bool canBePlaced = false;
    
    private void OnCollisionEnter(Collision collision)
    {
        canBePlaced = false;
        GetComponent<MeshRenderer>().material = invalidMaterial;
    }

    private void OnCollisionExit(Collision collision)
    {
        canBePlaced = true;
        GetComponent<MeshRenderer>().material = validMaterial;
    }
}
