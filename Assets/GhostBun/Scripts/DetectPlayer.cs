using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    LayerMask detectionLayer;
    [SerializeField]
    float detectionDistance = 8f;
    [SerializeField]
    float autoDetectDistance = 1f;

    [SerializeField]
    GameObject gesture;

    PlayerManager pm;
    [SerializeField]
    float viewAngle = 15f;

    NavMeshAgent navMeshAgent;

    public float waitTimer = 10f;

    Vector3 directionToPlayer;
    float distanceToPlayer;
    bool lookForPlayer = true;

    float timeSinceLookedAtPlayer = 0f;
    [SerializeField]
    float lookAtPlayerEverySeconds = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, autoDetectDistance);
        Gizmos.DrawLine(transform.position, transform.forward * detectionDistance + transform.position);
        Gizmos.DrawLine(transform.position, Quaternion.Euler(0, viewAngle * 0.5f, 0) * transform.forward * detectionDistance + transform.position);
        Gizmos.DrawLine(transform.position, Quaternion.Euler(0, -viewAngle * 0.5f, 0) * transform.forward * detectionDistance + transform.position);
    }

    private void Start()
    {
        gesture.SetActive(false);
        pm = FindObjectOfType<PlayerManager>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (timeSinceLookedAtPlayer > lookAtPlayerEverySeconds && lookForPlayer && CheckPlayerInView())
        {
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out RaycastHit hitInfo, detectionDistance, detectionLayer))
            {
                if (hitInfo.transform.CompareTag("PlayerTelekinesis"))
                {
                    pm.PlayerDetected();
                    lookForPlayer = false; //Делаем паузу для поиска игрока.
                    StartEmote();

                }
            }
            timeSinceLookedAtPlayer = 0f;
        }
        timeSinceLookedAtPlayer += Time.fixedDeltaTime;
    }

    public bool CheckPlayerInView()
    {
        directionToPlayer = player.transform.position - transform.position;
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer < autoDetectDistance) return true;
        return distanceToPlayer < detectionDistance && viewAngle > Vector2.Angle(new Vector2(directionToPlayer.x, directionToPlayer.z), new Vector2(transform.forward.x, transform.forward.z));
    }

    public void StartEmote()
    {
         transform.LookAt(player.transform);
         transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y, 0));
         // Останавливаем движение NPC до окончания анимации
         StartCoroutine(WhoaThisDudeIsLevitating(waitTimer));
    }


    /// <summary>
    /// Включаем анимацию возмущения/удивления  
    /// </summary>
    /// <param name="delay">Время после которого персанаж возобновит движение</param>
    /// <returns></returns>
    private IEnumerator WhoaThisDudeIsLevitating(float delay)
    {
        gesture.SetActive(true);
        //Надо сделать связь с CharacterWaypointsNavigation. Останавливать персонажа нужно через него.
        navMeshAgent.isStopped = true;
        //Сюда вставляется анимация возмущения??
        yield return new WaitForSeconds(delay);
        navMeshAgent.isStopped = false;
        gesture.SetActive(false);
        lookForPlayer = true;
    }
}
