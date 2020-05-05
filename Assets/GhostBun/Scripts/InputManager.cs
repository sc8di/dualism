using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using EmeraldAI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 50f;
    [SerializeField] private GameObject _player;
    [SerializeField] private LayerMask _walkOn;
    [SerializeField] private float _timerToGo = .1f;

    private TelekineticEngine _telekineticEngine;
    private NavMeshAgent _navMeshAgent;
    private CharacterWaypointsNavigation _wpNavigation;
    private Animator _animator;
    private float _touchTimer = 0;

    private void Awake()
    {
        _telekineticEngine = FindObjectOfType<TelekineticEngine>();
        _animator = _player.GetComponent<Animator>();
        _navMeshAgent = _player.GetComponent<NavMeshAgent>();
        _wpNavigation = _player.GetComponent<CharacterWaypointsNavigation>();
    }
    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _touchTimer = 0;
        }
        

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (_touchTimer < _timerToGo)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 100, _walkOn))
                {
                    _navMeshAgent.SetDestination(hit.point);
                    _wpNavigation.StopWork(_player.name);
                }
            }
            else //В любом случае если таймер больше чем таймер ту го, то мы скорее всего юзали телекинез.
            {
                //Отключаем телекинез
                _telekineticEngine.DisableTelekineticField();
                //_wpNavigation.goToMove();
                _wpNavigation.goToMove();
                //Выключаеманимацию телекинеза
                _animator.SetTrigger("Walk");
                //Включаем персонажу мозг.
                _navMeshAgent.isStopped = false;
                _navMeshAgent.SetDestination(_player.transform.position); //Чтобы сразу после телекинеза немного постоял, а не ломился невесть куда.
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {            
            if (_touchTimer < _timerToGo)       //Когда ждем на левую почку крысы     
                _touchTimer += Time.deltaTime;  //Запускаем таймер.
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
                        // Вырубаем аниимацию работы
                        _wpNavigation.StopWork(_player.name);
                        //Включаем анимацию телекинеза
                        _animator.SetTrigger("Telekinetic");
                    }
                }
                _telekineticEngine.AddRotationForce(Input.GetAxis("Mouse X") * Time.deltaTime * _rotateSpeed);
            }
        }
    }
}
