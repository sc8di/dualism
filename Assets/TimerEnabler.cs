using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEnabler : MonoBehaviour
{
    float timer = 0;

    [SerializeField]
    float timeToEnable = 1f;
    [SerializeField]
    GameObject gameObject;

    private void FixedUpdate()
    {
        if (timer < timeToEnable)
        {
            timer += Time.fixedDeltaTime;
        }
        if (!gameObject.activeInHierarchy && timer >= timeToEnable)
        {
            gameObject.SetActive(true);
        }
    }
}
