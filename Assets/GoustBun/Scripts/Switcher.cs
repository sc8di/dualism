using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    [Header("Основные настройки")]
    [Tooltip("Список контролируемых объектов.")]
    [SerializeField] GameObject[] targets = new GameObject[0];
    [Tooltip("Запуск через столкновение или триггер. Если отключено, можно запускать внешним скриптом через StartProcess")]
    [SerializeField] bool switchByColliderOrTrigger = true;
    [Tooltip("Отступ времени до активации.")]
    [SerializeField] float timeBeforeSwitch = 3f;
    [Space]

    [Header("Реверсивные функции")]
    [Tooltip("Активирует реверсивную функцию - возвращает исходное состояние объекта через определенное время.")]
    [SerializeField] bool reverse = false;
    [Tooltip("Отступ времени до реверсии.")]
    [SerializeField] float timeBeforeReverse = 5f;
    [Space]

    [Header("Уничтожение")]
    [Tooltip("Уничтожает компонент вместо его отключения. Если активно, то реверсивные функции не будут запускаться. Уничтожает себя.")]
    [SerializeField] bool destroyInstead = false;
    [Tooltip("Уничтожает запустивший функцию объект. Работает только когда включено уничтожение.")]
    [SerializeField] bool destroyActivator = false;

    GameObject activatorToDestroy;
    float switchTimer = 0;
    float reverseTimer = 0;
    bool switchingActive = false;

    [SerializeField] string[] tagsAllowed;

    private void OnDrawGizmos()
    {
        if (targets.Length > 0)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] != null)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawLine(transform.position, targets[i].transform.position);
                }
            }
        }
    }

    //Используем два варианта активации. Для триггера и для коллизии.
    private void OnTriggerEnter(Collider collision)
    {
        StartProcess(collision);
    }
    private void OnCollisionEnter(Collision collision)
    {
        StartProcess(collision.collider);
    }

    /// <summary>
    /// Активация процесса отключения/удаления объекта. Вызывается приватно при коллизии или триггере.
    /// </summary>
    /// <param name="collision"></param>
    private void StartProcess(Collider collision)
    {
        if (!switchingActive && switchByColliderOrTrigger)
        {
            foreach (string tag in tagsAllowed)
            {
                if (collision.gameObject.CompareTag(tag))
                {
                    if (destroyActivator)
                    {
                        activatorToDestroy = collision.gameObject;
                    }
                    StartProcess();
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Отключение объекта, если будет вызываться через внешний скрипт или событие.
    /// </summary>
    public void StartProcess()
    {
        if (!switchingActive)
        {
            switchTimer = 0;
            reverseTimer = 0;
            switchingActive = true;
            StartCoroutine(DisableCountdown());
        }
    }

    private IEnumerator DisableCountdown()
    {
        while (switchTimer <= timeBeforeSwitch)
        {
            switchTimer += Time.deltaTime;
            yield return null;
        }
        if (destroyInstead)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i])
                {
                    Destroy(targets[i]);
                    if (destroyActivator && activatorToDestroy)
                    {
                        Destroy(activatorToDestroy);
                    }
                }
            }
            Destroy(gameObject);
        }
        SwitchTargets();
        if (reverse)
        {
            while (reverseTimer <= timeBeforeReverse)
            {
                reverseTimer += Time.deltaTime;
                yield return null;
            }
            SwitchTargets();
        }
        switchingActive = false;
    }

    /// <summary>
    /// Переключает состояние объектов в массиве.
    /// </summary>
    private void SwitchTargets()
    {
        if (targets.Length > 0)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] != null)
                {
                    targets[i].SetActive(!targets[i].activeInHierarchy);
                }
            }
        }
    }
}
