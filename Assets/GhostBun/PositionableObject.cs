using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionableObject : MonoBehaviour
{
    [SerializeField]
    GameObject positionMarker;
    [SerializeField]
    GameObject positionableObject;
    [SerializeField]
    float reactivateObjectAfterSeconds = 3f;
    [SerializeField]
    float distanceActivation = 0.2f;

    SphereCollider thisTrigger;

    bool reactivate = false;
    float cooldown = 0f;
    bool dontTriggerInThisFrame = false;

    private void Start()
    {
        thisTrigger = GetComponent<SphereCollider>();
    }

    private void FixedUpdate()
    {
        dontTriggerInThisFrame = false;
        if (reactivate)
        {
            cooldown += Time.fixedDeltaTime;
            if (cooldown > reactivateObjectAfterSeconds)
            {
                Debug.Log("Reactivated");
                positionableObject.GetComponent<Rigidbody>().isKinematic = false;
                dontTriggerInThisFrame = true;
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
            positionableObject.GetComponent<Rigidbody>().isKinematic = true;
            positionableObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
            positionMarker.SetActive(false);
            reactivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == positionableObject && !dontTriggerInThisFrame)
        {
            positionMarker.SetActive(true);
        }
    }
}
