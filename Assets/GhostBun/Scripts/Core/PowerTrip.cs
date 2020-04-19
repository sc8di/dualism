using System.Collections.Generic;
using UnityEngine;

public class PowerTrip : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public float mass;
    public float attachedMass;
    public int itemsUnderControl;

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
        Rigidbody rb = other.attachedRigidbody;
        
        if (rb != null && 
            rb.mass <= attachedMass &&
            itemsUnderControl > affectedBodies.Count)
        {
            rb.useGravity = false;
            affectedBodies.Add(rb);
            
            if (!Managers.Items.BodyContains(rb))
            {
                Managers.Items.AddBody(rb);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        
        if (rb != null)
        {
            rb.useGravity = true;
            affectedBodies.Remove(rb);
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
                Debug.Log($"Name:{rb.name}, velocity{rb.velocity}");
                Debug.Log($"Name:{rb.name}, angularVelocity{rb.angularVelocity}");
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
