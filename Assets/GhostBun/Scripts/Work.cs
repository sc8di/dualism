using EmeraldAI;
using System.Collections;
using UnityEngine;

public class Work : MonoBehaviour
{
    public enum Tag { Player,NPC, Both}

    public Tag chooseTag;

    [SerializeField] private int _emoteAnimationIndex;

    private EmeraldAIEventsManager _eventSystem;

    public float turnOffTrigetTime = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if(chooseTag == Tag.Both)
        {
            if (other.CompareTag("Player") || other.CompareTag("NPC"))
            {
                //Debug.Log("Worker on point: " + _emoteAnimationIndex);
                _eventSystem = other.GetComponent<EmeraldAIEventsManager>();

                // Останавливаем движение NPC до окончания анимации
                StartCoroutine(Working(other.GetComponent<AnimationsArray>().AnimationsLength[_emoteAnimationIndex]));
            }
        }
        else
        {
            //Debug.Log("Worker on point: " + _emoteAnimationIndex);
            if (other.CompareTag(chooseTag.ToString()))
            {
                //Debug.Log("Worker on point: " + _emoteAnimationIndex);
                _eventSystem = other.GetComponent<EmeraldAIEventsManager>();

                // Останавливаем движение NPC до окончания анимации
                StartCoroutine(Working(other.GetComponent<AnimationsArray>().AnimationsLength[_emoteAnimationIndex]));
            }
        }
        
        

    }
    /// <summary>
    /// Включаем анимацию работы  
    /// </summary>
    /// <param name="delay">Время после которого персанаж возобновит движение</param>
    /// <returns></returns>
    private IEnumerator Working(float delay)
    {
        _eventSystem.StopMovement();
        _eventSystem.PlayEmoteAnimation(_emoteAnimationIndex);
        yield return new WaitForSeconds(delay);
        _eventSystem.ResumeMovement();
        StartCoroutine(TurnOffCollider(turnOffTrigetTime));
    }

    /// <summary>
    /// Выключаем колайдер на какое-то время что бы предотвратить павторный вызов
    /// </summary>
    /// <param name="delay">Время отключения колайдера</param>
    /// <returns></returns>
    private IEnumerator TurnOffCollider(float delay)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}


