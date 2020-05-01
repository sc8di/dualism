using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] public bool isAvailable { get; protected set; } = true;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        StartCoroutine(CheckPosition());
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

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void FixedUpdate()
    {
        if (!isAvailable)
        {

        }
    }

    private IEnumerator CheckPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (startPosition != transform.position)
            {
                SetAvailability(false);
            }
            Debug.Log("Is Active Waypoint: " + isAvailable);
        }
    }

}
