using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] public bool isAvailable { get; protected set; } = true;
    public List<string> CurrentUser;

    [SerializeField] [Range(0, 10)] int WeightOfWaypoint;


    private void Update()
    {
        Debug.Log($"Waypoint: {gameObject.name} // // is Available: {isAvailable} // // ");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 2);
    }

    public void SetAvailability(bool availability)
    {
        isAvailable = availability;
    }

    public int GetWaeightOfWaypoint()
    {
        return WeightOfWaypoint;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

}
