using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField]
    float verticalOffset = 2f;

    [SerializeField]
    float maximumRadius = 2f;

    [SerializeField]
    float expansionSpeed = 1f;

    [SerializeField]
    float force;

    static List<Rigidbody> rbList = new List<Rigidbody>();

    Vector3 basicScale = Vector3.one;
    float currentRadius = 0f;

    private void Start()
    {
        transform.localScale = Vector3.one * currentRadius;
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

    private void OnDisable()
    {
        rbList.Clear();
        currentRadius = 0;
        transform.localScale = Vector3.one * currentRadius;
    }

    private void FixedUpdate()
    {
        if (transform.localPosition.y != verticalOffset)
        {
            transform.localPosition = Vector3.up * verticalOffset;
        }
        if (currentRadius < maximumRadius)
        {
            currentRadius += Time.fixedDeltaTime * expansionSpeed * Random.Range(-0.5f, 1f);
            transform.localScale = Vector3.one * currentRadius;
        }
        for (int i = 0; i < rbList.Count; i++)
        {
            if (!rbList[i])
            {
                rbList.RemoveAt(i);
                i--;
                continue;
            }
            Vector3 directionalForce = (transform.position - rbList[i].transform.position).normalized * force;
            Vector3 randomForce = Random.insideUnitSphere * Random.Range(0, force) * Random.Range(1f, 3f);
            rbList[i].AddForce((directionalForce + randomForce) * Time.fixedDeltaTime);
        }
    }
}
