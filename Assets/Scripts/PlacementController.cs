using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    public string placeableTag;
    public Material fakeMaterial;

    GameObject selectedGO, fakeGO;
    public Camera playerCamera; //TODO: enlever public + cam current player

    void Start()
    {

    }

    void Update()
    {
        if (selectedGO)
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == placeableTag)
                {
                    fakeGO.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(selectedGO, hit.point, Quaternion.identity);
                    }
                    else if (fakeGO)
                    {
                        transform.position = hit.point;
                    }
                }
                else if (fakeGO)
                {
                    fakeGO.SetActive(false);
                }
            } 
            else if (fakeGO)
            {
                fakeGO.SetActive(false);
            }
        }
    }

    public void setSelectedPlaceableGameObject(GameObject g)
    {
        selectedGO = g;
        fakeGO = Instantiate(g.transform.GetChild(0).gameObject, transform);
        fakeGO.GetComponent<Collider>().enabled = false;
        fakeGO.GetComponent<MeshRenderer>().material = fakeMaterial;
    }
}
