using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmeraldAI;

public class Work : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I work");
        other.GetComponent<EmeraldAIEventsManager>().PlayEmoteAnimation(0);
            
    }
}
