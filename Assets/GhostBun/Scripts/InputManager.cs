using UnityEngine;
using UnityEngine.AI;
using EmeraldAI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 50f;
    [SerializeField] private TelekineticEngine _telekineticEngine;
    [SerializeField] private GameObject _player;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private LayerMask _walkOn;
    [SerializeField] private float _timerToGo = .1f;
    [SerializeField] private PowerTrip _PowerTrip;

    public bool EnablePointForce = false;
    public int indexTelekineticAnimation = 0;

    private EmeraldAIEventsManager _eventManager;
    private float _touchTimer = 0;

    private void Awake()
    {
        _eventManager = _player.GetComponent<EmeraldAIEventsManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _touchTimer = 0;

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //Отключаем телекинез
            if (EnablePointForce)
                _PowerTrip.DisableField();            
            else            
                _telekineticEngine.DisableTelekineticField();
            

            //Включаем персонажу мозг.
            _navMeshAgent.enabled = true;
            //Выключаеманимацию телекинеза
            _eventManager.StopLoopEmoteAnimation(indexTelekineticAnimation);
            if (_touchTimer < _timerToGo)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 100, _walkOn))                
                    _navMeshAgent.destination = hit.point;                
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
                if(!_telekineticEngine.TelekineticFieldEnabled() || (EnablePointForce && !_PowerTrip.gameObject.activeInHierarchy))
                {                    
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Кастуем позицию куда поставить телекинез.
                    if (Physics.Raycast(ray, out RaycastHit hit, 100, _walkOn)) // Если кастанули по нужному слою, ставим туда телекинез.
                    {
                        if (EnablePointForce)
                        {
                            _PowerTrip.SetLocation(hit.point);
                            _PowerTrip.EnableField();
                        }
                        else
                        {
                            _telekineticEngine.SetLocation(hit.point);
                            _telekineticEngine.EnableTelekineticField();
                        }                         
                        _navMeshAgent.enabled = false; // Отключаем мозг персонажа.
                        //Включаем анимацию телекинеза
                        _eventManager.LoopEmoteAnimation(indexTelekineticAnimation);
                    }
                }
                _telekineticEngine.AddRotationForce(Input.GetAxis("Mouse X") * Time.deltaTime * _rotateSpeed);
            }
        }
    }
}
