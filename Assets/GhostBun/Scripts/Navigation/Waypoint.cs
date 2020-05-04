using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] public bool isAvailable { get; protected set; } = true;
    public string CurrentUser { get; set; }


    //private void Update()
    //{
    //    Debug.Log($"Waypoint: {gameObject.name} // // is Available: {isAvailable} // // character: {CurrentUser}");
    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 2);
    }

    public void SetAvailability(bool availability)
    {
        isAvailable = availability;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

}
