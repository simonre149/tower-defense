using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject placer, objectToPlace;
    PlacementController placementController;

    void Start()
    {
        placementController = placer.GetComponent<PlacementController>();
        placementController.setSelectedPlaceableGameObject(objectToPlace); // TEMP
    }

    void Update()
    {
        
    }
}
