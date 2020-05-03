using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using EmeraldAI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 50f;
    [SerializeField] private TelekineticEngine _telekineticEngine;
    [SerializeField] private GameObject _player;
    [SerializeField] private LayerMask _walkOn;
    [SerializeField] private float _timerToGo = .1f;
    [SerializeField] private float delayToWander = 0.5f;

    private NavMeshAgent _navMeshAgent;
    private CharacterWaypointsNavigation _wpNavigation;
    private Animator _animator;
    private float _touchTimer = 0;
    private float _wanderTimer = 0;

    private void Awake()
    {
        _animator = _player.GetComponent<Animator>();
        _navMeshAgent = _player.GetComponent<NavMeshAgent>();
        _wpNavigation = _player.GetComponent<CharacterWaypointsNavigation>();
    }

    private void Update()
    {
        //Запускаем движение по waypoints после достижения точки заданной игроком
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.5f 
                || _navMeshAgent.velocity == Vector3.zero)
        {
            Debug.Log("How many times is it calls?");
            _wanderTimer += Time.deltaTime;
            if (_wanderTimer > delayToWander)// я не согласен что контролировать два таймера одной переменной хорошая идея
            {
                _wpNavigation.goToMove();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _touchTimer = 0;
            _wanderTimer = 0;
        }
            

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //Отключаем телекинез
            _telekineticEngine.DisableTelekineticField();

            _wpNavigation.goToMove();
            //Включаем персонажу мозг.
            _navMeshAgent.isStopped = false;
            //Выключаеманимацию телекинеза
            _animator.SetTrigger("Walk");
            //Добавил для остановки после телекинеза. Когда он к вейпоинту бежит сразу после телекинеза - пиздецки бесит.
            _navMeshAgent.isStopped = true;
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_player.transform.position);
            _wanderTimer = 0;

            if (_touchTimer < _timerToGo)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 100, _walkOn))
                    _navMeshAgent.SetDestination(hit.point);
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {            
            if (_touchTimer < _timerToGo)       //Когда ждем на левую почку крысы     
                _touchTimer += Time.deltaTime; // Жопускаем таймер.
            else
            {                
                //По окончанию тиканья таймера начинаем включать телекинез
                //Если он не активен в момент после окончания работы таймера, то запускаем его процесс.
                if(!_telekineticEngine.TelekineticFieldEnabled())
                {                    
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Кастуем позицию куда поставить телекинез.
                    if (Physics.Raycast(ray, out RaycastHit hit, 100, _walkOn)) // Если кастанули по нужному слою, ставим туда телекинез.
                    {
                        _telekineticEngine.SetLocation(hit.point);
                        _telekineticEngine.EnableTelekineticField();

                        // Отключаем мозг персонажа.
                        _navMeshAgent.isStopped = true;
                        //Включаем анимацию телекинеза
                        _animator.SetTrigger("Telekinetic");
                    }
                }
                _telekineticEngine.AddRotationForce(Input.GetAxis("Mouse X") * Time.deltaTime * _rotateSpeed);
            }
        }
    }
}
