using UnityEngine;

public class UserInputManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    [SerializeField] private float _anchorTimer = 0.1f;

    public bool gameState = true;

    private float _touchTimer;

    public void Startup()
    {
        Debug.Log("Input manager starting...");

        Status = ManagerStatus.Started;
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1")) 
            _touchTimer = 0;

        if(Input.GetButtonUp("Fire1"))
        {
            // Передвижение игрока. Broadcast для MovementManager?
        }

        if (Input.GetButton("Fire1"))
        {
            if(_touchTimer < _anchorTimer)
                _touchTimer += Time.fixedDeltaTime;
            else
            {
                // Задействовать якорь. Broadcast для AnchorManager or something else?
            }
        }
    }
}