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
    //[SerializeField] private EmeraldAISystem _emeraldAISystem;
    [SerializeField] private LayerMask _walkOn;
    [SerializeField] private float _timerToGo = .1f;
    //[SerializeField] private int indexTelekineticAnimation = 0;
    [SerializeField] private float delayToWander = 2f;

    private NavMeshAgent _navMeshAgent;
    //private EmeraldAIEventsManager _eventManager;
    private CharacterWaypointsNavigation _wpNavigation;
    private float _touchTimer = 0;
    private float _wanderTimer = 0;

    private void Awake()
    {
        _navMeshAgent = _player.GetComponent<NavMeshAgent>();
        //_eventManager = GetComponent<EmeraldAIEventsManager>();
        _wpNavigation = _player.GetComponent<CharacterWaypointsNavigation>();
    }
    private void Update()
    {
        //Запускаем движение по waypoints после достижения точки заданной игроком
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.5f)
        {
            _wanderTimer += 0.001f;
            if (_wanderTimer > _timerToGo)
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
            //_emeraldAISystem.Activate();
            //Выключаеманимацию телекинеза
            //_eventManager.StopLoopEmoteAnimation(indexTelekineticAnimation);
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
                        //_emeraldAISystem.Deactivate();

                        //Включаем анимацию телекинеза
                        //_navMeshAgent.LoopEmoteAnimation(indexTelekineticAnimation);
                    }
                }
                _telekineticEngine.AddRotationForce(Input.GetAxis("Mouse X") * Time.deltaTime * _rotateSpeed);
            }
        }
    }
}
