﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] public bool isAvailable;
    [HideInInspector]
    public List<string> CurrentUser;

    [SerializeField] [Range(0, 10)] int WeightOfWaypoint;
    [SerializeField] GameObject gesture;
    [SerializeField] BoxCollider clickBox;

    public bool isMoved = false;

    private void Start()
    {
        StartCoroutine(CheckAvailability());
    }
    //private void Update()
    //{
    //    Debug.Log($"Waypoint: {gameObject.name} // // is Available: {isAvailable} // // ");
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

    public void SetAvailability(bool availability, bool moved)
    {
        isAvailable = availability;
        isMoved = moved;
    }

    public int GetWaeightOfWaypoint()
    {
        return WeightOfWaypoint;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private IEnumerator CheckAvailability()
    {
        while (true)
        {
            if (isMoved)
            {
                GetComponent<BoxCollider>().enabled = false;
                clickBox.enabled = false;
                gesture.SetActive(false);
            }
                
            else if (!isMoved && isAvailable)
            {
                gesture.SetActive(true);
                GetComponent<BoxCollider>().enabled = true;
                clickBox.enabled = true;
            }

            yield return new WaitForSeconds(1);
        }
    }

}
