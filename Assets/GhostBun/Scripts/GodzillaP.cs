using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodzillaP : MonoBehaviour
{
    public float force = 500f;
    [SerializeField]
    ForceMode forceMode;

    AllRigidbodies allrb;

    private void Start()
    {
        allrb = FindObjectOfType<AllRigidbodies>();
        gameObject.SetActive(false);
    }

    private void PushByStep()
    {
        
        allrb.AddForceToAll(transform.up + Random.onUnitSphere * force, forceMode);
    }
}
