using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckClick : MonoBehaviour
{
    [SerializeField]
    public Waypoint waypoint;
    [SerializeField]
    public Transform parent;


    public void Check()
    {
        Debug.Log("Click: " + waypoint.name);
    }


}
