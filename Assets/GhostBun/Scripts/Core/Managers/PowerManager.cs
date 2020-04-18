using UnityEngine;

public class PowerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    #region Power variables.
    [Header("Telecinetic", order = 0)]
    [Range(0, 1)]
    [SerializeField] private float startingRadiusGrab;
    [SerializeField] private float maximumRadiusGrab;
    [SerializeField] private float expansionSpeedGrab;
    [Range(0, 1)]
    [SerializeField] private float expansionChaosGrab;
    [Range(0, 1)]
    [SerializeField] private float chaoticForseGrab;
    [SerializeField] private int maximumObjectsInControlGrab;
    [SerializeField] private float forceGrab;
    [SerializeField] private float chaoticForceGrab;

    [Space(10)]
    [Header("Push", order = 1)]
    [Range(0, 1)]
    [SerializeField] private float startingRadiusPush;
    [SerializeField] private float maximumRadiusPush;
    [SerializeField] private float expansionSpeedPush;
    [SerializeField] private float expansionChaosPush;
    [SerializeField] private float chaoticForsePush;
    [SerializeField] private int maximumObjectsInControlPush;
    [SerializeField] private float forcePush;
    [SerializeField] private float chaoticForcePush;

    [Space(10)]
    [Header("Rage", order = 2)]
    [Range(0, 1)]
    [SerializeField] private float startingRadiusRage;
    [SerializeField] private float maximumRadiusRage;
    [SerializeField] private float expansionSpeedRage;
    [Range(0, 1)]
    [SerializeField] private float expansionChaosRage;
    [Range(0, 1)]
    [SerializeField] private float chaoticForseRage;
    [SerializeField] private int maximumObjectsInControlRage;
    [SerializeField] private float forceRage;
    [SerializeField] private float chaoticForceRage;
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
            startingRadius = startingRadiusGrab,
            maximumRadius = maximumRadiusGrab,
            expansionSpeed = expansionSpeedGrab,
            expansionChaos = expansionChaosGrab,
            chaoticForse = chaoticForseGrab,
            maximumObjectsInControl = maximumObjectsInControlGrab,
            force = forceGrab,
            chaoticForce = chaoticForceGrab
        };
        Push = new Power()
        {
            forceMode = ForceMode.Impulse,
            startingRadius = startingRadiusPush,
            maximumRadius = maximumRadiusPush,
            expansionSpeed = expansionSpeedPush,
            expansionChaos = expansionChaosPush,
            chaoticForse = chaoticForsePush,
            maximumObjectsInControl = maximumObjectsInControlPush,
            force = forcePush,
            chaoticForce = chaoticForcePush
        };
        Rage = new Power()
        {
            forceMode = ForceMode.VelocityChange,
            startingRadius = startingRadiusRage,
            maximumRadius = maximumRadiusRage,
            expansionSpeed = expansionSpeedRage,
            expansionChaos = expansionChaosRage,
            chaoticForse = chaoticForseRage,
            maximumObjectsInControl = maximumObjectsInControlRage,
            force = forceRage,
            chaoticForce = chaoticForceRage
        };
        #endregion


        Status = ManagerStatus.Started;
    }
}