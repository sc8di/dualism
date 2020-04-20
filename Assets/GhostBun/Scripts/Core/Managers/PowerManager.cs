using UnityEngine;

public class PowerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    #region Power variables.
    [Header("Telecinetic", order = 0)]
    [Range(0, 1)]
    [SerializeField] private float _startingRadiusGrab;
    [SerializeField] private float _maximumRadiusGrab;
    [SerializeField] private float _expansionSpeedGrab;
    [Range(0, 1)]
    [SerializeField] private float _expansionChaosGrab;
    [Range(0, 1)]
    [SerializeField] private float _chaoticForseGrab;
    [SerializeField] private int _maximumObjectsInControlGrab;
    [SerializeField] private float _forceGrab;
    [SerializeField] private float _chaoticForceGrab;

    [Space(10)]
    [Header("Push", order = 1)]
    [Range(0, 1)]
    [SerializeField] private float _startingRadiusPush;
    [SerializeField] private float _maximumRadiusPush;
    [SerializeField] private float _expansionSpeedPush;
    [SerializeField] private float _expansionChaosPush;
    [SerializeField] private float _chaoticForsePush;
    [SerializeField] private int _maximumObjectsInControlPush;
    [SerializeField] private float _forcePush;
    [SerializeField] private float _chaoticForcePush;

    [Space(10)]
    [Header("Rage", order = 2)]
    [Range(0, 1)]
    [SerializeField] private float _startingRadiusRage;
    [SerializeField] private float _maximumRadiusRage;
    [SerializeField] private float _expansionSpeedRage;
    [Range(0, 1)]
    [SerializeField] private float _expansionChaosRage;
    [Range(0, 1)]
    [SerializeField] private float _chaoticForseRage;
    [SerializeField] private int _maximumObjectsInControlRage;
    [SerializeField] private float _forceRage;
    [SerializeField] private float _chaoticForceRage;
    #endregion

    public Power Telecinetic;
    public Power Push;
    public Power Rage;

    public void Startup()
    {
        Debug.Log("Power manager starting...");

        #region Power inicialize.
        Telecinetic = new Power()
        {
            forceMode = ForceMode.Force,
            startingRadius = _startingRadiusGrab,
            maximumRadius = _maximumRadiusGrab,
            expansionSpeed = _expansionSpeedGrab,
            expansionChaos = _expansionChaosGrab,
            chaoticForse = _chaoticForseGrab,
            maximumObjectsInControl = _maximumObjectsInControlGrab,
            force = _forceGrab,
            chaoticForce = _chaoticForceGrab
        };
        Push = new Power()
        {
            forceMode = ForceMode.Impulse,
            startingRadius = _startingRadiusPush,
            maximumRadius = _maximumRadiusPush,
            expansionSpeed = _expansionSpeedPush,
            expansionChaos = _expansionChaosPush,
            chaoticForse = _chaoticForsePush,
            maximumObjectsInControl = _maximumObjectsInControlPush,
            force = _forcePush,
            chaoticForce = _chaoticForcePush
        };
        Rage = new Power()
        {
            forceMode = ForceMode.VelocityChange,
            startingRadius = _startingRadiusRage,
            maximumRadius = _maximumRadiusRage,
            expansionSpeed = _expansionSpeedRage,
            expansionChaos = _expansionChaosRage,
            chaoticForse = _chaoticForseRage,
            maximumObjectsInControl = _maximumObjectsInControlRage,
            force = _forceRage,
            chaoticForce = _chaoticForceRage
        };
        #endregion

        Status = ManagerStatus.Started;
    }
}