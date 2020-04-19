using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTrip : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public float mass;
    public float attachedMass;

    private Rigidbody fieldRb;
    private HashSet<Rigidbody> affectedBodies = new HashSet<Rigidbody>();
    private Vector3 location;


    private void Start()
    {
        fieldRb = GetComponent<Rigidbody>();

        gameObject.SetActive(false);

        fieldRb.mass = mass;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && other.attachedRigidbody.mass <= attachedMass)
        {
            other.attachedRigidbody.useGravity = false;
            affectedBodies.Add(other.attachedRigidbody);
            
            if (!Managers.Items.BodyContains(other.attachedRigidbody))
            {
                Managers.Items.AddBody(other.attachedRigidbody);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            other.attachedRigidbody.useGravity = true;
        }
    }

    void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.position = location + new Vector3(0, 1.5f, 0);
            
            foreach (Rigidbody rb in affectedBodies)
            {
                Vector3 directionToPoint = (transform.position - rb.position).normalized;
                float distance = (transform.position - rb.position).magnitude;
                float strength = rb.mass * mass / distance;
                
                rb.AddForce(directionToPoint * strength);
            }
        }
    }

    public void DisableField()
    {
        foreach (Rigidbody rb in affectedBodies)
        {
            rb.useGravity = true;
        }
        affectedBodies.Clear();
        gameObject.SetActive(false);
    }

    public void EnableField()
    {
        gameObject.SetActive(true);
    }

    public void SetLocation(Vector3 newLocation)
    {
        location = newLocation;
    }
}
