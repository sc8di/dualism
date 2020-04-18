using UnityEngine;

public class NpcManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    public void Startup()
    {
        Debug.Log("NPC manager starting...");

        Status = ManagerStatus.Started;
    }
}
