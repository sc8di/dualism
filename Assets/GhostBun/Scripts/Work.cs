using EmeraldAI;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Work : MonoBehaviour
{
    public enum Tag { Player,NPC, Both}

    public Tag chooseTag;
    public enum WorkAnimation 
    { 
        WorkOnComputer,
        InteractWithDocuments,
        InteractWithPrinter,
        Documents,
        Ring,
        SitAndWorkOnComputer,
        Talking,
        Looking,
        TalkingSit,
    }
    
    public WorkAnimation Animation;

    public float turnOffTrigerTime = 10f;
    public Vector3 gestureMove = new Vector3(-0.5f, 1f, -0.5f);

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private CharacterWaypointsNavigation _wpNavigation;
    private Waypoint _waypoint;
    private PlayerManager pm;

    [SerializeField] ParticleSystem gesture;
    [SerializeField] AnimationsArray animLength;
    [SerializeField] float changeNeedAmount;
    [SerializeField] [Range(0, 4)] int needID;

    private int _workAnimationIndex;

    private void Start()
    {
        pm = FindObjectOfType<PlayerManager>();
        SetAnimationClip();
        _waypoint = GetComponent<Waypoint>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(chooseTag == Tag.Both)
        {
            if (other.CompareTag("Player") && _waypoint.CurrentUser.Contains(other.name)
                || other.CompareTag("NPC") && _waypoint.CurrentUser.Contains(other.name))
            //if (other.CompareTag("Player") || other.CompareTag("NPC"))
            {
                //Debug.Log("Worker on point: " + _emoteAnimationIndex);
                _animator = other.GetComponent<Animator>();
                _navMeshAgent = other.GetComponent<NavMeshAgent>();
                _wpNavigation = other.GetComponent<CharacterWaypointsNavigation>();

                // Останавливаем движение NPC до окончания анимации
                StartCoroutine(Working(animLength.AnimationsLength[_workAnimationIndex], other.tag));
                StartCoroutine(TurnOffCollider(turnOffTrigerTime + animLength.AnimationsLength[_workAnimationIndex], other.tag));
            }
        }
        else
        {
            //Debug.Log("Worker on point: " + _emoteAnimationIndex);
            if (other.CompareTag(chooseTag.ToString()) && _waypoint.CurrentUser.Contains(other.name))
            //if (other.CompareTag(chooseTag.ToString()))
            {
                Debug.Log("Worker on point: " + _workAnimationIndex);
                _animator = other.GetComponent<Animator>();
                _navMeshAgent = other.GetComponent<NavMeshAgent>();
                _wpNavigation = other.GetComponent<CharacterWaypointsNavigation>();

                // Останавливаем движение NPC до окончания анимации
                StartCoroutine(Working(animLength.AnimationsLength[_workAnimationIndex], other.tag));
                StartCoroutine(TurnOffCollider(turnOffTrigerTime + animLength.AnimationsLength[_workAnimationIndex], other.tag));
            }
        }
    }

    private void ChangeNeed()
    {
        //pm.ChangeNeed(needID, changeNeedAmount);
    }

    /// <summary>
    /// Включаем анимацию работы  
    /// </summary>
    /// <param name="delay">Время после которого персанаж возобновит движение</param>
    /// <returns></returns>
    private IEnumerator Working(float delay, string name)
    {
        _wpNavigation.isWorking = true;
        _waypoint.SetAvailability(false);
        gesture.transform.position += gestureMove;

        yield return new WaitForSeconds(_navMeshAgent.speed / 10);

        _navMeshAgent.isStopped = true;
        _animator.SetTrigger("Work");
        _animator.SetInteger("Index", _workAnimationIndex);
        

        yield return new WaitForSeconds(delay);

        _navMeshAgent.isStopped = false;
        _wpNavigation.isWorking = false;
        gesture.transform.position -= gestureMove;

        if (name == "Player")
            ChangeNeed(); //Изменение потребности после оконачания анимации.
        yield return new WaitForEndOfFrame();
        _wpNavigation.GoToRandomPoint();
    }

    /// <summary>
    /// Выключаем колайдер на какое-то время что бы предотвратить павторный вызов
    /// </summary>
    /// <param name="delay">Время отключения колайдера</param>
    /// <returns></returns>
    private IEnumerator TurnOffCollider(float delay, string name)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(delay);

        gameObject.GetComponent<BoxCollider>().enabled = true;
        _waypoint.SetAvailability(true);
        _waypoint.CurrentUser.Remove(name);
    }

    private void SetAnimationClip()
    {
        switch (Animation)
        {
            case WorkAnimation.WorkOnComputer:
                _workAnimationIndex = 0;
                break;
            case WorkAnimation.InteractWithDocuments:
                _workAnimationIndex = 1;
                break;
            case WorkAnimation.InteractWithPrinter:
                _workAnimationIndex = 2;
                break;
            case WorkAnimation.Documents:
                _workAnimationIndex = 3;
                break;
            case WorkAnimation.Ring:
                _workAnimationIndex = 4;
                break;
            case WorkAnimation.SitAndWorkOnComputer:
                _workAnimationIndex = 5;
                break;
            case WorkAnimation.Talking:
                _workAnimationIndex = 6;
                break;
            case WorkAnimation.Looking:
                _workAnimationIndex = 7;
                break;
            case WorkAnimation.TalkingSit:
                _workAnimationIndex = 8;
                break;
        }
    }
}


