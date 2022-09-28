using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    public string placeableTag;
    public MeshFilter fakeSelectedPlaceableGO;

    GameObject selectedPlaceableGO;
    public Camera playerCamera; //TODO: private + cam current player

    void Start()
    {

    }

    void Update()
    {
        if (selectedPlaceableGO)
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) 
            {
                if (hit.transform.gameObject.tag == placeableTag)
                {
                    fakeSelectedPlaceableGO.gameObject.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(selectedPlaceableGO, hit.point, Quaternion.identity);
                    }
                    else if (fakeSelectedPlaceableGO)
                    {
                        fakeSelectedPlaceableGO.transform.position = hit.point;
                    }
                }
            } 
            else if (fakeSelectedPlaceableGO)
            {
                fakeSelectedPlaceableGO.gameObject.SetActive(false);
            }
        }
    }

    public void setSelectedPlaceableGameObject(GameObject g)
    {
        selectedPlaceableGO = g;
        fakeSelectedPlaceableGO.GetComponent<MeshFilter>().sharedMesh = g.GetComponent<MeshFilter>().sharedMesh;
    }
}
