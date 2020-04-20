using EmeraldAI;
using System.Collections;
using UnityEngine;

public class Work : MonoBehaviour
{
    [SerializeField] private int _emoteAnimationIndex;

    private EmeraldAIEventsManager _eventSystem;

    private void OnTriggerEnter(Collider other)
    {
        _eventSystem = other.GetComponent<EmeraldAIEventsManager>();

        // Останавливаем движение NPC до окончания анимации
        StartCoroutine(Working(other.GetComponent<AnimationsArray>().TalkingRingLength));
    }

    private IEnumerator Working(float delay)
    {
        _eventSystem.StopMovement();
        _eventSystem.PlayEmoteAnimation(_emoteAnimationIndex);
        yield return new WaitForSeconds(delay);
        _eventSystem.ResumeMovement();
    }
}
