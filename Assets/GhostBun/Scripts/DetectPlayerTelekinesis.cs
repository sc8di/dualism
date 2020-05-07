using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerTelekinesis : MonoBehaviour
{
    public int timesPlayerDetected;

    private void Start()
    {
        timesPlayerDetected = 0;
        Managers.Player.SetPlayerDetectedCount(timesPlayerDetected);
    }

    public void PlayerDetected()
    {
        timesPlayerDetected++;
        Debug.Log($"Player Detected! Total detections: {timesPlayerDetected}");
    }
}
