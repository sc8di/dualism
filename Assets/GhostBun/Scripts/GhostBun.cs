using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBun : MonoBehaviour
{
    [SerializeField]
    ForceMode forceMode;
    [SerializeField]
    float force;
    List<Rigidbody> rbList = new List<Rigidbody>();

    [SerializeField]
    float bunSpeed = 5;
    [SerializeField]
    GameObject target;

    [SerializeField]
    float stopThreshold = 0.2f;

    Vector3 startingLocation;
    Rigidbody rb;
    float distanceToTarget;

    private void Start()
    {
        startingLocation = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (target.activeInHierarchy)
        {
            distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if(distanceToTarget > stopThreshold)
            {
                transform.LookAt(target.transform);
                rb.MovePosition(transform.position + transform.forward * bunSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            distanceToTarget = Vector3.Distance(transform.position, startingLocation);
            if (distanceToTarget > stopThreshold)
            {
                transform.LookAt(startingLocation);
                rb.MovePosition(transform.position + transform.forward * bunSpeed * Time.fixedDeltaTime);
            }
        }

        ///Бегаем по записям.
        for (int i = 0; i < rbList.Count; i++)
        {
            //Если объект уже уничтожен, не существует, убираем его из листа.
            if (!rbList[i])
            {
                rbList.RemoveAt(i);
                i--;
                continue;
            }
            Vector3 directionalForce = (transform.position - rbList[i].transform.position).normalized * force;
            rbList[i].AddForce(directionalForce * Time.fixedDeltaTime, forceMode);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb && !rbList.Contains(rb))
        {
            rbList.Add(rb);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb)
        {
            rbList.Remove(rb);
        }
    }

}
