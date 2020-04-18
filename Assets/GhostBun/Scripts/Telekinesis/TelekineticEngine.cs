using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekineticEngine : MonoBehaviour
{
    [SerializeField] float verticalOffset = 1f;
    [SerializeField] GameObject playerMark;
    [SerializeField] GameObject anchorMark;
    [SerializeField] TelekineticField teleField;
    [SerializeField] LayerMask playerCollideOn;
    [SerializeField] CapsuleCollider mainCollider;
    [SerializeField] Rigidbody rb;

    GameObject player;

    bool enablingPhase = false;

    float distanceOffset = 1f;
    float rotationForce = 0f;

    //Во время FixedUpdate перемещаем марки к тем позициям, где они должны быть. 
    //С чилдами это не работает.
    private void FixedUpdate()
    {
        if (!enablingPhase && TelekineticFieldEnabled())
        {    //Добавляем скорости вращения по Y
            rb.AddTorque(Vector3.up * rotationForce, ForceMode.Acceleration);
            //апдейтим позиции наших марок.
            playerMark.transform.position = transform.position + transform.forward * distanceOffset;
            anchorMark.transform.position = transform.position - transform.forward * distanceOffset;
            //Перетаскиваем игрока на марку игрока
            player.transform.position = playerMark.transform.position;
        }
    }

    //Это фиксит безумие физики.
    protected void LateUpdate()
    {
        //Рижидбади перезаписывает вращение на фазе FixedUpdate, поэтому мы как последние извращенцы делаем это в LateUpdate, чтобы RB не успел все испортить.
        if (enablingPhase)
        {
            mainCollider.enabled = true;
            //Пересчитываем дистанцию, которая должна быть между марками
            SetDistanceBetweenPoints(Vector3.Distance(transform.position, player.transform.position));
            //Поворачиваем наш телекинез в сторону персонажа, чтобы красиво поднять его в воздух. Без этого он как аутист начинает телепортироваться по уровню.
            transform.LookAt(player.transform);
            //Активируем телекинез
            teleField.gameObject.SetActive(true);
            //Завершаем фазу.
            enablingPhase = false;
        }

        if (!enablingPhase && TelekineticFieldEnabled())
        {
            //Несмотря на то, что мы установили ограничения по вращению X и Z, RB считает, что она умнее и при AddTorque начинает беспорядочно бесоебить.
            //Исправляем это своими силами.
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }

    /// <summary>
    /// Устанавливаем кто игрок. Его будем поднимать.
    /// </summary>
    /// <param name="player"></param>
    public void SetPlayerAsTarget(GameObject player)
    {
        this.player = player;
    }

    /// <summary>
    /// Проверяем работает ли телекинез.
    /// </summary>
    /// <returns></returns>
    public bool TelekineticFieldEnabled()
    {
        return teleField.gameObject.activeInHierarchy;
    }

    /// <summary>
    /// Функция для запуска телекинеза. Сам процесс будет проходить в LateUpdate.
    /// </summary>
    public void EnableTelekineticField()
    {
        enablingPhase = true;
    }

    /// <summary>
    /// Отключаем телекинез и сбрасываем скорость вращения нашего RB.
    /// </summary>
    public void DisableTelekineticField()
    {
        rb.angularVelocity = Vector3.zero;
        rotationForce = 0f;
        rb.rotation = Quaternion.Euler(Vector3.zero);
        teleField.gameObject.SetActive(false);
        mainCollider.enabled = false;
    }

    /// <summary>
    /// Телепортируем телекинез в точку.
    /// </summary>
    /// <param name="newLocation"></param>
    public void SetLocation(Vector3 newLocation)
    {
        transform.position = newLocation + Vector3.up * verticalOffset;
    }

    /// <summary>
    /// Определяем расстояние между марками. Апдейтим наш коллайдер и сбрасываем центр масс.
    /// </summary>
    /// <param name="distance"></param>
    public void SetDistanceBetweenPoints(float distance)
    {
        distanceOffset = distance;
        mainCollider.center = distance * Vector3.forward + Vector3.up;
        rb.centerOfMass = Vector3.zero;
    }

    /// <summary>
    /// Сила для вращения телекинеза.
    /// </summary>
    /// <param name="force"></param>
    public void AddRotationForce(float force)
    {
        rotationForce = force;
    }
}
