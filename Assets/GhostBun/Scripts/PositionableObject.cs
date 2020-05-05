using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PositionableObject : MonoBehaviour
{
    [SerializeField]
    GameObject positionMarker;
    [SerializeField]
    GameObject positionableObject;
    [SerializeField]
    Material ghostMaterial;
    [SerializeField]
    float reactivateObjectAfterSeconds = 3f;
    [SerializeField]
    float distanceActivation = 0.2f;
    [SerializeField]
    Waypoint thisWaypoint;

    bool isOnPosition = false;
    SphereCollider thisTrigger;

    bool reactivate = false;
    float cooldown = 0f;
    bool dontTriggerInThisFrame = false;

    public bool IsOnPosition()
    {
        return isOnPosition;
    }

    private void Start()
    {
        positionMarker = Instantiate(positionableObject, transform);
        positionMarker.GetComponent<MeshRenderer>().material = ghostMaterial;
        Destroy(positionMarker.GetComponent<Rigidbody>());
        Destroy(positionMarker.GetComponent<NavMeshObstacle>());
        Destroy(positionMarker.GetComponent<BoxCollider>());
        thisTrigger = GetComponent<SphereCollider>();
        ActivateWaypoint(false , false);
    }

    private void FixedUpdate()
    {
        dontTriggerInThisFrame = false;
        if (reactivate)
        {
            cooldown += Time.fixedDeltaTime;
            if (cooldown > reactivateObjectAfterSeconds)
            {
                Debug.Log("Can be pulled again");
                dontTriggerInThisFrame = true;
                positionableObject.GetComponent<Rigidbody>().isKinematic = false;
                reactivate = false;
                cooldown = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == positionableObject && !dontTriggerInThisFrame)
        {
            Debug.Log("Deactivated");
            dontTriggerInThisFrame = true;
            positionableObject.GetComponent<Rigidbody>().isKinematic = true;
            positionableObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
            positionMarker.SetActive(false);
            reactivate = true;
            isOnPosition = true;
            ActivateWaypoint(true, false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == positionableObject && !dontTriggerInThisFrame)
        {
            Debug.Log("Reactivated");
            positionMarker.SetActive(true);
            isOnPosition = false;
            ActivateWaypoint(false , true);
        }
    }

    private void ActivateWaypoint(bool state, bool moved)
    {
        if (thisWaypoint)
        {
            thisWaypoint.SetAvailability(state, moved);
        }
    }
}
