using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeEventManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    public void Startup()
    {
        Debug.Log("Event manager starting...");

        Status = ManagerStatus.Started;
    }
}
