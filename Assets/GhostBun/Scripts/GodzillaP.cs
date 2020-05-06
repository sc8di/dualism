using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodzillaP : MonoBehaviour
{
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private AudioSource _stomp;
    private AllRigidbodies _allrb;
    
    public float force = 500f;

    private void Start()
    {
        _allrb = FindObjectOfType<AllRigidbodies>();
        gameObject.SetActive(false);
    }

    private void PushByStep()
    {
        _allrb.AddForceToAll(transform.up + Random.onUnitSphere * force, _forceMode);
        _stomp.Play();
    }

    private void DisableMe()
    {
        gameObject.SetActive(false);
    }
}
