using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routine : MonoBehaviour
{
    public enum Operation
    {
        Disable,
        Enable,
    }
    [SerializeField] public WaypointOperation[] waypoints;
    float currentTime = 0f;

    [System.Serializable]
    public struct WaypointOperation
    {
        public Waypoint wp;
        public float secondsBeforeAct;
        public bool activated;
        public Operation operation;
    }

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime%60 < 0.1f)
        {
            Debug.Log($"Current time is {(int)(8 + currentTime / 60)}:00");
        }
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (!waypoints[i].activated && waypoints[i].secondsBeforeAct < currentTime)
            {
                waypoints[i].activated = true;
                Debug.Log($"Waypoint {waypoints[i].wp.name} activated");
            }
        }
    }
}
