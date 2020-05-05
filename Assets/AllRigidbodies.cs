using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllRigidbodies : MonoBehaviour
{
    private List<Rigidbody> _rbList = new List<Rigidbody>();

    private void Start()
    {
        RaycastHit[] hits = Physics.BoxCastAll(Vector3.zero, Vector3.one * 25, transform.forward);
        foreach (RaycastHit hit in hits)
        {
            if (hit.rigidbody != null && !_rbList.Contains(hit.rigidbody))
            {
                _rbList.Add(hit.rigidbody);
            }
        }
    }

    public void AddForceToAll(Vector3 force, ForceMode forceMode)
    {
        for (int i = 0; i < _rbList.Count; i++)
        {
            if (!_rbList[i])
            {
                _rbList.Remove(_rbList[i]);
            }
            _rbList[i].AddForce(force, forceMode);
        }
    }
}
