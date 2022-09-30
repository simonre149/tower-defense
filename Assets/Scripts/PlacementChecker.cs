using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementChecker : MonoBehaviour
{
    public bool canBePlaced = true;
    public string placeableTag = "Placeable", agentTag = "Agent";
    ArrayList currentlyColliding = new ArrayList();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != placeableTag && other.tag != agentTag && !currentlyColliding.Contains(other))
        {
            currentlyColliding.Add(other);
            canBePlaced = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != placeableTag && currentlyColliding.Contains(other))
        {
            currentlyColliding.Remove(other);
            if (currentlyColliding.Count == 0)
                canBePlaced = true;
        }
    }
}
