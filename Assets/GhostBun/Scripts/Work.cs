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

    [SerializeField] GameObject gesture;
    [SerializeField] GameObject[] _activeGesture;
    [SerializeField] BoxCollider clicableBox;
    [SerializeField] AnimationsArray animLength;
    [SerializeField] float changeNeedAmount;
    [SerializeField] [Range(0, 4)] int needID;

    private int _workAnimationIndex;
    private float _timer;

    private void Start()
    {
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

                StartWorking(other.name);
                // Останавливаем движение NPC до окончания анимации
                StartCoroutine(Working(animLength.AnimationsLength[_workAnimationIndex], other.name));
                StartCoroutine(TurnOffCollider(turnOffTrigerTime + animLength.AnimationsLength[_workAnimationIndex], other.name));
                //StartCoroutine(TurnOffParticle(animLength.AnimationsLength[_workAnimationIndex]));
                
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
                StartCoroutine(Working(animLength.AnimationsLength[_workAnimationIndex], other.name));
                StartCoroutine(TurnOffCollider(turnOffTrigerTime + animLength.AnimationsLength[_workAnimationIndex], other.name));
                //StartCoroutine(TurnOffParticle(animLength.AnimationsLength[_workAnimationIndex]));
            }
        }
    }

    private void ChangeNeed()
    {
        Managers.Player.ChangeNeed(needID, changeNeedAmount);
    }

    /// <summary>
    /// Включаем анимацию работы  
    /// </summary>
    /// <param name="delay">Время после которого персанаж возобновит движение</param>
    /// <returns></returns>
    private IEnumerator Working(float delay, string name)
    {
        gesture.SetActive(false);

        yield return new WaitForSeconds(_navMeshAgent.speed / 20);

        _animator.SetBool("Work", false);
        _navMeshAgent.isStopped = true;
        

        yield return new WaitForSeconds(delay);

        _animator.SetTrigger("Walk");
        _navMeshAgent.isStopped = false;
        _waypoint.CurrentUser.Remove(name);
        _wpNavigation.workParticle.SetActive(false);
        _wpNavigation.isWorking = false;
        if (name == "Player")
            _activeGesture[needID].SetActive(false);




        yield return new WaitForEndOfFrame();
        //Изменение потребности после оконачания анимации.
        if (name == "Player")
            ChangeNeed();
        _wpNavigation.GoToRandomPoint();
        Debug.Log("Go after work");
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
        clicableBox.enabled = true;
        gesture.SetActive(true);

    }
    private void StartWorking(string name)
    {
        if (!_wpNavigation.isWorking)
        {
            clicableBox.enabled = false;
            _wpNavigation.isWorking = true;
            _wpNavigation.workParticle.SetActive(true);
            _waypoint.SetAvailability(false);
            _animator.SetBool("Work", true);
            _animator.SetInteger("Index", _workAnimationIndex);
            if (name == "Player")
                _activeGesture[needID].SetActive(true);
        }
    }

    public void StopParticle()
    {
        _activeGesture[needID].SetActive(false);
        //gesture.transform.position -= gestureMove;
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


