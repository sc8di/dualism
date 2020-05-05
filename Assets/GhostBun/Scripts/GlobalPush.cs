using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPush : MonoBehaviour
{
    public float force = 500f;
    [SerializeField]
    ForceMode forceMode;

    AllRigidbodies allrb;
    bool atstart = true;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 arrowEnd = transform.forward * 6 + transform.position;
        Gizmos.DrawLine(transform.position, arrowEnd);
        Gizmos.DrawLine(arrowEnd, -transform.right + arrowEnd + -transform.forward);
        Gizmos.DrawLine(arrowEnd, transform.right + arrowEnd + -transform.forward);
    }

    private void Start()
    {
        allrb = FindObjectOfType<AllRigidbodies>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (!atstart)
        {
            allrb.AddForceToAll(transform.forward * force, forceMode);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        atstart = false;
    }
}
