using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekineticField : MonoBehaviour
{
    [SerializeField]
    ForceMode forceMode;

    [SerializeField]
    [Range(0,1)]
    float startingRadius = 1f;

    [SerializeField]
    float maximumRadius = 2f;

    [SerializeField]
    float expansionSpeed = 10f;

    [SerializeField]
    [Range(0, 1)]
    float expansionChaos = 0f;

    [SerializeField]
    [Range(0, 1)]
    float chaoticForse = 0f;

    [SerializeField]
    int maximumObjectsInControl = 5;

    [SerializeField]
    float force;
    [SerializeField]
    float chaoticForce;

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
        if (rb && !rbList.Contains(rb) && rbList.Count < maximumObjectsInControl)
        {
            rbList.Add(rb);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rbList.Contains(rb))
        {
            rbList.Remove(rb);
        }
    }

    private void OnDisable()
    {
        rbList.Clear();
        currentRadius = startingRadius;
        transform.localScale = Vector3.one * currentRadius;
    }

    private void FixedUpdate()
    {
        
        if (currentRadius < maximumRadius)
        {
            currentRadius += Time.fixedDeltaTime * (expansionSpeed + (Random.Range(-0.5f * chaoticForse, 1f * chaoticForse) * expansionChaos));
            transform.localScale = Vector3.one * currentRadius;
        }

        if (rbList.Count > 1) rbList.Sort(new Sort());

        for (int i = 0; (i < (rbList.Count < maximumObjectsInControl ? rbList.Count : maximumObjectsInControl)); i++)
        {
            Debug.Log(rbList[i].name);
            if (!rbList[i])
            {
                rbList.RemoveAt(i);
                i--;
                continue;
            }
            Vector3 directionalForce = (transform.position - rbList[i].transform.position).normalized * force;
            Vector3 randomForce = Random.insideUnitSphere * Random.Range(0, chaoticForce) * Random.Range(0f, 2f);
            rbList[i].AddForce((directionalForce + randomForce) * Time.fixedDeltaTime, forceMode);
        }
    }

    private class Sort : IComparer<Rigidbody>
    {
        int IComparer<Rigidbody>.Compare(Rigidbody _objA, Rigidbody _objB)
        {
            float t1 = _objA.mass;
            float t2 = _objB.mass;
            return t1.CompareTo(t2);
        }
    }
}
