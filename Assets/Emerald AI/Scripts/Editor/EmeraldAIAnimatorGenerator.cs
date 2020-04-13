using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditorInternal;

namespace EmeraldAI.Utility
{
    public class EmeraldAIAnimatorGenerator
    {
        public static void GenerateAnimatorController(EmeraldAISystem EmeraldComponent)
        {
            UnityEditor.Animations.AnimatorController m_AnimatorController = EmeraldComponent.AIAnimator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;

            //Update Attack Animations
            if (EmeraldComponent.AttackAnimationList.Count >= 1)
            {
                EmeraldComponent.Attack1Animation = EmeraldComponent.AttackAnimationList[0].AnimationClip;
                EmeraldComponent.Attack1AnimationSpeed = EmeraldComponent.AttackAnimationList[0].AnimationSpeed;
                EmeraldComponent.TotalAttackAnimations = 1;
            }
            if (EmeraldComponent.AttackAnimationList.Count >= 2)
            {
                EmeraldComponent.Attack2Animation = EmeraldComponent.AttackAnimationList[1].AnimationClip;
                EmeraldComponent.Attack2AnimationSpeed = EmeraldComponent.AttackAnimationList[1].AnimationSpeed;
                if (EmeraldComponent.AttackAnimationList[1] != null)
                {
                    EmeraldComponent.TotalAttackAnimations = 2;
                }
            }
            if (EmeraldComponent.AttackAnimationList.Count >= 3)
            {
                EmeraldComponent.Attack3Animation = EmeraldComponent.AttackAnimationList[2].AnimationClip;
                EmeraldComponent.Attack3AnimationSpeed = EmeraldComponent.AttackAnimationList[2].AnimationSpeed;
                if (EmeraldComponent.AttackAnimationList[2] != null)
                {
                    EmeraldComponent.TotalAttackAnimations = 3;
                }
            }

            //Update Ranged Attack Animations
            if (EmeraldComponent.RangedAttackAnimationList.Count >= 1)
            {
                EmeraldComponent.RangedAttack1Animation = EmeraldComponent.RangedAttackAnimationList[0].AnimationClip;
                EmeraldComponent.RangedAttack1AnimationSpeed = EmeraldComponent.RangedAttackAnimationList[0].AnimationSpeed;
                EmeraldComponent.TotalRangedAttackAnimations = 1;
            }
            if (EmeraldComponent.RangedAttackAnimationList.Count >= 2)
            {
                EmeraldComponent.RangedAttack2Animation = EmeraldComponent.RangedAttackAnimationList[1].AnimationClip;
                EmeraldComponent.RangedAttack2AnimationSpeed = EmeraldComponent.RangedAttackAnimationList[1].AnimationSpeed;
                if (EmeraldComponent.RangedAttackAnimationList[1] != null)
                {
                    EmeraldComponent.TotalRangedAttackAnimations = 2;
                }
            }
            if (EmeraldComponent.RangedAttackAnimationList.Count >= 3)
            {
                EmeraldComponent.RangedAttack3Animation = EmeraldComponent.RangedAttackAnimationList[2].AnimationClip;
                EmeraldComponent.RangedAttack3AnimationSpeed = EmeraldComponent.RangedAttackAnimationList[2].AnimationSpeed;
                if (EmeraldComponent.RangedAttackAnimationList[2] != null)
                {
                    EmeraldComponent.TotalRangedAttackAnimations = 3;
                }
            }

            //Update Idle Animations
            if (EmeraldComponent.IdleAnimationList.Count >= 1)
            {
                EmeraldComponent.Idle1Animation = EmeraldComponent.IdleAnimationList[0].AnimationClip;
                EmeraldComponent.Idle1AnimationSpeed = EmeraldComponent.IdleAnimationList[0].AnimationSpeed;
                EmeraldComponent.TotalIdleAnimations = 1;
            }
            if (EmeraldComponent.IdleAnimationList.Count >= 2)
            {
                EmeraldComponent.Idle2Animation = EmeraldComponent.IdleAnimationList[1].AnimationClip;
                EmeraldComponent.Idle2AnimationSpeed = EmeraldComponent.IdleAnimationList[1].AnimationSpeed;
                if (EmeraldComponent.IdleAnimationList[1] != null)
                {
                    EmeraldComponent.TotalIdleAnimations = 2;
                }
            }
            if (EmeraldComponent.IdleAnimationList.Count >= 3)
            {
                EmeraldComponent.Idle3Animation = EmeraldComponent.IdleAnimationList[2].AnimationClip;
                EmeraldComponent.Idle3AnimationSpeed = EmeraldComponent.IdleAnimationList[2].AnimationSpeed;
                if (EmeraldComponent.IdleAnimationList[2] != null)
                {
                    EmeraldComponent.TotalIdleAnimations = 3;
                }
            }

            //Update Hit Animations
            if (EmeraldComponent.HitAnimationList.Count >= 1)
            {
                EmeraldComponent.Hit1Animation = EmeraldComponent.HitAnimationList[0].AnimationClip;
                EmeraldComponent.Hit1AnimationSpeed = EmeraldComponent.HitAnimationList[0].AnimationSpeed;
                EmeraldComponent.TotalHitAnimations = 1;
            }
            if (EmeraldComponent.HitAnimationList.Count >= 2)
            {
                EmeraldComponent.Hit2Animation = EmeraldComponent.HitAnimationList[1].AnimationClip;
                EmeraldComponent.Hit2AnimationSpeed = EmeraldComponent.HitAnimationList[1].AnimationSpeed;
                if (EmeraldComponent.HitAnimationList[1] != null)
                {
                    EmeraldComponent.TotalHitAnimations = 2;
                }
            }
            if (EmeraldComponent.HitAnimationList.Count >= 3)
            {
                EmeraldComponent.Hit3Animation = EmeraldComponent.HitAnimationList[2].AnimationClip;
                EmeraldComponent.Hit3AnimationSpeed = EmeraldComponent.HitAnimationList[2].AnimationSpeed;
                if (EmeraldComponent.HitAnimationList[2] != null)
                {
                    EmeraldComponent.TotalHitAnimations = 3;
                }
            }

            //Update Combat Hit Animations
            if (EmeraldComponent.CombatHitAnimationList.Count >= 1)
            {
                EmeraldComponent.CombatHit1Animation = EmeraldComponent.CombatHitAnimationList[0].AnimationClip;
                EmeraldComponent.CombatHit1AnimationSpeed = EmeraldComponent.CombatHitAnimationList[0].AnimationSpeed;
                EmeraldComponent.TotalCombatHitAnimations = 1;
            }
            if (EmeraldComponent.CombatHitAnimationList.Count >= 2)
            {
                EmeraldComponent.CombatHit2Animation = EmeraldComponent.CombatHitAnimationList[1].AnimationClip;
                EmeraldComponent.CombatHit2AnimationSpeed = EmeraldComponent.CombatHitAnimationList[1].AnimationSpeed;
                if (EmeraldComponent.CombatHitAnimationList[1] != null)
                {
                    EmeraldComponent.TotalCombatHitAnimations = 2;
                }
            }
            if (EmeraldComponent.CombatHitAnimationList.Count >= 3)
            {
                EmeraldComponent.CombatHit3Animation = EmeraldComponent.CombatHitAnimationList[2].AnimationClip;
                EmeraldComponent.CombatHit3AnimationSpeed = EmeraldComponent.CombatHitAnimationList[2].AnimationSpeed;
                if (EmeraldComponent.CombatHitAnimationList[2] != null)
                {
                    EmeraldComponent.TotalCombatHitAnimations = 3;
                }
            }

            //Update Ranged Combat Hit Animations
            if (EmeraldComponent.RangedCombatHitAnimationList.Count >= 1)
            {
                EmeraldComponent.RangedCombatHit1Animation = EmeraldComponent.RangedCombatHitAnimationList[0].AnimationClip;
                EmeraldComponent.RangedCombatHit1AnimationSpeed = EmeraldComponent.RangedCombatHitAnimationList[0].AnimationSpeed;
                EmeraldComponent.TotalRangedCombatHitAnimations = 1;
            }
            if (EmeraldComponent.RangedCombatHitAnimationList.Count >= 2)
            {
                EmeraldComponent.RangedCombatHit2Animation = EmeraldComponent.RangedCombatHitAnimationList[1].AnimationClip;
                EmeraldComponent.RangedCombatHit2AnimationSpeed = EmeraldComponent.RangedCombatHitAnimationList[1].AnimationSpeed;
                if (EmeraldComponent.RangedCombatHitAnimationList[1] != null)
                {
                    EmeraldComponent.TotalRangedCombatHitAnimations = 2;
                }
            }
            if (EmeraldComponent.RangedCombatHitAnimationList.Count >= 3)
            {
                EmeraldComponent.RangedCombatHit3Animation = EmeraldComponent.RangedCombatHitAnimationList[2].AnimationClip;
                EmeraldComponent.RangedCombatHit3AnimationSpeed = EmeraldComponent.RangedCombatHitAnimationList[2].AnimationSpeed;
                if (EmeraldComponent.RangedCombatHitAnimationList[2] != null)
                {
                    EmeraldComponent.TotalRangedCombatHitAnimations = 3;
                }
            }

            //Update Run Attack Animations
            if (EmeraldComponent.RunAttackAnimationList.Count >= 1)
            {
                EmeraldComponent.RunAttack1Animation = EmeraldComponent.RunAttackAnimationList[0].AnimationClip;
                EmeraldComponent.RunAttack1AnimationSpeed = EmeraldComponent.RunAttackAnimationList[0].AnimationSpeed;
                EmeraldComponent.TotalRunAttackAnimations = 1;
            }
            if (EmeraldComponent.RunAttackAnimationList.Count >= 2)
            {
                EmeraldComponent.RunAttack2Animation = EmeraldComponent.RunAttackAnimationList[1].AnimationClip;
                EmeraldComponent.RunAttack2AnimationSpeed = EmeraldComponent.RunAttackAnimationList[1].AnimationSpeed;
                if (EmeraldComponent.RunAttackAnimationList[1] != null)
                {
                    EmeraldComponent.TotalRunAttackAnimations = 2;
                }
            }
            if (EmeraldComponent.RunAttackAnimationList.Count >= 3)
            {
                EmeraldComponent.RunAttack3Animation = EmeraldComponent.RunAttackAnimationList[2].AnimationClip;
                EmeraldComponent.RunAttack3AnimationSpeed = EmeraldComponent.RunAttackAnimationList[2].AnimationSpeed;
                if (EmeraldComponent.RunAttackAnimationList[2] != null)
                {
                    EmeraldComponent.TotalRunAttackAnimations = 3;
                }
            }

            //Update Ranged Run Attack Animations
            if (EmeraldComponent.RangedRunAttackAnimationList.Count >= 1)
            {
                EmeraldComponent.RangedRunAttack1Animation = EmeraldComponent.RangedRunAttackAnimationList[0].AnimationClip;
                EmeraldComponent.RangedRunAttack1AnimationSpeed = EmeraldComponent.RangedRunAttackAnimationList[0].AnimationSpeed;
                EmeraldComponent.TotalRangedRunAttackAnimations = 1;
            }
            if (EmeraldComponent.RangedRunAttackAnimationList.Count >= 2)
            {
                EmeraldComponent.RangedRunAttack2Animation = EmeraldComponent.RangedRunAttackAnimationList[1].AnimationClip;
                EmeraldComponent.RangedRunAttack2AnimationSpeed = EmeraldComponent.RangedRunAttackAnimationList[1].AnimationSpeed;
                if (EmeraldComponent.RangedRunAttackAnimationList[1] != null)
                {
                    EmeraldComponent.TotalRangedRunAttackAnimations = 2;
                }
            }
            if (EmeraldComponent.RangedRunAttackAnimationList.Count >= 3)
            {
                EmeraldComponent.RangedRunAttack3Animation = EmeraldComponent.RangedRunAttackAnimationList[2].AnimationClip;
                EmeraldComponent.RangedRunAttack3AnimationSpeed = EmeraldComponent.RangedRunAttackAnimationList[2].AnimationSpeed;
                if (EmeraldComponent.RangedRunAttackAnimationList[2] != null)
                {
                    EmeraldComponent.TotalRangedRunAttackAnimations = 3;
                }
            }

            //Update Death Animations
            if (EmeraldComponent.DeathAnimationList.Count >= 1)
            {
                EmeraldComponent.Death1Animation = EmeraldComponent.DeathAnimationList[0].AnimationClip;
                EmeraldComponent.Death1AnimationSpeed = EmeraldComponent.DeathAnimationList[0].AnimationSpeed;
                EmeraldComponent.TotalDeathAnimations = 1;
            }
            if (EmeraldComponent.DeathAnimationList.Count >= 2)
            {
                EmeraldComponent.Death2Animation = EmeraldComponent.DeathAnimationList[1].AnimationClip;
                EmeraldComponent.Death2AnimationSpeed = EmeraldComponent.DeathAnimationList[1].AnimationSpeed;
                if (EmeraldComponent.DeathAnimationList[1] != null)
                {
                    EmeraldComponent.TotalDeathAnimations = 2;
                }
            }
            if (EmeraldComponent.DeathAnimationList.Count >= 3)
            {
                EmeraldComponent.Death3Animation = EmeraldComponent.DeathAnimationList[2].AnimationClip;
                EmeraldComponent.Death3AnimationSpeed = EmeraldComponent.DeathAnimationList[2].AnimationSpeed;
                if (EmeraldComponent.DeathAnimationList[2] != null)
                {
                    EmeraldComponent.TotalDeathAnimations = 3;
                }
            }

            //Update Ranged Death Animations
            if (EmeraldComponent.RangedDeathAnimationList.Count >= 1)
            {
                EmeraldComponent.RangedDeath1Animation = EmeraldComponent.RangedDeathAnimationList[0].AnimationClip;
                EmeraldComponent.RangedDeath1AnimationSpeed = EmeraldComponent.RangedDeathAnimationList[0].AnimationSpeed;
                EmeraldComponent.TotalRangedDeathAnimations = 1;
            }
            if (EmeraldComponent.RangedDeathAnimationList.Count >= 2)
            {
                EmeraldComponent.RangedDeath2Animation = EmeraldComponent.RangedDeathAnimationList[1].AnimationClip;
                EmeraldComponent.RangedDeath2AnimationSpeed = EmeraldComponent.RangedDeathAnimationList[1].AnimationSpeed;
                if (EmeraldComponent.RangedDeathAnimationList[1] != null)
                {
                    EmeraldComponent.TotalRangedDeathAnimations = 2;
                }
            }
            if (EmeraldComponent.RangedDeathAnimationList.Count >= 3)
            {
                EmeraldComponent.RangedDeath3Animation = EmeraldComponent.RangedDeathAnimationList[2].AnimationClip;
                EmeraldComponent.RangedDeath3AnimationSpeed = EmeraldComponent.RangedDeathAnimationList[2].AnimationSpeed;
                if (EmeraldComponent.RangedDeathAnimationList[2] != null)
                {
                    EmeraldComponent.TotalRangedDeathAnimations = 3;
                }
            }

            //Update Emote Animations
            if (EmeraldComponent.EmoteAnimationList.Count >= 1)
            {
                EmeraldComponent.Emote1Animation = EmeraldComponent.EmoteAnimationList[0].EmoteAnimationClip;
                EmeraldComponent.TotalEmoteAnimations = 1;
            }
            if (EmeraldComponent.EmoteAnimationList.Count >= 2)
            {
                EmeraldComponent.Emote2Animation = EmeraldComponent.EmoteAnimationList[1].EmoteAnimationClip;
                if (EmeraldComponent.EmoteAnimationList[1].EmoteAnimationClip != null)
                {
                    EmeraldComponent.TotalEmoteAnimations = 2;
                }
            }
            if (EmeraldComponent.EmoteAnimationList.Count >= 3)
            {
                EmeraldComponent.Emote3Animation = EmeraldComponent.EmoteAnimationList[2].EmoteAnimationClip;
                if (EmeraldComponent.EmoteAnimationList[2].EmoteAnimationClip != null)
                {
                    EmeraldComponent.TotalEmoteAnimations = 3;
                }
            }

            //Go through each sub-state by name and assign the animation to each state within the sub-state using an index
            for (int i = 0; i < m_AnimatorController.layers[0].stateMachine.stateMachines.Length; i++)
            {
                if (m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.name == "Idle States")
                {
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.motion = EmeraldComponent.Idle1Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.speed = EmeraldComponent.Idle1AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.motion = EmeraldComponent.Idle2Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.speed = EmeraldComponent.Idle2AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.motion = EmeraldComponent.Idle3Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.speed = EmeraldComponent.Idle3AnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.name == "Hit States")
                {
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.motion = EmeraldComponent.Hit1Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.speed = EmeraldComponent.Hit1AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.motion = EmeraldComponent.Hit2Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.speed = EmeraldComponent.Hit2AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.motion = EmeraldComponent.Hit3Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.speed = EmeraldComponent.Hit3AnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.name == "Emote States")
                {
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.motion = EmeraldComponent.Emote1Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.speed = EmeraldComponent.Emote1AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.motion = EmeraldComponent.Emote2Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.speed = EmeraldComponent.Emote2AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.motion = EmeraldComponent.Emote3Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.speed = EmeraldComponent.Emote3AnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.name == "Combat Hit States")
                {
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.motion = EmeraldComponent.CombatHit1Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.speed = EmeraldComponent.CombatHit1AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.motion = EmeraldComponent.CombatHit2Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.speed = EmeraldComponent.CombatHit2AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.motion = EmeraldComponent.CombatHit3Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.speed = EmeraldComponent.CombatHit3AnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.name == "Combat Hit States (Ranged)")
                {
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.motion = EmeraldComponent.RangedCombatHit1Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.speed = EmeraldComponent.RangedCombatHit1AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.motion = EmeraldComponent.RangedCombatHit2Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.speed = EmeraldComponent.RangedCombatHit2AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.motion = EmeraldComponent.RangedCombatHit3Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.speed = EmeraldComponent.RangedCombatHit3AnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.name == "Attack States")
                {
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.motion = EmeraldComponent.Attack1Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.speed = EmeraldComponent.Attack1AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.motion = EmeraldComponent.Attack2Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.speed = EmeraldComponent.Attack2AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.motion = EmeraldComponent.Attack3Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.speed = EmeraldComponent.Attack3AnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.name == "Attack States (Ranged)")
                {
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.motion = EmeraldComponent.RangedAttack1Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.speed = EmeraldComponent.RangedAttack1AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.motion = EmeraldComponent.RangedAttack2Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.speed = EmeraldComponent.RangedAttack2AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.motion = EmeraldComponent.RangedAttack3Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.speed = EmeraldComponent.RangedAttack3AnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.name == "Run Attack States")
                {
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.motion = EmeraldComponent.RunAttack1Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.speed = EmeraldComponent.RunAttack1AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.motion = EmeraldComponent.RunAttack2Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.speed = EmeraldComponent.RunAttack2AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.motion = EmeraldComponent.RunAttack3Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.speed = EmeraldComponent.RunAttack3AnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.name == "Run Attack States (Ranged)")
                {
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.motion = EmeraldComponent.RangedRunAttack1Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.speed = EmeraldComponent.RangedRunAttack1AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.motion = EmeraldComponent.RangedRunAttack2Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.speed = EmeraldComponent.RangedRunAttack2AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.motion = EmeraldComponent.RangedRunAttack3Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.speed = EmeraldComponent.RangedRunAttack3AnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.name == "Death States")
                {
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.motion = EmeraldComponent.Death1Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.speed = EmeraldComponent.Death1AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.motion = EmeraldComponent.Death2Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.speed = EmeraldComponent.Death2AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.motion = EmeraldComponent.Death3Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.speed = EmeraldComponent.Death3AnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.name == "Death States (Ranged)")
                {
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.motion = EmeraldComponent.RangedDeath1Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[0].state.speed = EmeraldComponent.RangedDeath1AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.motion = EmeraldComponent.RangedDeath2Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[1].state.speed = EmeraldComponent.RangedDeath2AnimationSpeed;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.motion = EmeraldComponent.RangedDeath3Animation;
                    m_AnimatorController.layers[0].stateMachine.stateMachines[i].stateMachine.states[2].state.speed = EmeraldComponent.RangedDeath3AnimationSpeed;
                }
            }

            //Go through each state by name and assign the animation to the proper state
            for (int i = 0; i < m_AnimatorController.layers[0].stateMachine.states.Length; i++)
            {
                if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Turn Left")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.NonCombatTurnLeftAnimation;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.mirror = EmeraldComponent.MirrorTurnLeft;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.speed = EmeraldComponent.TurnLeftAnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Turn Right")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.NonCombatTurnRightAnimation;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.mirror = EmeraldComponent.MirrorTurnRight;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.speed = EmeraldComponent.TurnRightAnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Pull Out Weapon")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.PullOutWeaponAnimation;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Put Away Weapon")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.PutAwayWeaponAnimation;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Pull Out Weapon (Ranged)")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.RangedPullOutWeaponAnimation;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Put Away Weapon (Ranged)")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.RangedPutAwayWeaponAnimation;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Combat Turn Left")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.CombatTurnLeftAnimation;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.mirror = EmeraldComponent.MirrorCombatTurnLeft;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.speed = EmeraldComponent.CombatTurnLeftAnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Combat Turn Right")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.CombatTurnRightAnimation;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.mirror = EmeraldComponent.MirrorCombatTurnRight;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.speed = EmeraldComponent.CombatTurnRightAnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Combat Turn Left (Ranged)")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.RangedCombatTurnLeftAnimation;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.mirror = EmeraldComponent.MirrorRangedCombatTurnLeft;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.speed = EmeraldComponent.RangedCombatTurnLeftAnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Combat Turn Right (Ranged)")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.RangedCombatTurnRightAnimation;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.mirror = EmeraldComponent.MirrorRangedCombatTurnRight;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.speed = EmeraldComponent.RangedCombatTurnRightAnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Walk Backwards")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.CombatWalkBackAnimation;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Walk Backwards (Ranged)")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.RangedCombatWalkBackAnimation;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Block")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.BlockIdleAnimation;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Block Hit")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.BlockHitAnimation;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Warning")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.IdleWarningAnimation;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.speed = EmeraldComponent.IdleWarningAnimationSpeed;
                }
                else if (m_AnimatorController.layers[0].stateMachine.states[i].state.name == "Warning (Ranged)")
                {
                    m_AnimatorController.layers[0].stateMachine.states[i].state.motion = EmeraldComponent.RangedIdleWarningAnimation;
                    m_AnimatorController.layers[0].stateMachine.states[i].state.speed = EmeraldComponent.RangedIdleWarningAnimationSpeed;
                }
            }

            //Get and assign Movement Blend Tree animations
            UnityEditor.Animations.AnimatorState m_StateMachine = m_AnimatorController.layers[0].stateMachine.states[0].state;
            UnityEditor.Animations.BlendTree MovementBlendTree = m_StateMachine.motion as UnityEditor.Animations.BlendTree;

            var SerializedIdleBlendTreeRef = new SerializedObject(MovementBlendTree);
            var MovementBlendTreeChildren = SerializedIdleBlendTreeRef.FindProperty("m_Childs");

            //Assign our Idle animation and settings to the Idle Blend Tree
            var MovementMotionSlot1 = MovementBlendTreeChildren.GetArrayElementAtIndex(0);
            var MovementMotion1 = MovementMotionSlot1.FindPropertyRelative("m_Motion");
            UnityEditor.Animations.BlendTree IdleBlendTree = MovementMotion1.objectReferenceValue as UnityEditor.Animations.BlendTree;
            var SerializedIdleBlendTree = new SerializedObject(IdleBlendTree);
            var IdleBlendTreeChildren = SerializedIdleBlendTree.FindProperty("m_Childs");
            var IdleMotionSlot = IdleBlendTreeChildren.GetArrayElementAtIndex(0);
            var IdleAnimation = IdleMotionSlot.FindPropertyRelative("m_Motion");
            var IdleAnimationSpeed = IdleMotionSlot.FindPropertyRelative("m_TimeScale");
            IdleAnimationSpeed.floatValue = EmeraldComponent.IdleNonCombatAnimationSpeed;
            IdleAnimation.objectReferenceValue = EmeraldComponent.NonCombatIdleAnimation;
            SerializedIdleBlendTree.ApplyModifiedProperties();

            //Assign our Walk animations and settings to the Walk Blend Tree; one for walk left, walk straight, and walk right.
            var MovementMotionSlot2 = MovementBlendTreeChildren.GetArrayElementAtIndex(1);
            var MovementMotion2 = MovementMotionSlot2.FindPropertyRelative("m_Motion");
            UnityEditor.Animations.BlendTree WalkBlendTree = MovementMotion2.objectReferenceValue as UnityEditor.Animations.BlendTree;
            var SerializedWalkBlendTree = new SerializedObject(WalkBlendTree);
            var WalkBlendTreeChildren = SerializedWalkBlendTree.FindProperty("m_Childs");

            //Adjust our non-combat movement thresholds depending on which Animator Type is being used.
            var WalkMovementMotionThreshold = MovementBlendTreeChildren.GetArrayElementAtIndex(1).FindPropertyRelative("m_Threshold");
            var RunMovementMotionThreshold = MovementBlendTreeChildren.GetArrayElementAtIndex(2).FindPropertyRelative("m_Threshold");

            if (EmeraldComponent.AnimatorType == EmeraldAISystem.AnimatorTypeState.NavMeshDriven)
            {
                WalkMovementMotionThreshold.floatValue = (float)(EmeraldComponent.WalkSpeed);
                RunMovementMotionThreshold.floatValue = (float)(EmeraldComponent.RunSpeed);
            }
            else if (EmeraldComponent.AnimatorType == EmeraldAISystem.AnimatorTypeState.RootMotion)
            {
                WalkMovementMotionThreshold.floatValue = 0.1f;
                RunMovementMotionThreshold.floatValue = 1;
            }

            SerializedIdleBlendTreeRef.ApplyModifiedProperties();

            //Walk Left
            var WalkMotionSlot1 = WalkBlendTreeChildren.GetArrayElementAtIndex(0);
            var WalkLeftAnimation = WalkMotionSlot1.FindPropertyRelative("m_Motion");
            var WalkLeftAnimationSpeed = WalkMotionSlot1.FindPropertyRelative("m_TimeScale");
            var WalkLeftMirror = WalkMotionSlot1.FindPropertyRelative("m_Mirror");
            WalkLeftAnimationSpeed.floatValue = EmeraldComponent.NonCombatWalkAnimationSpeed;
            WalkLeftAnimation.objectReferenceValue = EmeraldComponent.WalkLeftAnimation;
            WalkLeftMirror.boolValue = EmeraldComponent.MirrorWalkLeft;

            //Walk Straight
            var WalkMotionSlot2 = WalkBlendTreeChildren.GetArrayElementAtIndex(1);
            var WalkStraightAnimation = WalkMotionSlot2.FindPropertyRelative("m_Motion");
            var WalkStraightAnimationSpeed = WalkMotionSlot2.FindPropertyRelative("m_TimeScale");
            WalkStraightAnimationSpeed.floatValue = EmeraldComponent.NonCombatWalkAnimationSpeed;
            WalkStraightAnimation.objectReferenceValue = EmeraldComponent.WalkStraightAnimation;

            //Walk Right
            var WalkMotionSlot3 = WalkBlendTreeChildren.GetArrayElementAtIndex(2);
            var WalkRightAnimation = WalkMotionSlot3.FindPropertyRelative("m_Motion");
            var WalkRightAnimationSpeed = WalkMotionSlot3.FindPropertyRelative("m_TimeScale");
            var WalkRightMirror = WalkMotionSlot3.FindPropertyRelative("m_Mirror");
            WalkRightAnimationSpeed.floatValue = EmeraldComponent.NonCombatWalkAnimationSpeed;
            WalkRightAnimation.objectReferenceValue = EmeraldComponent.WalkRightAnimation;
            WalkRightMirror.boolValue = EmeraldComponent.MirrorWalkRight;

            SerializedWalkBlendTree.ApplyModifiedProperties();

            //Assign our Run animations and settings to the Run Blend Tree; one for run left, run straight, and run right.
            var MovementMotionSlot3 = MovementBlendTreeChildren.GetArrayElementAtIndex(2);
            var MovementMotion3 = MovementMotionSlot3.FindPropertyRelative("m_Motion");
            UnityEditor.Animations.BlendTree RunBlendTree = MovementMotion3.objectReferenceValue as UnityEditor.Animations.BlendTree;
            var SerializedRunBlendTree = new SerializedObject(RunBlendTree);
            var RunBlendTreeChildren = SerializedRunBlendTree.FindProperty("m_Childs");

            //Run Left
            var RunMotionSlot1 = RunBlendTreeChildren.GetArrayElementAtIndex(0);
            var RunLeftAnimation = RunMotionSlot1.FindPropertyRelative("m_Motion");
            var RunLeftAnimationSpeed = RunMotionSlot1.FindPropertyRelative("m_TimeScale");
            var RunLeftMirror = RunMotionSlot1.FindPropertyRelative("m_Mirror");
            RunLeftAnimationSpeed.floatValue = EmeraldComponent.NonCombatRunAnimationSpeed;
            RunLeftAnimation.objectReferenceValue = EmeraldComponent.RunLeftAnimation;
            RunLeftMirror.boolValue = EmeraldComponent.MirrorRunLeft;

            //Run Straight
            var RunMotionSlot2 = RunBlendTreeChildren.GetArrayElementAtIndex(1);
            var RunStraightAnimation = RunMotionSlot2.FindPropertyRelative("m_Motion");
            var RunStraightAnimationSpeed = RunMotionSlot2.FindPropertyRelative("m_TimeScale");
            RunStraightAnimationSpeed.floatValue = EmeraldComponent.NonCombatRunAnimationSpeed;
            RunStraightAnimation.objectReferenceValue = EmeraldComponent.RunStraightAnimation;

            //Run Right
            var RunMotionSlot3 = RunBlendTreeChildren.GetArrayElementAtIndex(2);
            var RunRightAnimation = RunMotionSlot3.FindPropertyRelative("m_Motion");
            var RunRightAnimationSpeed = RunMotionSlot3.FindPropertyRelative("m_TimeScale");
            var RunRightMirror = RunMotionSlot3.FindPropertyRelative("m_Mirror");
            RunRightAnimationSpeed.floatValue = EmeraldComponent.NonCombatRunAnimationSpeed;
            RunRightAnimation.objectReferenceValue = EmeraldComponent.RunRightAnimation;
            RunRightMirror.boolValue = EmeraldComponent.MirrorRunRight;

            SerializedRunBlendTree.ApplyModifiedProperties();

            //Get and assign Combat Movement Blend Tree animations
            UnityEditor.Animations.AnimatorState m_StateMachine_Combat = m_AnimatorController.layers[0].stateMachine.states[3].state;
            UnityEditor.Animations.BlendTree CombatMovementBlendTree = m_StateMachine_Combat.motion as UnityEditor.Animations.BlendTree;

            var SerializedCombatIdleBlendTreeRef = new SerializedObject(CombatMovementBlendTree);
            var CombatMovementBlendTreeChildren = SerializedCombatIdleBlendTreeRef.FindProperty("m_Childs");

            //Assign our Idle animation and settings to the Idle Blend Tree
            var CombatMovementMotionSlot1 = CombatMovementBlendTreeChildren.GetArrayElementAtIndex(0);
            var CombatMovementMotion1 = CombatMovementMotionSlot1.FindPropertyRelative("m_Motion");
            UnityEditor.Animations.BlendTree CombatIdleBlendTree = CombatMovementMotion1.objectReferenceValue as UnityEditor.Animations.BlendTree;
            var SerializedCombatIdleBlendTree = new SerializedObject(CombatIdleBlendTree);
            var CombatIdleBlendTreeChildren = SerializedCombatIdleBlendTree.FindProperty("m_Childs");
            var CombatIdleMotionSlot = CombatIdleBlendTreeChildren.GetArrayElementAtIndex(0);
            var CombatIdleAnimation = CombatIdleMotionSlot.FindPropertyRelative("m_Motion");
            var CombatIdleAnimationSpeed = CombatIdleMotionSlot.FindPropertyRelative("m_TimeScale");
            CombatIdleAnimationSpeed.floatValue = EmeraldComponent.IdleCombatAnimationSpeed;
            CombatIdleAnimation.objectReferenceValue = EmeraldComponent.CombatIdleAnimation;
            SerializedCombatIdleBlendTree.ApplyModifiedProperties();

            //Assign our Walk animations and settings to the Walk Blend Tree; one for walk left, walk straight, and walk right.
            var CombatMovementMotionSlot2 = CombatMovementBlendTreeChildren.GetArrayElementAtIndex(1);
            var CombatMovementMotion2 = CombatMovementMotionSlot2.FindPropertyRelative("m_Motion");
            UnityEditor.Animations.BlendTree CombatWalkBlendTree = CombatMovementMotion2.objectReferenceValue as UnityEditor.Animations.BlendTree;
            var SerializedCombatWalkBlendTree = new SerializedObject(CombatWalkBlendTree);
            var CombatWalkBlendTreeChildren = SerializedCombatWalkBlendTree.FindProperty("m_Childs");

            //Adjust our combat movement thresholds depending on which Animator Type is being used.
            var CombatWalkMovementMotionThreshold = CombatMovementBlendTreeChildren.GetArrayElementAtIndex(1).FindPropertyRelative("m_Threshold");
            var CombatRunMovementMotionThreshold = CombatMovementBlendTreeChildren.GetArrayElementAtIndex(2).FindPropertyRelative("m_Threshold");

            if (EmeraldComponent.AnimatorType == EmeraldAISystem.AnimatorTypeState.NavMeshDriven)
            {
                CombatWalkMovementMotionThreshold.floatValue = (float)(EmeraldComponent.WalkSpeed);
                CombatRunMovementMotionThreshold.floatValue = (float)(EmeraldComponent.RunSpeed);
            }
            else if (EmeraldComponent.AnimatorType == EmeraldAISystem.AnimatorTypeState.RootMotion)
            {
                CombatWalkMovementMotionThreshold.floatValue = 0.1f;
                CombatRunMovementMotionThreshold.floatValue = 1;
            }

            SerializedCombatIdleBlendTreeRef.ApplyModifiedProperties();

            //Walk Left
            var CombatWalkMotionSlot1 = CombatWalkBlendTreeChildren.GetArrayElementAtIndex(0);
            var CombatWalkLeftAnimation = CombatWalkMotionSlot1.FindPropertyRelative("m_Motion");
            var CombatWalkLeftAnimationSpeed = CombatWalkMotionSlot1.FindPropertyRelative("m_TimeScale");
            var CombatWalkLeftMirror = CombatWalkMotionSlot1.FindPropertyRelative("m_Mirror");
            CombatWalkLeftAnimationSpeed.floatValue = EmeraldComponent.CombatWalkAnimationSpeed;
            CombatWalkLeftAnimation.objectReferenceValue = EmeraldComponent.CombatWalkLeftAnimation;
            CombatWalkLeftMirror.boolValue = EmeraldComponent.MirrorCombatWalkLeft;

            //Walk Straight
            var CombatWalkMotionSlot2 = CombatWalkBlendTreeChildren.GetArrayElementAtIndex(1);
            var CombatWalkStraightAnimation = CombatWalkMotionSlot2.FindPropertyRelative("m_Motion");
            var CombatWalkStraightAnimationSpeed = CombatWalkMotionSlot2.FindPropertyRelative("m_TimeScale");
            CombatWalkStraightAnimationSpeed.floatValue = EmeraldComponent.CombatWalkAnimationSpeed;
            CombatWalkStraightAnimation.objectReferenceValue = EmeraldComponent.CombatWalkStraightAnimation;

            //Walk Right
            var CombatWalkMotionSlot3 = CombatWalkBlendTreeChildren.GetArrayElementAtIndex(2);
            var CombatWalkRightAnimation = CombatWalkMotionSlot3.FindPropertyRelative("m_Motion");
            var CombatWalkRightAnimationSpeed = CombatWalkMotionSlot3.FindPropertyRelative("m_TimeScale");
            var CombatWalkRightMirror = CombatWalkMotionSlot3.FindPropertyRelative("m_Mirror");
            CombatWalkRightAnimationSpeed.floatValue = EmeraldComponent.CombatWalkAnimationSpeed;
            CombatWalkRightAnimation.objectReferenceValue = EmeraldComponent.CombatWalkRightAnimation;
            CombatWalkRightMirror.boolValue = EmeraldComponent.MirrorCombatWalkRight;

            SerializedCombatWalkBlendTree.ApplyModifiedProperties();

            //Assign our Run animations and settings to the Run Blend Tree; one for run left, run straight, and run right.
            var CombatMovementMotionSlot3 = CombatMovementBlendTreeChildren.GetArrayElementAtIndex(2);
            var CombatMovementMotion3 = CombatMovementMotionSlot3.FindPropertyRelative("m_Motion");
            UnityEditor.Animations.BlendTree CombatRunBlendTree = CombatMovementMotion3.objectReferenceValue as UnityEditor.Animations.BlendTree;
            var SerializedCombatRunBlendTree = new SerializedObject(CombatRunBlendTree);
            var CombatRunBlendTreeChildren = SerializedCombatRunBlendTree.FindProperty("m_Childs");

            //Run Left
            var CombatRunMotionSlot1 = CombatRunBlendTreeChildren.GetArrayElementAtIndex(0);
            var CombatRunLeftAnimation = CombatRunMotionSlot1.FindPropertyRelative("m_Motion");
            var CombatRunLeftAnimationSpeed = CombatRunMotionSlot1.FindPropertyRelative("m_TimeScale");
            var CombatRunLeftMirror = CombatRunMotionSlot1.FindPropertyRelative("m_Mirror");
            CombatRunLeftAnimationSpeed.floatValue = EmeraldComponent.CombatRunAnimationSpeed;
            CombatRunLeftAnimation.objectReferenceValue = EmeraldComponent.CombatRunLeftAnimation;
            CombatRunLeftMirror.boolValue = EmeraldComponent.MirrorCombatRunLeft;

            //Run Straight
            var CombatRunMotionSlot2 = CombatRunBlendTreeChildren.GetArrayElementAtIndex(1);
            var CombatRunStraightAnimation = CombatRunMotionSlot2.FindPropertyRelative("m_Motion");
            var CombatRunStraightAnimationSpeed = CombatRunMotionSlot2.FindPropertyRelative("m_TimeScale");
            CombatRunStraightAnimationSpeed.floatValue = EmeraldComponent.CombatRunAnimationSpeed;
            CombatRunStraightAnimation.objectReferenceValue = EmeraldComponent.CombatRunStraightAnimation;

            //Run Right
            var CombatRunMotionSlot3 = CombatRunBlendTreeChildren.GetArrayElementAtIndex(2);
            var CombatRunRightAnimation = CombatRunMotionSlot3.FindPropertyRelative("m_Motion");
            var CombatRunRightAnimationSpeed = CombatRunMotionSlot3.FindPropertyRelative("m_TimeScale");
            var CombatRunRightMirror = CombatRunMotionSlot3.FindPropertyRelative("m_Mirror");
            CombatRunRightAnimationSpeed.floatValue = EmeraldComponent.CombatRunAnimationSpeed;
            CombatRunRightAnimation.objectReferenceValue = EmeraldComponent.CombatRunRightAnimation;
            CombatRunRightMirror.boolValue = EmeraldComponent.MirrorCombatRunRight;

            if (EmeraldComponent.EnableBothWeaponTypes == EmeraldAISystem.YesOrNo.Yes || EmeraldComponent.WeaponTypeRef == EmeraldAISystem.WeaponType.Ranged)
            {
                ApplyRangedAnimations(EmeraldComponent);
            }

            SerializedCombatRunBlendTree.ApplyModifiedProperties();
            EmeraldComponent.AnimatorControllerGenerated = true;
            EmeraldComponent.AnimationsUpdated = false;
            EmeraldComponent.AnimationListsChanged = false;
        }

        //Assigns all of our Ranged Animations, when Enable Both Weapon Types is enabled.
        static void ApplyRangedAnimations (EmeraldAISystem EmeraldComponent)
        {
            UnityEditor.Animations.AnimatorController m_AnimatorController = EmeraldComponent.AIAnimator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;

            //Get and assign Combat Movement Blend Tree animations
            UnityEditor.Animations.AnimatorState m_StateMachine_Combat = m_AnimatorController.layers[0].stateMachine.states[12].state;
            UnityEditor.Animations.BlendTree CombatMovementBlendTree = m_StateMachine_Combat.motion as UnityEditor.Animations.BlendTree;

            var SerializedCombatIdleBlendTreeRef = new SerializedObject(CombatMovementBlendTree);
            var CombatMovementBlendTreeChildren = SerializedCombatIdleBlendTreeRef.FindProperty("m_Childs");

            //Assign our Idle animation and settings to the Idle Blend Tree
            var CombatMovementMotionSlot1 = CombatMovementBlendTreeChildren.GetArrayElementAtIndex(0);
            var CombatMovementMotion1 = CombatMovementMotionSlot1.FindPropertyRelative("m_Motion");
            UnityEditor.Animations.BlendTree CombatIdleBlendTree = CombatMovementMotion1.objectReferenceValue as UnityEditor.Animations.BlendTree;
            var SerializedCombatIdleBlendTree = new SerializedObject(CombatIdleBlendTree);
            var CombatIdleBlendTreeChildren = SerializedCombatIdleBlendTree.FindProperty("m_Childs");
            var CombatIdleMotionSlot = CombatIdleBlendTreeChildren.GetArrayElementAtIndex(0);
            var CombatIdleAnimation = CombatIdleMotionSlot.FindPropertyRelative("m_Motion");
            var CombatIdleAnimationSpeed = CombatIdleMotionSlot.FindPropertyRelative("m_TimeScale");
            CombatIdleAnimationSpeed.floatValue = EmeraldComponent.RangedIdleCombatAnimationSpeed;
            CombatIdleAnimation.objectReferenceValue = EmeraldComponent.RangedCombatIdleAnimation;
            SerializedCombatIdleBlendTree.ApplyModifiedProperties();

            //Assign our Walk animations and settings to the Walk Blend Tree; one for walk left, walk straight, and walk right.
            var CombatMovementMotionSlot2 = CombatMovementBlendTreeChildren.GetArrayElementAtIndex(1);
            var CombatMovementMotion2 = CombatMovementMotionSlot2.FindPropertyRelative("m_Motion");
            UnityEditor.Animations.BlendTree CombatWalkBlendTree = CombatMovementMotion2.objectReferenceValue as UnityEditor.Animations.BlendTree;
            var SerializedCombatWalkBlendTree = new SerializedObject(CombatWalkBlendTree);
            var CombatWalkBlendTreeChildren = SerializedCombatWalkBlendTree.FindProperty("m_Childs");

            //Adjust our combat movement thresholds depending on which Animator Type is being used.
            var CombatWalkMovementMotionThreshold = CombatMovementBlendTreeChildren.GetArrayElementAtIndex(1).FindPropertyRelative("m_Threshold");
            var CombatRunMovementMotionThreshold = CombatMovementBlendTreeChildren.GetArrayElementAtIndex(2).FindPropertyRelative("m_Threshold");

            if (EmeraldComponent.AnimatorType == EmeraldAISystem.AnimatorTypeState.NavMeshDriven)
            {
                CombatWalkMovementMotionThreshold.floatValue = (float)(EmeraldComponent.WalkSpeed);
                CombatRunMovementMotionThreshold.floatValue = (float)(EmeraldComponent.RunSpeed);
            }
            else if (EmeraldComponent.AnimatorType == EmeraldAISystem.AnimatorTypeState.RootMotion)
            {
                CombatWalkMovementMotionThreshold.floatValue = 0.1f;
                CombatRunMovementMotionThreshold.floatValue = 1;
            }

            SerializedCombatIdleBlendTreeRef.ApplyModifiedProperties();

            //Walk Left
            var CombatWalkMotionSlot1 = CombatWalkBlendTreeChildren.GetArrayElementAtIndex(0);
            var CombatWalkLeftAnimation = CombatWalkMotionSlot1.FindPropertyRelative("m_Motion");
            var CombatWalkLeftAnimationSpeed = CombatWalkMotionSlot1.FindPropertyRelative("m_TimeScale");
            var CombatWalkLeftMirror = CombatWalkMotionSlot1.FindPropertyRelative("m_Mirror");
            CombatWalkLeftAnimationSpeed.floatValue = EmeraldComponent.RangedCombatWalkAnimationSpeed;
            CombatWalkLeftAnimation.objectReferenceValue = EmeraldComponent.RangedCombatWalkLeftAnimation;
            CombatWalkLeftMirror.boolValue = EmeraldComponent.MirrorRangedCombatWalkLeft;

            //Walk Straight
            var CombatWalkMotionSlot2 = CombatWalkBlendTreeChildren.GetArrayElementAtIndex(1);
            var CombatWalkStraightAnimation = CombatWalkMotionSlot2.FindPropertyRelative("m_Motion");
            var CombatWalkStraightAnimationSpeed = CombatWalkMotionSlot2.FindPropertyRelative("m_TimeScale");
            CombatWalkStraightAnimationSpeed.floatValue = EmeraldComponent.RangedCombatWalkAnimationSpeed;
            CombatWalkStraightAnimation.objectReferenceValue = EmeraldComponent.RangedCombatWalkStraightAnimation;

            //Walk Right
            var CombatWalkMotionSlot3 = CombatWalkBlendTreeChildren.GetArrayElementAtIndex(2);
            var CombatWalkRightAnimation = CombatWalkMotionSlot3.FindPropertyRelative("m_Motion");
            var CombatWalkRightAnimationSpeed = CombatWalkMotionSlot3.FindPropertyRelative("m_TimeScale");
            var CombatWalkRightMirror = CombatWalkMotionSlot3.FindPropertyRelative("m_Mirror");
            CombatWalkRightAnimationSpeed.floatValue = EmeraldComponent.RangedCombatWalkAnimationSpeed;
            CombatWalkRightAnimation.objectReferenceValue = EmeraldComponent.RangedCombatWalkRightAnimation;
            CombatWalkRightMirror.boolValue = EmeraldComponent.MirrorRangedCombatWalkRight;

            SerializedCombatWalkBlendTree.ApplyModifiedProperties();

            //Assign our Run animations and settings to the Run Blend Tree; one for run left, run straight, and run right.
            var CombatMovementMotionSlot3 = CombatMovementBlendTreeChildren.GetArrayElementAtIndex(2);
            var CombatMovementMotion3 = CombatMovementMotionSlot3.FindPropertyRelative("m_Motion");
            UnityEditor.Animations.BlendTree CombatRunBlendTree = CombatMovementMotion3.objectReferenceValue as UnityEditor.Animations.BlendTree;
            var SerializedCombatRunBlendTree = new SerializedObject(CombatRunBlendTree);
            var CombatRunBlendTreeChildren = SerializedCombatRunBlendTree.FindProperty("m_Childs");

            //Run Left
            var CombatRunMotionSlot1 = CombatRunBlendTreeChildren.GetArrayElementAtIndex(0);
            var CombatRunLeftAnimation = CombatRunMotionSlot1.FindPropertyRelative("m_Motion");
            var CombatRunLeftAnimationSpeed = CombatRunMotionSlot1.FindPropertyRelative("m_TimeScale");
            var CombatRunLeftMirror = CombatRunMotionSlot1.FindPropertyRelative("m_Mirror");
            CombatRunLeftAnimationSpeed.floatValue = EmeraldComponent.RangedCombatRunAnimationSpeed;
            CombatRunLeftAnimation.objectReferenceValue = EmeraldComponent.RangedCombatRunLeftAnimation;
            CombatRunLeftMirror.boolValue = EmeraldComponent.MirrorRangedCombatRunLeft;

            //Run Straight
            var CombatRunMotionSlot2 = CombatRunBlendTreeChildren.GetArrayElementAtIndex(1);
            var CombatRunStraightAnimation = CombatRunMotionSlot2.FindPropertyRelative("m_Motion");
            var CombatRunStraightAnimationSpeed = CombatRunMotionSlot2.FindPropertyRelative("m_TimeScale");
            CombatRunStraightAnimationSpeed.floatValue = EmeraldComponent.RangedCombatRunAnimationSpeed;
            CombatRunStraightAnimation.objectReferenceValue = EmeraldComponent.RangedCombatRunStraightAnimation;

            //Run Right
            var CombatRunMotionSlot3 = CombatRunBlendTreeChildren.GetArrayElementAtIndex(2);
            var CombatRunRightAnimation = CombatRunMotionSlot3.FindPropertyRelative("m_Motion");
            var CombatRunRightAnimationSpeed = CombatRunMotionSlot3.FindPropertyRelative("m_TimeScale");
            var CombatRunRightMirror = CombatRunMotionSlot3.FindPropertyRelative("m_Mirror");
            CombatRunRightAnimationSpeed.floatValue = EmeraldComponent.RangedCombatRunAnimationSpeed;
            CombatRunRightAnimation.objectReferenceValue = EmeraldComponent.RangedCombatRunRightAnimation;
            CombatRunRightMirror.boolValue = EmeraldComponent.MirrorRangedCombatRunRight;

            SerializedCombatRunBlendTree.ApplyModifiedProperties();
        }
    }
}