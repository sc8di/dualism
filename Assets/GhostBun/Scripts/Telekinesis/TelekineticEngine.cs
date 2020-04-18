using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekineticEngine : MonoBehaviour
{

    [SerializeField]
    float verticalOffset = 1f;

    GameObject player;

    [SerializeField]
    GameObject playerMark;

    [SerializeField]
    GameObject anchorMark;

    [SerializeField]
    TelekineticField tf;

    [SerializeField]
    LayerMask playerCollideOn;

    public void SetPlayerAsTarget(GameObject player)
    {
        this.player = player;
    }

    public bool TelekineticFieldEnabled()
    {
        return tf.gameObject.activeInHierarchy;
    }

    public void EnableTelekineticField()
    {
        SetDistance(Vector3.Distance(transform.position, player.transform.position));
        transform.LookAt(player.transform, Vector3.up);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        //Включаем телекинез.
        tf.gameObject.SetActive(true);
    }

    public void DisableTelekineticField()
    {
        tf.gameObject.SetActive(false);
        transform.eulerAngles = Vector3.zero;
    }

    public void SetLocation(Vector3 newLocation)
    {
        transform.position = newLocation + Vector3.up * verticalOffset;
    }

    public void SetDistance(float distance)
    {
        playerMark.transform.localPosition = transform.forward * distance;
        anchorMark.transform.localPosition = -transform.forward * distance;
    }

    //Проверяем поворот по горизонту
    public void ChangeVectorHorizontal(float angle)
    {
        //Сохраняем текущие значения
        Vector3 lastAngle = transform.eulerAngles;
        Vector3 lastPlayerMarkPosition = playerMark.transform.position;
        //Меняем значения
        transform.eulerAngles += new Vector3(0, angle, 0);
        //Проверяем возможны ли эти изменения
        Debug.DrawLine(lastPlayerMarkPosition, playerMark.transform.position);
        float distanceDelta = Vector3.Distance(playerMark.transform.position, lastPlayerMarkPosition);
        if (!Physics.CapsuleCast(transform.up + lastPlayerMarkPosition, -transform.up + lastPlayerMarkPosition, 0.4f, playerMark.transform.position - lastPlayerMarkPosition, distanceDelta, playerCollideOn))
        {
            //Если ничего не мешает, применяем положение персонажа.
            player.transform.position = playerMark.transform.position;
        }
        else
        {
            //Иначе отменячем изменения.
            transform.eulerAngles = lastAngle;
            playerMark.transform.position = lastPlayerMarkPosition;
        }

    }
}
