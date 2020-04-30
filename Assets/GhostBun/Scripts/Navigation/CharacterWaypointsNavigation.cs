using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterWaypointsNavigation : MonoBehaviour
{
    enum navigationMethod { linear, reverse, random }

    [SerializeField]
    navigationMethod navMethod = navigationMethod.linear;

    [SerializeField]
    List<Waypoint> wpList;

    NavMeshAgent navMeshAgent;

    Waypoint targetWaypoint;

    [SerializeField]
    float distanceFalloff = 0.5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (wpList.Count > 1)
        {
            for (int i = 1; i < wpList.Count; i++)
            {
                Gizmos.DrawLine(wpList[i].GetPosition(), wpList[i - 1].GetPosition());
            }
            Gizmos.DrawLine(wpList[0].GetPosition(), wpList[wpList.Count - 1].GetPosition());
        }

    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetWaypoint = wpList[0];
        navMeshAgent.SetDestination(targetWaypoint.GetPosition());
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, targetWaypoint.GetPosition()) < distanceFalloff)
        {
            targetWaypoint = GetNextWaypoint();
            navMeshAgent.SetDestination(targetWaypoint.GetPosition());
        }
    }

    private Waypoint GetNextWaypoint()
    {
        if (wpList.IndexOf(targetWaypoint) + 1 > (wpList.Count - 1))
        {
            return wpList[0];
        }
        else
        {
            return wpList[wpList.IndexOf(targetWaypoint) + 1];
        }
    }
}

