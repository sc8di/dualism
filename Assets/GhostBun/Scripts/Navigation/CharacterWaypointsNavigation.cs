using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterWaypointsNavigation : MonoBehaviour
{
    [SerializeField]
    List<Waypoint> wpList;

    [SerializeField]
    float distanceFalloff = 0.5f;
    [SerializeField]
    private float _timerToWander = 0.5f;
    [SerializeField]
    public GameObject workParticle;


    Animator _animator;
    NavMeshAgent _navMeshAgent;
    Waypoint _targetWaypoint;
    Waypoint _closestWp;

    private float _wanderTimer = 0;
    private int maxWeight = 0;

    public bool isWorking { get; set; } = false;

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.blue;
    //    if (wpList.Count > 1)
    //    {
    //        for (int i = 1; i < wpList.Count; i++)
    //        {
    //            Gizmos.DrawLine(wpList[i].GetPosition(), wpList[i - 1].GetPosition());
    //        }
    //        Gizmos.DrawLine(wpList[0].GetPosition(), wpList[wpList.Count - 1].GetPosition());
    //    }
    //}

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        //Записываем максимальный вес выподения Waypoint
        for (int i = 0; i < wpList.Count; i++)
        {
            if (wpList[i].GetWaeightOfWaypoint() > maxWeight)
                maxWeight = wpList[i].GetWaeightOfWaypoint();
        }
        //Старт движения
        if (wpList.Count != 0)
        {
            _targetWaypoint = GetNextRandomWaypoint();
            _targetWaypoint.CurrentUser.Add(gameObject.name);
            _navMeshAgent.SetDestination(_targetWaypoint.GetPosition());
        }
        else
            Debug.LogError("List of waypoints is empty");

    }
    private void FixedUpdate()
    {
        //Запускаем движение по waypoints после достижения точки заданной игроком
        if (_navMeshAgent.velocity == Vector3.zero && !isWorking)
        {
            _wanderTimer += Time.fixedDeltaTime;
            if (_wanderTimer > _timerToWander)
            {
                //Debug.Log("I am staying");
                //_wpNavigation.goToMove();
                //if (gameObject.tag == "Player")
                //    goToMove();
                //else 
                GoToRandomPoint();
                _wanderTimer = 0f;
            }
        }

        if (Vector3.Distance(transform.position, _targetWaypoint.GetPosition()) < distanceFalloff && !isWorking)
        {
            GoToRandomPoint();
        }
        _animator.SetFloat("Forward", _navMeshAgent.velocity.magnitude / _navMeshAgent.speed);
    }
    /// <summary>
    /// метод запускает движение по Waypoints(точкам)
    /// </summary>
    public void goToMove()
    {
        //Debug.Log("Go back to the closest waipoint");
        _targetWaypoint = FindTheClosest();
        _targetWaypoint.CurrentUser.Add(gameObject.name);
        _navMeshAgent.SetDestination(_targetWaypoint.GetPosition());
    }

    public void GoToRandomPoint()
    {
        if (!isWorking)
        {
            _targetWaypoint = GetNextRandomWaypoint();
            _targetWaypoint.CurrentUser.Add(gameObject.name);
            _navMeshAgent.SetDestination(_targetWaypoint.GetPosition());
        }
    }

    //private Waypoint GetNextWaypoint()
    //{
    //    if (wpList.IndexOf(_targetWaypoint) + 1 > (wpList.Count - 1))
    //    {
    //        return wpList[0];
    //    }
    //    else
    //    {
    //        return wpList[wpList.IndexOf(_targetWaypoint) + 1];
    //    }
    //}
    /// <summary>
    /// Метод случайно выбирает точку движения
    /// </summary>
    /// <returns>Возвращает Waypoint object</returns>
    private Waypoint GetNextRandomWaypoint()
    {
        //Debug.Log("get random");
        List<Waypoint> availableWaypoints = new List<Waypoint>();
        int weight = Random.Range(0, maxWeight);
        foreach (Waypoint wp in wpList)
        {
            if (wp.isAvailable == true && wp.GetWaeightOfWaypoint() >= weight)
            {
                availableWaypoints.Add(wp);
            }
        }
        int index;
        index = Random.Range(0, availableWaypoints.Count);
        return wpList[index];
    }

    /// <summary>
    /// Метод находит ближайшую точку 
    /// </summary>
    /// <returns>Возвращает Waypoint object</returns>
    public Waypoint FindTheClosest()
    {
        float lowestDist = Mathf.Infinity;

        for (int i = 0; i < wpList.Count; i++)
        {
            //Debug.Log("get closest, How many times is it calls?");

            float dist = Vector3.Distance(wpList[i].transform.position, transform.position);

            if (dist < lowestDist)
            {
                lowestDist = dist;
                _closestWp = wpList[i];
            }
        }
        return _closestWp;
    }

    /// <summary>
    /// Метод останавливает анимацию работы
    /// </summary>
    public void StopWork(string name)
    {
        if (isWorking)
        {
            isWorking = false;
            workParticle.SetActive(false);
            Waypoint wp = FindTheClosest();
            wp.GetComponent<Work>().StopCoroutine("Working");
            wp.GetComponent<Work>().StopParticle();
            wp.CurrentUser.Remove(name);
        }
        //Debug.Log("Stop Working");
        //_animator.SetTrigger("Walk");

    }
}

