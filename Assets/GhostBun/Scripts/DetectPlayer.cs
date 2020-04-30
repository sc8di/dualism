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

    [SerializeField] DetectPlayerTelekinesis dpt;
    [SerializeField]
    float viewAngle = 15f;

    NavMeshAgent navMeshAgent;

    [SerializeField] private int _emoteAnimationIndex;

    public float turnOffTrigerTime = 10f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.forward * detectionDistance + transform.position);
        Gizmos.DrawLine(transform.position, Quaternion.Euler(0, viewAngle * 0.5f, 0) * transform.forward * detectionDistance + transform.position);
        Gizmos.DrawLine(transform.position, Quaternion.Euler(0, -viewAngle * 0.5f, 0) * transform.forward * detectionDistance + transform.position);
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Включаем анимацию работы  
    /// </summary>
    /// <param name="delay">Время после которого персанаж возобновит движение</param>
    /// <returns></returns>
    private IEnumerator Working(float delay)
    {
        navMeshAgent.isStopped = true;
        //_eventSystem.PlayEmoteAnimation(_emoteAnimationIndex);
        yield return new WaitForSeconds(delay);
        navMeshAgent.isStopped = false;
    }

    private void FixedUpdate()
    {
        TestDetection();
    }

    public void TestDetection()
    {
        Debug.Log("Testing for player");
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out RaycastHit hitInfo, detectionDistance, detectionLayer))
        {
            Vector3 characterDirection = transform.forward;
            Vector3 playerDirection = (player.transform.position - transform.position).normalized;
            //Debug.Log(characterDirection + " " + playerDirection + " " + Vector2.Angle(new Vector2(playerDirection.x, playerDirection.z), new Vector2(characterDirection.x, characterDirection.z)));
            Debug.Log(hitInfo.transform.tag);
            if (hitInfo.transform.CompareTag("Player") && viewAngle > Vector2.Angle(new Vector2(playerDirection.x, playerDirection.z), new Vector2(characterDirection.x, characterDirection.z)))
            {
                dpt.PlayerDetected();
                StartEmote();
            }
        }
        else
        {
            Debug.Log("Player not seen");
        }
    }

    public void StartEmote()
    {
         // Останавливаем движение NPC до окончания анимации
         StartCoroutine(Working(this.GetComponent<AnimationsArray>().AnimationsLength[_emoteAnimationIndex]));
    }
}
