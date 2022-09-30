using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject placer, objectToPlace, objectToPlace2;
    PlacementController placementController;

    void Start()
    {
        placementController = placer.GetComponent<PlacementController>();
        placementController.setSelectedPlaceableGameObject(objectToPlace); // TEMP
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //TEMP
        {
            placementController.setSelectedPlaceableGameObject(objectToPlace2);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            placementController.setSelectedPlaceableGameObject(null);
        }
    }
}
