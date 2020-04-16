using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I work");
    }
}
