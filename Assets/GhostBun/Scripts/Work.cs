using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmeraldAI;

public class Work : MonoBehaviour
{
    [SerializeField] int emoteAnimationIndex;

    private EmeraldAIEventsManager eventSystem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            eventSystem = other.GetComponent<EmeraldAIEventsManager>();

            // Останавливаем движение NPC до окончания анимации
            StartCoroutine(Working(other.GetComponent<AnimationsArray>().AnimationsLength[emoteAnimationIndex]));
        }
        
    }

    private IEnumerator Working(float delay)
    {
        eventSystem.StopMovement();

        eventSystem.PlayEmoteAnimation(emoteAnimationIndex);

        yield return new WaitForSeconds(delay);

        eventSystem.ResumeMovement();
    }
}
