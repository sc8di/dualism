using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsArray : MonoBehaviour
{
    //На Start and Awake не подключает аниматор
    [SerializeField] Animator animator;

    private float talkingRingLength;

    public float TalkingRingLength { get; private set; }

    private void Start()
    {
        GetAnimationLength();
    }
    private void GetAnimationLength()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Talking Ring":
                    TalkingRingLength = clip.length;
                    Debug.Log("Talking Ring: " + TalkingRingLength);
                    break;
            }
        }
    }
}
