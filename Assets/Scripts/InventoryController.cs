using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject objectToPlace;
    PlacementController placementController;

    void Start()
    {
        placementController = GetComponent<PlacementController>();
        placementController.setSelectedPlaceableGameObject(objectToPlace);
    }

    void Update()
    {
        
    }
}
