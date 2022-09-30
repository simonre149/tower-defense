using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    public int ignoreRaycastLayerIndex = 2;
    public string placeableTag = "Placeable";
    public Material fakeValidPlaceMaterial, fakeInvalidPlaceMaterial;

    GameObject selectedGO, fakeGO;
    public Camera playerCamera; //TODO: enlever public + cam current player

    void Update()
    {
        if (selectedGO && fakeGO)
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                updateFakeGO(hit.point);
                if (hit.transform.gameObject.tag == placeableTag)
                {
                    fakeGO.SetActive(true);
                    if (Input.GetMouseButtonDown(0) && fakeGO.GetComponent<PlacementChecker>().canBePlaced)
                    {
                        Instantiate(selectedGO, hit.point, Quaternion.identity);
                    }
                }
            }
            else
            {
                fakeGO.SetActive(false);
            }
        }
    }

    void updateFakeGO(Vector3 newPos)
    {
        transform.position = newPos;
        fakeGO.GetComponent<MeshRenderer>().material = fakeGO.GetComponent<PlacementChecker>().canBePlaced ? fakeValidPlaceMaterial : fakeInvalidPlaceMaterial;
    }

    public void setSelectedPlaceableGameObject(GameObject g)
    {
        selectedGO = g;
        if (fakeGO)
        {
            Destroy(fakeGO);
        }
        fakeGO = Instantiate(g.transform.GetChild(0).gameObject, transform);
        fakeGO.layer = ignoreRaycastLayerIndex;
        fakeGO.GetComponent<Collider>().isTrigger = true;
        fakeGO.AddComponent<PlacementChecker>();
        fakeGO.AddComponent<Rigidbody>();
        fakeGO.GetComponent<Rigidbody>().useGravity = false;
    }
}
