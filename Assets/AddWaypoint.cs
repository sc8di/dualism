using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmeraldAI;

public class AddWaypoint : MonoBehaviour
{
    [SerializeField]
    EmeraldAISystem EAIS;

    private void OnEnable()
    {
        EAIS.WaypointsList.Insert(3, transform.position);
        if (EAIS.AIReachedDestination)
        {
            Debug.Log("DESTINATION REACHED");
        }
    }
}
