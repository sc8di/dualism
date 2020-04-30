using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerTelekinesis : MonoBehaviour
{
    public int timesPlayerDetected = 0;

    public void PlayerDetected()
    {
        timesPlayerDetected++;
        Debug.Log($"Player Detected! Total detections: {timesPlayerDetected}");
    }
}
