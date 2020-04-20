using UnityEngine;
using UnityEngine.UIElements;

public class TelekineticEngine : MonoBehaviour
{
    [SerializeField] private float _verticalOffset = 1f;
    [SerializeField] private Transform _playerMark;
    [SerializeField] private Transform _anchorMark;
    [SerializeField] private Transform _player;
    [SerializeField] private TelekineticField _teleField;
    [SerializeField] private LayerMask _playerCollideOn;
    [SerializeField] private CapsuleCollider _mainCollider;
    [SerializeField] private Rigidbody _body;

    private bool _enablingPhase = false;
    private float _distanceOffset = 1f;
    private float _rotationForce = 0f;

    //Во время FixedUpdate перемещаем марки к тем позициям, где они должны быть. 
    //С чилдами это не работает.
    private void FixedUpdate()
    {
        if (!_enablingPhase && TelekineticFieldEnabled())
        {    //Добавляем скорости вращения по Y
            _body.AddTorque(Vector3.up * _rotationForce, ForceMode.Acceleration);
            //апдейтим позиции наших марок.
            _playerMark.position = transform.position + transform.forward * _distanceOffset;
            _anchorMark.position = transform.position - transform.forward * _distanceOffset;
            //Перетаскиваем игрока на марку игрока
            _player.position = _playerMark.transform.position;
        }
    }

    //Это фиксит безумие физики.
    protected void LateUpdate()
    {
        //Рижидбади перезаписывает вращение на фазе FixedUpdate, поэтому мы как последние извращенцы делаем это в LateUpdate, чтобы RB не успел все испортить.
        if (_enablingPhase)
        {
            _mainCollider.enabled = true;
            //Пересчитываем дистанцию, которая должна быть между марками
            SetDistanceBetweenPoints(Vector3.Distance(transform.position, _player.transform.position));
            //Поворачиваем наш телекинез в сторону персонажа, чтобы красиво поднять его в воздух. Без этого он как аутист начинает телепортироваться по уровню.
            transform.LookAt(_player.transform);
            //Активируем телекинез
            _teleField.gameObject.SetActive(true);
            //Завершаем фазу.
            _enablingPhase = false;
        }

        if (!_enablingPhase && TelekineticFieldEnabled())
        {
            //Несмотря на то, что мы установили ограничения по вращению X и Z, RB считает, что она умнее и при AddTorque начинает беспорядочно бесоебить.
            //Исправляем это своими силами.
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }


    /// <summary>
    /// Проверяем работает ли телекинез.
    /// </summary>
    /// <returns></returns>
    public bool TelekineticFieldEnabled()
    {
        return _teleField.gameObject.activeInHierarchy;
    }

    /// <summary>
    /// Функция для запуска телекинеза. Сам процесс будет проходить в LateUpdate.
    /// </summary>
    public void EnableTelekineticField()
    {
        _enablingPhase = true;
    }

    /// <summary>
    /// Отключаем телекинез и сбрасываем скорость вращения нашего RB.
    /// </summary>
    public void DisableTelekineticField()
    {
        _body.angularVelocity = Vector3.zero;
        _rotationForce = 0f;
        _body.rotation = Quaternion.Euler(Vector3.zero);
        _teleField.gameObject.SetActive(false);
        _mainCollider.enabled = false;
    }

    /// <summary>
    /// Телепортируем телекинез в точку.
    /// </summary>
    /// <param name="newLocation"></param>
    public void SetLocation(Vector3 newLocation)
    {
        transform.position = newLocation + Vector3.up * _verticalOffset;
    }

    /// <summary>
    /// Определяем расстояние между марками. Апдейтим наш коллайдер и сбрасываем центр масс.
    /// </summary>
    /// <param name="distance"></param>
    public void SetDistanceBetweenPoints(float distance)
    {
        _distanceOffset = distance;
        _mainCollider.center = distance * Vector3.forward + Vector3.up;
        _body.centerOfMass = Vector3.zero;
    }

    /// <summary>
    /// Сила для вращения телекинеза.
    /// </summary>
    /// <param name="force"></param>
    public void AddRotationForce(float force)
    {
        _rotationForce = force;
    }
}
