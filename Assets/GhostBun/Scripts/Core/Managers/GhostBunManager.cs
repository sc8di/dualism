using UnityEngine;

public class GhostBunManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    public void Startup()
    {
        Debug.Log("GhostBun manager starting...");

        Status = ManagerStatus.Started;
    }
}
