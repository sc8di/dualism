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

    Animator _animator;
    NavMeshAgent _navMeshAgent;
    Waypoint _targetWaypoint;
    Waypoint _closestWp;

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
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (wpList.Count != 0)
        {
            _targetWaypoint = wpList[0];
            _navMeshAgent.SetDestination(_targetWaypoint.GetPosition());
        }
        else
            Debug.Log("List of waypoints is empty");
            
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _targetWaypoint.GetPosition()) < distanceFalloff)
        {
            _targetWaypoint = GetNextRandoomWaypoint();
            _navMeshAgent.SetDestination(_targetWaypoint.GetPosition());
        }
        _animator.SetFloat("Forward", _navMeshAgent.velocity.magnitude / _navMeshAgent.speed);
    }
    /// <summary>
    /// метод запускает движение по Waypoints(точкам)
    /// </summary>
    public void goToMove()
    {
        Debug.Log("Go back to the closest waipoint");
        _targetWaypoint = FindTheColsest();
        _navMeshAgent.SetDestination(_targetWaypoint.GetPosition());
    }

    private Waypoint GetNextWaypoint()
    {
        if (wpList.IndexOf(_targetWaypoint) + 1 > (wpList.Count - 1))
        {
            return wpList[0];
        }
        else
        {
            return wpList[wpList.IndexOf(_targetWaypoint) + 1];
        }
    }
    /// <summary>
    /// Метод случайно выбирает точку движения
    /// </summary>
    /// <returns>Возвращает Waypoint object</returns>
    private Waypoint GetNextRandoomWaypoint()
    {
        int index = Random.Range(0, wpList.Count);
        return wpList[index];
    }
    /// <summary>
    /// Метод находит ближайшую точку 
    /// </summary>
    /// <returns>Возвращает Waypoint object</returns>
    private Waypoint FindTheColsest()
    {
        float lowestDist = Mathf.Infinity;

        for (int i = 0; i < wpList.Count; i++)
        {

            float dist = Vector3.Distance(wpList[i].transform.position, transform.position);

            if (dist < lowestDist)
            {
                lowestDist = dist;
                _closestWp = wpList[i];
            }
        }
        return _closestWp;
    }
}

