using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EmeraldAI.Utility
{
    public static class AnimationProfileExporter
    {
        static public void ExportAnimationProfile(string SaveLocationPath, EmeraldAISystem EmeraldAIComponent)
        {
            AnimationProfile m_AnimationProfile = ScriptableObject.CreateInstance("AnimationProfile") as AnimationProfile;

            m_AnimationProfile.AIAnimator = EmeraldAIComponent.AIAnimator.runtimeAnimatorController;

            //Attack Animations
            m_AnimationProfile.Attack1Animation = EmeraldAIComponent.Attack1Animation;
            m_AnimationProfile.Attack2Animation = EmeraldAIComponent.Attack2Animation;
            m_AnimationProfile.Attack3Animation = EmeraldAIComponent.Attack3Animation;
            m_AnimationProfile.RunAttack1Animation = EmeraldAIComponent.RunAttack1Animation;
            m_AnimationProfile.RunAttack2Animation = EmeraldAIComponent.RunAttack2Animation;
            m_AnimationProfile.RunAttack3Animation = EmeraldAIComponent.RunAttack3Animation;

            //Idle Animations
            m_AnimationProfile.Idle1Animation = EmeraldAIComponent.Idle1Animation;
            m_AnimationProfile.Idle2Animation = EmeraldAIComponent.Idle2Animation;
            m_AnimationProfile.Idle3Animation = EmeraldAIComponent.Idle3Animation;
            m_AnimationProfile.IdleWarningAnimation = EmeraldAIComponent.IdleWarningAnimation;
            m_AnimationProfile.NonCombatIdleAnimation = EmeraldAIComponent.NonCombatIdleAnimation;

            //Combat Idle Animations
            m_AnimationProfile.CombatIdleAnimation = EmeraldAIComponent.CombatIdleAnimation;

            //Non Combat Turn Animations
            m_AnimationProfile.NonCombatTurnLeftAnimation = EmeraldAIComponent.NonCombatTurnLeftAnimation;
            m_AnimationProfile.NonCombatTurnRightAnimation = EmeraldAIComponent.NonCombatTurnRightAnimation;

            //Combat Turn Animations
            m_AnimationProfile.CombatTurnLeftAnimation = EmeraldAIComponent.CombatTurnLeftAnimation;
            m_AnimationProfile.CombatTurnRightAnimation = EmeraldAIComponent.CombatTurnRightAnimation;

            //Non Combat Movement Animations
            m_AnimationProfile.WalkLeftAnimation = EmeraldAIComponent.WalkLeftAnimation;
            m_AnimationProfile.WalkStraightAnimation = EmeraldAIComponent.WalkStraightAnimation;
            m_AnimationProfile.WalkRightAnimation = EmeraldAIComponent.WalkRightAnimation;
            m_AnimationProfile.RunLeftAnimation = EmeraldAIComponent.RunLeftAnimation;
            m_AnimationProfile.RunStraightAnimation = EmeraldAIComponent.RunStraightAnimation;
            m_AnimationProfile.RunRightAnimation = EmeraldAIComponent.RunRightAnimation;

            //Combat Movement Animations           
            m_AnimationProfile.CombatWalkLeftAnimation = EmeraldAIComponent.CombatWalkLeftAnimation;
            m_AnimationProfile.CombatWalkStraightAnimation = EmeraldAIComponent.CombatWalkStraightAnimation;
            m_AnimationProfile.CombatWalkBackAnimation = EmeraldAIComponent.CombatWalkBackAnimation;
            m_AnimationProfile.CombatWalkRightAnimation = EmeraldAIComponent.CombatWalkRightAnimation;
            m_AnimationProfile.CombatRunLeftAnimation = EmeraldAIComponent.CombatRunLeftAnimation;
            m_AnimationProfile.CombatRunStraightAnimation = EmeraldAIComponent.CombatRunStraightAnimation;
            m_AnimationProfile.CombatRunRightAnimation = EmeraldAIComponent.CombatRunRightAnimation;

            //Emote Animations
            m_AnimationProfile.Emote1Animation = EmeraldAIComponent.Emote1Animation;
            m_AnimationProfile.Emote2Animation = EmeraldAIComponent.Emote2Animation;
            m_AnimationProfile.Emote3Animation = EmeraldAIComponent.Emote3Animation;

            //Hit Animations
            m_AnimationProfile.Hit1Animation = EmeraldAIComponent.Hit1Animation;
            m_AnimationProfile.Hit2Animation = EmeraldAIComponent.Hit2Animation;
            m_AnimationProfile.Hit3Animation = EmeraldAIComponent.Hit3Animation;
            m_AnimationProfile.CombatHit1Animation = EmeraldAIComponent.CombatHit1Animation;
            m_AnimationProfile.CombatHit2Animation = EmeraldAIComponent.CombatHit2Animation;
            m_AnimationProfile.CombatHit3Animation = EmeraldAIComponent.CombatHit3Animation;

            //Block Animations
            m_AnimationProfile.BlockIdleAnimation = EmeraldAIComponent.BlockIdleAnimation;
            m_AnimationProfile.BlockHitAnimation = EmeraldAIComponent.BlockHitAnimation;

            //Take Out and Put Away Weapon Animations
            m_AnimationProfile.PutAwayWeaponAnimation = EmeraldAIComponent.PutAwayWeaponAnimation;
            m_AnimationProfile.PullOutWeaponAnimation = EmeraldAIComponent.PullOutWeaponAnimation;

            //Death Animations
            m_AnimationProfile.Death1Animation = EmeraldAIComponent.Death1Animation;
            m_AnimationProfile.Death2Animation = EmeraldAIComponent.Death2Animation;
            m_AnimationProfile.Death3Animation = EmeraldAIComponent.Death3Animation;

            //Added ranged
            m_AnimationProfile.RangedDeath1Animation = EmeraldAIComponent.RangedDeath1Animation;
            m_AnimationProfile.RangedDeath2Animation = EmeraldAIComponent.RangedDeath2Animation;
            m_AnimationProfile.RangedDeath3Animation = EmeraldAIComponent.RangedDeath3Animation;

            //Rabged - Other Animations
            m_AnimationProfile.RangedCombatIdleAnimation = EmeraldAIComponent.RangedCombatIdleAnimation;
            m_AnimationProfile.RangedCombatWalkLeftAnimation = EmeraldAIComponent.RangedCombatWalkLeftAnimation;
            m_AnimationProfile.RangedCombatWalkStraightAnimation = EmeraldAIComponent.RangedCombatWalkStraightAnimation;
            m_AnimationProfile.RangedCombatWalkBackAnimation = EmeraldAIComponent.RangedCombatWalkBackAnimation;
            m_AnimationProfile.RangedCombatWalkRightAnimation = EmeraldAIComponent.RangedCombatWalkRightAnimation;
            m_AnimationProfile.RangedCombatRunLeftAnimation = EmeraldAIComponent.RangedCombatRunLeftAnimation;
            m_AnimationProfile.RangedCombatRunStraightAnimation = EmeraldAIComponent.RangedCombatRunStraightAnimation;
            m_AnimationProfile.RangedCombatRunRightAnimation = EmeraldAIComponent.RangedCombatRunRightAnimation;
            m_AnimationProfile.RangedIdleWarningAnimation = EmeraldAIComponent.RangedIdleWarningAnimation;
            m_AnimationProfile.RangedPutAwayWeaponAnimation = EmeraldAIComponent.RangedPutAwayWeaponAnimation;
            m_AnimationProfile.RangedPullOutWeaponAnimation = EmeraldAIComponent.RangedPullOutWeaponAnimation;
            m_AnimationProfile.RangedAttack1Animation = EmeraldAIComponent.RangedAttack1Animation;
            m_AnimationProfile.RangedAttack2Animation = EmeraldAIComponent.RangedAttack2Animation;
            m_AnimationProfile.RangedAttack3Animation = EmeraldAIComponent.RangedAttack3Animation;
            m_AnimationProfile.RangedRunAttack1Animation = EmeraldAIComponent.RangedRunAttack1Animation;
            m_AnimationProfile.RangedRunAttack2Animation = EmeraldAIComponent.RangedRunAttack2Animation;
            m_AnimationProfile.RangedRunAttack3Animation = EmeraldAIComponent.RangedRunAttack3Animation;
            m_AnimationProfile.RangedCombatHit1Animation = EmeraldAIComponent.RangedCombatHit1Animation;
            m_AnimationProfile.RangedCombatHit2Animation = EmeraldAIComponent.RangedCombatHit2Animation;
            m_AnimationProfile.RangedCombatHit3Animation = EmeraldAIComponent.RangedCombatHit3Animation;
            m_AnimationProfile.RangedCombatTurnLeftAnimation = EmeraldAIComponent.RangedCombatTurnLeftAnimation;
            m_AnimationProfile.RangedCombatTurnRightAnimation = EmeraldAIComponent.RangedCombatTurnRightAnimation;

            //All Animation Speeds
            m_AnimationProfile.Idle1AnimationSpeed = EmeraldAIComponent.Idle1AnimationSpeed;
            m_AnimationProfile.Idle2AnimationSpeed = EmeraldAIComponent.Idle2AnimationSpeed;
            m_AnimationProfile.Idle3AnimationSpeed = EmeraldAIComponent.Idle3AnimationSpeed;
            m_AnimationProfile.IdleWarningAnimationSpeed = EmeraldAIComponent.IdleWarningAnimationSpeed;
            m_AnimationProfile.RangedIdleWarningAnimationSpeed = EmeraldAIComponent.RangedIdleWarningAnimationSpeed;
            m_AnimationProfile.IdleCombatAnimationSpeed = EmeraldAIComponent.IdleCombatAnimationSpeed;
            m_AnimationProfile.RangedIdleCombatAnimationSpeed = EmeraldAIComponent.RangedIdleCombatAnimationSpeed;
            m_AnimationProfile.IdleNonCombatAnimationSpeed = EmeraldAIComponent.IdleNonCombatAnimationSpeed;
            m_AnimationProfile.Attack1AnimationSpeed = EmeraldAIComponent.Attack1AnimationSpeed;
            m_AnimationProfile.Attack2AnimationSpeed = EmeraldAIComponent.Attack2AnimationSpeed;
            m_AnimationProfile.Attack3AnimationSpeed = EmeraldAIComponent.Attack3AnimationSpeed;
            m_AnimationProfile.RangedAttack1AnimationSpeed = EmeraldAIComponent.RangedAttack1AnimationSpeed;
            m_AnimationProfile.RangedAttack2AnimationSpeed = EmeraldAIComponent.RangedAttack2AnimationSpeed;
            m_AnimationProfile.RangedAttack3AnimationSpeed = EmeraldAIComponent.RangedAttack3AnimationSpeed;
            m_AnimationProfile.RunAttack1AnimationSpeed = EmeraldAIComponent.RunAttack1AnimationSpeed;
            m_AnimationProfile.RunAttack2AnimationSpeed = EmeraldAIComponent.RunAttack2AnimationSpeed;
            m_AnimationProfile.RunAttack3AnimationSpeed = EmeraldAIComponent.RunAttack3AnimationSpeed;
            m_AnimationProfile.RangedRunAttack1AnimationSpeed = EmeraldAIComponent.RangedRunAttack1AnimationSpeed;
            m_AnimationProfile.RangedRunAttack2AnimationSpeed = EmeraldAIComponent.RangedRunAttack2AnimationSpeed;
            m_AnimationProfile.RangedRunAttack3AnimationSpeed = EmeraldAIComponent.RangedRunAttack3AnimationSpeed;
            m_AnimationProfile.TurnLeftAnimationSpeed = EmeraldAIComponent.TurnLeftAnimationSpeed;
            m_AnimationProfile.TurnRightAnimationSpeed = EmeraldAIComponent.TurnRightAnimationSpeed;
            m_AnimationProfile.CombatTurnLeftAnimationSpeed = EmeraldAIComponent.CombatTurnLeftAnimationSpeed;
            m_AnimationProfile.CombatTurnRightAnimationSpeed = EmeraldAIComponent.CombatTurnRightAnimationSpeed;
            m_AnimationProfile.RangedCombatTurnLeftAnimationSpeed = EmeraldAIComponent.RangedCombatTurnLeftAnimationSpeed;
            m_AnimationProfile.RangedCombatTurnRightAnimationSpeed = EmeraldAIComponent.RangedCombatTurnRightAnimationSpeed;
            m_AnimationProfile.Death1AnimationSpeed = EmeraldAIComponent.Death1AnimationSpeed;
            m_AnimationProfile.Death2AnimationSpeed = EmeraldAIComponent.Death2AnimationSpeed;
            m_AnimationProfile.Death3AnimationSpeed = EmeraldAIComponent.Death3AnimationSpeed;
            m_AnimationProfile.RangedDeath1AnimationSpeed = EmeraldAIComponent.RangedDeath1AnimationSpeed;
            m_AnimationProfile.RangedDeath2AnimationSpeed = EmeraldAIComponent.RangedDeath2AnimationSpeed;
            m_AnimationProfile.RangedDeath3AnimationSpeed = EmeraldAIComponent.RangedDeath3AnimationSpeed;
            m_AnimationProfile.Emote1AnimationSpeed = EmeraldAIComponent.Emote1AnimationSpeed;
            m_AnimationProfile.Emote2AnimationSpeed = EmeraldAIComponent.Emote2AnimationSpeed;
            m_AnimationProfile.Emote3AnimationSpeed = EmeraldAIComponent.Emote3AnimationSpeed;
            m_AnimationProfile.WalkAnimationSpeed = EmeraldAIComponent.WalkAnimationSpeed;
            m_AnimationProfile.RunAnimationSpeed = EmeraldAIComponent.RunAnimationSpeed;
            m_AnimationProfile.NonCombatWalkAnimationSpeed = EmeraldAIComponent.NonCombatWalkAnimationSpeed;
            m_AnimationProfile.NonCombatRunAnimationSpeed = EmeraldAIComponent.NonCombatRunAnimationSpeed;
            m_AnimationProfile.CombatWalkAnimationSpeed = EmeraldAIComponent.CombatWalkAnimationSpeed;
            m_AnimationProfile.CombatRunAnimationSpeed = EmeraldAIComponent.CombatRunAnimationSpeed;
            m_AnimationProfile.RangedCombatWalkAnimationSpeed = EmeraldAIComponent.RangedCombatWalkAnimationSpeed;
            m_AnimationProfile.RangedCombatRunAnimationSpeed = EmeraldAIComponent.RangedCombatRunAnimationSpeed;
            m_AnimationProfile.Hit1AnimationSpeed = EmeraldAIComponent.Hit1AnimationSpeed;
            m_AnimationProfile.Hit2AnimationSpeed = EmeraldAIComponent.Hit2AnimationSpeed;
            m_AnimationProfile.Hit3AnimationSpeed = EmeraldAIComponent.Hit3AnimationSpeed;
            m_AnimationProfile.CombatHit1AnimationSpeed = EmeraldAIComponent.CombatHit1AnimationSpeed;
            m_AnimationProfile.CombatHit2AnimationSpeed = EmeraldAIComponent.CombatHit2AnimationSpeed;
            m_AnimationProfile.CombatHit3AnimationSpeed = EmeraldAIComponent.CombatHit3AnimationSpeed;
            m_AnimationProfile.RangedCombatHit1AnimationSpeed = EmeraldAIComponent.RangedCombatHit1AnimationSpeed;
            m_AnimationProfile.RangedCombatHit2AnimationSpeed = EmeraldAIComponent.RangedCombatHit2AnimationSpeed;
            m_AnimationProfile.RangedCombatHit3AnimationSpeed = EmeraldAIComponent.RangedCombatHit3AnimationSpeed;

            //Mirror Animation Settings
            m_AnimationProfile.MirrorWalkLeft = EmeraldAIComponent.MirrorWalkLeft;
            m_AnimationProfile.MirrorWalkRight = EmeraldAIComponent.MirrorWalkRight;
            m_AnimationProfile.MirrorRunLeft = EmeraldAIComponent.MirrorRunLeft;
            m_AnimationProfile.MirrorRunRight = EmeraldAIComponent.MirrorRunRight;
            m_AnimationProfile.MirrorCombatWalkLeft = EmeraldAIComponent.MirrorCombatWalkLeft;
            m_AnimationProfile.MirrorCombatWalkRight = EmeraldAIComponent.MirrorCombatWalkRight;
            m_AnimationProfile.MirrorCombatRunLeft = EmeraldAIComponent.MirrorCombatRunLeft;
            m_AnimationProfile.MirrorCombatRunRight = EmeraldAIComponent.MirrorCombatRunRight;
            m_AnimationProfile.MirrorCombatTurnLeft = EmeraldAIComponent.MirrorCombatTurnLeft;
            m_AnimationProfile.MirrorCombatTurnRight = EmeraldAIComponent.MirrorCombatTurnRight;
            m_AnimationProfile.MirrorRangedCombatWalkLeft = EmeraldAIComponent.MirrorRangedCombatWalkLeft;
            m_AnimationProfile.MirrorRangedCombatWalkRight = EmeraldAIComponent.MirrorRangedCombatWalkRight;
            m_AnimationProfile.MirrorRangedCombatRunLeft = EmeraldAIComponent.MirrorRangedCombatRunLeft;
            m_AnimationProfile.MirrorRangedCombatRunRight = EmeraldAIComponent.MirrorRangedCombatRunRight;
            m_AnimationProfile.MirrorRangedCombatTurnLeft = EmeraldAIComponent.MirrorRangedCombatTurnLeft;
            m_AnimationProfile.MirrorRangedCombatTurnRight = EmeraldAIComponent.MirrorRangedCombatTurnRight;
            m_AnimationProfile.MirrorTurnLeft = EmeraldAIComponent.MirrorTurnLeft;
            m_AnimationProfile.MirrorTurnRight = EmeraldAIComponent.MirrorTurnRight;
            m_AnimationProfile.ReverseWalkAnimation = EmeraldAIComponent.ReverseWalkAnimation;
            m_AnimationProfile.ReverseRangedWalkAnimation = EmeraldAIComponent.ReverseRangedWalkAnimation;

            //Animation Specific Settings
            m_AnimationProfile.UseWarningAnimationRef = (AnimationProfile.YesOrNo)EmeraldAIComponent.UseWarningAnimationRef;
            m_AnimationProfile.UseRunAttacksRef = (AnimationProfile.YesOrNo)EmeraldAIComponent.UseRunAttacksRef;
            m_AnimationProfile.UseHitAnimations = (AnimationProfile.YesOrNo)EmeraldAIComponent.UseHitAnimations;
            m_AnimationProfile.UseEquipAnimation = (AnimationProfile.YesOrNo)EmeraldAIComponent.UseEquipAnimation;
            m_AnimationProfile.UseBlockingRef = (AnimationProfile.YesOrNo)EmeraldAIComponent.UseBlockingRef;
            m_AnimationProfile.WeaponTypeRef = (AnimationProfile.WeaponType)EmeraldAIComponent.WeaponTypeRef;
            m_AnimationProfile.AnimatorType = (AnimationProfile.AnimatorTypeState)EmeraldAIComponent.AnimatorType;

            //Animation Lists
            //Store our animation lists to a scriptable object to be imported when needed. These are essentially making copies of the AI's current animation lists.
            for (int i = 0; i < EmeraldAIComponent.IdleAnimationList.Count; i++)
            {
                m_AnimationProfile.IdleAnimationList.Add(new AnimationProfile.AnimationClass(EmeraldAIComponent.IdleAnimationList[i].AnimationSpeed, 
                    EmeraldAIComponent.IdleAnimationList[i].AnimationClip));
            }

            for (int i = 0; i < EmeraldAIComponent.AttackAnimationList.Count; i++)
            {
                m_AnimationProfile.AttackAnimationList.Add(new AnimationProfile.AnimationClass(EmeraldAIComponent.AttackAnimationList[i].AnimationSpeed, 
                    EmeraldAIComponent.AttackAnimationList[i].AnimationClip));
            }

            for (int i = 0; i < EmeraldAIComponent.RunAttackAnimationList.Count; i++)
            {
                m_AnimationProfile.RunAttackAnimationList.Add(new AnimationProfile.AnimationClass(EmeraldAIComponent.RunAttackAnimationList[i].AnimationSpeed,
                    EmeraldAIComponent.RunAttackAnimationList[i].AnimationClip));
            }

            for (int i = 0; i < EmeraldAIComponent.DeathAnimationList.Count; i++)
            {
                m_AnimationProfile.DeathAnimationList.Add(new AnimationProfile.AnimationClass(EmeraldAIComponent.DeathAnimationList[i].AnimationSpeed,
                    EmeraldAIComponent.DeathAnimationList[i].AnimationClip));
            }

            for (int i = 0; i < EmeraldAIComponent.RangedDeathAnimationList.Count; i++)
            {
                m_AnimationProfile.RangedDeathAnimationList.Add(new AnimationProfile.AnimationClass(EmeraldAIComponent.RangedDeathAnimationList[i].AnimationSpeed,
                    EmeraldAIComponent.RangedDeathAnimationList[i].AnimationClip));
            }

            for (int i = 0; i < EmeraldAIComponent.CombatHitAnimationList.Count; i++)
            {
                m_AnimationProfile.CombatHitAnimationList.Add(new AnimationProfile.AnimationClass(EmeraldAIComponent.CombatHitAnimationList[i].AnimationSpeed,
                    EmeraldAIComponent.CombatHitAnimationList[i].AnimationClip));
            }

            for (int i = 0; i < EmeraldAIComponent.HitAnimationList.Count; i++)
            {
                m_AnimationProfile.HitAnimationList.Add(new AnimationProfile.AnimationClass(EmeraldAIComponent.HitAnimationList[i].AnimationSpeed,
                    EmeraldAIComponent.HitAnimationList[i].AnimationClip));
            }

            for (int i = 0; i < EmeraldAIComponent.RangedAttackAnimationList.Count; i++)
            {
                m_AnimationProfile.RangedAttackAnimationList.Add(new AnimationProfile.AnimationClass(EmeraldAIComponent.RangedAttackAnimationList[i].AnimationSpeed,
                    EmeraldAIComponent.RangedAttackAnimationList[i].AnimationClip));
            }

            for (int i = 0; i < EmeraldAIComponent.RangedCombatHitAnimationList.Count; i++)
            {
                m_AnimationProfile.RangedCombatHitAnimationList.Add(new AnimationProfile.AnimationClass(EmeraldAIComponent.RangedCombatHitAnimationList[i].AnimationSpeed,
                    EmeraldAIComponent.RangedCombatHitAnimationList[i].AnimationClip));
            }

            for (int i = 0; i < EmeraldAIComponent.RangedRunAttackAnimationList.Count; i++)
            {
                m_AnimationProfile.RangedRunAttackAnimationList.Add(new AnimationProfile.AnimationClass(EmeraldAIComponent.RangedRunAttackAnimationList[i].AnimationSpeed,
                    EmeraldAIComponent.RangedRunAttackAnimationList[i].AnimationClip));
            }

            AssetDatabase.CreateAsset(m_AnimationProfile, SaveLocationPath);
        }

        static public void ImportAnimationProfile(EmeraldAISystem EmeraldAIComponent, AnimationProfile AnimationProfileFile, SerializedObject serializedObject, bool ImportAnimatorController)
        {
            if (ImportAnimatorController)
            {
                EmeraldAIComponent.AIAnimator = EmeraldAIComponent.GetComponent<Animator>();
                EmeraldAIComponent.GetComponent<Animator>().runtimeAnimatorController = AnimationProfileFile.AIAnimator;
            }

            //Animation Specific Settings
            EmeraldAIComponent.AnimatorType = (EmeraldAISystem.AnimatorTypeState)AnimationProfileFile.AnimatorType;

            //Attack Animations
            EmeraldAIComponent.Attack1Animation = AnimationProfileFile.Attack1Animation;
            EmeraldAIComponent.Attack2Animation = AnimationProfileFile.Attack2Animation;
            EmeraldAIComponent.Attack3Animation = AnimationProfileFile.Attack3Animation;
            EmeraldAIComponent.RunAttack1Animation = AnimationProfileFile.RunAttack1Animation;
            EmeraldAIComponent.RunAttack2Animation = AnimationProfileFile.RunAttack2Animation;
            EmeraldAIComponent.RunAttack3Animation = AnimationProfileFile.RunAttack3Animation;

            //Idle Animations
            EmeraldAIComponent.Idle1Animation = AnimationProfileFile.Idle1Animation;
            EmeraldAIComponent.Idle2Animation = AnimationProfileFile.Idle2Animation;
            EmeraldAIComponent.Idle3Animation = AnimationProfileFile.Idle3Animation;
            EmeraldAIComponent.IdleWarningAnimation = AnimationProfileFile.IdleWarningAnimation;
            EmeraldAIComponent.NonCombatIdleAnimation = AnimationProfileFile.NonCombatIdleAnimation;

            //Combat Idle Animations
            EmeraldAIComponent.CombatIdleAnimation = AnimationProfileFile.CombatIdleAnimation;

            //Non Combat Turn Animations
            EmeraldAIComponent.NonCombatTurnLeftAnimation = AnimationProfileFile.NonCombatTurnLeftAnimation;
            EmeraldAIComponent.NonCombatTurnRightAnimation = AnimationProfileFile.NonCombatTurnRightAnimation;

            //Combat Turn Animations
            EmeraldAIComponent.CombatTurnLeftAnimation = AnimationProfileFile.CombatTurnLeftAnimation;
            EmeraldAIComponent.CombatTurnRightAnimation = AnimationProfileFile.CombatTurnRightAnimation;

            //Non Combat Movement Animations
            EmeraldAIComponent.WalkLeftAnimation = AnimationProfileFile.WalkLeftAnimation;
            EmeraldAIComponent.WalkStraightAnimation = AnimationProfileFile.WalkStraightAnimation;
            EmeraldAIComponent.WalkRightAnimation = AnimationProfileFile.WalkRightAnimation;
            EmeraldAIComponent.RunLeftAnimation = AnimationProfileFile.RunLeftAnimation;
            EmeraldAIComponent.RunStraightAnimation = AnimationProfileFile.RunStraightAnimation;
            EmeraldAIComponent.RunRightAnimation = AnimationProfileFile.RunRightAnimation;

            //Combat Movement Animations           
            EmeraldAIComponent.CombatWalkLeftAnimation = AnimationProfileFile.CombatWalkLeftAnimation;
            EmeraldAIComponent.CombatWalkStraightAnimation = AnimationProfileFile.CombatWalkStraightAnimation;
            EmeraldAIComponent.CombatWalkBackAnimation = AnimationProfileFile.CombatWalkBackAnimation;
            EmeraldAIComponent.CombatWalkRightAnimation = AnimationProfileFile.CombatWalkRightAnimation;
            EmeraldAIComponent.CombatRunLeftAnimation = AnimationProfileFile.CombatRunLeftAnimation;
            EmeraldAIComponent.CombatRunStraightAnimation = AnimationProfileFile.CombatRunStraightAnimation;
            EmeraldAIComponent.CombatRunRightAnimation = AnimationProfileFile.CombatRunRightAnimation;

            //Emote Animations
            EmeraldAIComponent.Emote1Animation = AnimationProfileFile.Emote1Animation;
            EmeraldAIComponent.Emote2Animation = AnimationProfileFile.Emote2Animation;
            EmeraldAIComponent.Emote3Animation = AnimationProfileFile.Emote3Animation;

            //Hit Animations
            EmeraldAIComponent.Hit1Animation = AnimationProfileFile.Hit1Animation;
            EmeraldAIComponent.Hit2Animation = AnimationProfileFile.Hit2Animation;
            EmeraldAIComponent.Hit3Animation = AnimationProfileFile.Hit3Animation;
            EmeraldAIComponent.CombatHit1Animation = AnimationProfileFile.CombatHit1Animation;
            EmeraldAIComponent.CombatHit2Animation = AnimationProfileFile.CombatHit2Animation;
            EmeraldAIComponent.CombatHit3Animation = AnimationProfileFile.CombatHit3Animation;

            //Block Animations
            EmeraldAIComponent.BlockIdleAnimation = AnimationProfileFile.BlockIdleAnimation;
            EmeraldAIComponent.BlockHitAnimation = AnimationProfileFile.BlockHitAnimation;

            //Take Out and Put Away Weapon Animations
            EmeraldAIComponent.PutAwayWeaponAnimation = AnimationProfileFile.PutAwayWeaponAnimation;
            EmeraldAIComponent.PullOutWeaponAnimation = AnimationProfileFile.PullOutWeaponAnimation;

            //Death Animations
            EmeraldAIComponent.Death1Animation = AnimationProfileFile.Death1Animation;
            EmeraldAIComponent.Death2Animation = AnimationProfileFile.Death2Animation;
            EmeraldAIComponent.Death3Animation = AnimationProfileFile.Death3Animation;

            //Ranged - Other Animations
            EmeraldAIComponent.RangedCombatIdleAnimation = AnimationProfileFile.RangedCombatIdleAnimation;
            EmeraldAIComponent.RangedCombatWalkLeftAnimation = AnimationProfileFile.RangedCombatWalkLeftAnimation;
            EmeraldAIComponent.RangedCombatWalkStraightAnimation = AnimationProfileFile.RangedCombatWalkStraightAnimation;
            EmeraldAIComponent.RangedCombatWalkBackAnimation = AnimationProfileFile.RangedCombatWalkBackAnimation;
            EmeraldAIComponent.RangedCombatWalkRightAnimation = AnimationProfileFile.RangedCombatWalkRightAnimation;
            EmeraldAIComponent.RangedCombatRunLeftAnimation = AnimationProfileFile.RangedCombatRunLeftAnimation;
            EmeraldAIComponent.RangedCombatRunStraightAnimation = AnimationProfileFile.RangedCombatRunStraightAnimation;
            EmeraldAIComponent.RangedCombatRunRightAnimation = AnimationProfileFile.RangedCombatRunRightAnimation;
            EmeraldAIComponent.RangedIdleWarningAnimation = AnimationProfileFile.RangedIdleWarningAnimation;
            EmeraldAIComponent.RangedPutAwayWeaponAnimation = AnimationProfileFile.RangedPutAwayWeaponAnimation;
            EmeraldAIComponent.RangedPullOutWeaponAnimation = AnimationProfileFile.RangedPullOutWeaponAnimation;
            EmeraldAIComponent.RangedAttack1Animation = AnimationProfileFile.RangedAttack1Animation;
            EmeraldAIComponent.RangedAttack2Animation = AnimationProfileFile.RangedAttack2Animation;
            EmeraldAIComponent.RangedAttack3Animation = AnimationProfileFile.RangedAttack3Animation;
            EmeraldAIComponent.RangedRunAttack1Animation = AnimationProfileFile.RangedRunAttack1Animation;
            EmeraldAIComponent.RangedRunAttack2Animation = AnimationProfileFile.RangedRunAttack2Animation;
            EmeraldAIComponent.RangedRunAttack3Animation = AnimationProfileFile.RangedRunAttack3Animation;
            EmeraldAIComponent.RangedCombatHit1Animation = AnimationProfileFile.RangedCombatHit1Animation;
            EmeraldAIComponent.RangedCombatHit2Animation = AnimationProfileFile.RangedCombatHit2Animation;
            EmeraldAIComponent.RangedCombatHit3Animation = AnimationProfileFile.RangedCombatHit3Animation;
            EmeraldAIComponent.RangedCombatTurnLeftAnimation = AnimationProfileFile.RangedCombatTurnLeftAnimation;
            EmeraldAIComponent.RangedCombatTurnRightAnimation = AnimationProfileFile.RangedCombatTurnRightAnimation;

            //All Animation Speeds
            EmeraldAIComponent.Idle1AnimationSpeed = AnimationProfileFile.Idle1AnimationSpeed;
            EmeraldAIComponent.Idle2AnimationSpeed = AnimationProfileFile.Idle2AnimationSpeed;
            EmeraldAIComponent.Idle3AnimationSpeed = AnimationProfileFile.Idle3AnimationSpeed;
            EmeraldAIComponent.IdleWarningAnimationSpeed = AnimationProfileFile.IdleWarningAnimationSpeed;
            EmeraldAIComponent.RangedIdleWarningAnimationSpeed = AnimationProfileFile.RangedIdleWarningAnimationSpeed;
            EmeraldAIComponent.IdleCombatAnimationSpeed = AnimationProfileFile.IdleCombatAnimationSpeed;
            EmeraldAIComponent.RangedIdleCombatAnimationSpeed = AnimationProfileFile.RangedIdleCombatAnimationSpeed;
            EmeraldAIComponent.IdleNonCombatAnimationSpeed = AnimationProfileFile.IdleNonCombatAnimationSpeed;
            EmeraldAIComponent.Attack1AnimationSpeed = AnimationProfileFile.Attack1AnimationSpeed;
            EmeraldAIComponent.Attack2AnimationSpeed = AnimationProfileFile.Attack2AnimationSpeed;
            EmeraldAIComponent.Attack3AnimationSpeed = AnimationProfileFile.Attack3AnimationSpeed;
            EmeraldAIComponent.RangedAttack1AnimationSpeed = AnimationProfileFile.RangedAttack1AnimationSpeed;
            EmeraldAIComponent.RangedAttack2AnimationSpeed = AnimationProfileFile.RangedAttack2AnimationSpeed;
            EmeraldAIComponent.RangedAttack3AnimationSpeed = AnimationProfileFile.RangedAttack3AnimationSpeed;
            EmeraldAIComponent.RunAttack1AnimationSpeed = AnimationProfileFile.RunAttack1AnimationSpeed;
            EmeraldAIComponent.RunAttack2AnimationSpeed = AnimationProfileFile.RunAttack2AnimationSpeed;
            EmeraldAIComponent.RunAttack3AnimationSpeed = AnimationProfileFile.RunAttack3AnimationSpeed;
            EmeraldAIComponent.RangedRunAttack1AnimationSpeed = AnimationProfileFile.RangedRunAttack1AnimationSpeed;
            EmeraldAIComponent.RangedRunAttack2AnimationSpeed = AnimationProfileFile.RangedRunAttack2AnimationSpeed;
            EmeraldAIComponent.RangedRunAttack3AnimationSpeed = AnimationProfileFile.RangedRunAttack3AnimationSpeed;
            EmeraldAIComponent.TurnLeftAnimationSpeed = AnimationProfileFile.TurnLeftAnimationSpeed;
            EmeraldAIComponent.TurnRightAnimationSpeed = AnimationProfileFile.TurnRightAnimationSpeed;
            EmeraldAIComponent.CombatTurnLeftAnimationSpeed = AnimationProfileFile.CombatTurnLeftAnimationSpeed;
            EmeraldAIComponent.CombatTurnRightAnimationSpeed = AnimationProfileFile.CombatTurnRightAnimationSpeed;
            EmeraldAIComponent.RangedCombatTurnLeftAnimationSpeed = AnimationProfileFile.RangedCombatTurnLeftAnimationSpeed;
            EmeraldAIComponent.RangedCombatTurnRightAnimationSpeed = AnimationProfileFile.RangedCombatTurnRightAnimationSpeed;
            EmeraldAIComponent.Death1AnimationSpeed = AnimationProfileFile.Death1AnimationSpeed;
            EmeraldAIComponent.Death2AnimationSpeed = AnimationProfileFile.Death2AnimationSpeed;
            EmeraldAIComponent.Death3AnimationSpeed = AnimationProfileFile.Death3AnimationSpeed;
            EmeraldAIComponent.Emote1AnimationSpeed = AnimationProfileFile.Emote1AnimationSpeed;
            EmeraldAIComponent.Emote2AnimationSpeed = AnimationProfileFile.Emote2AnimationSpeed;
            EmeraldAIComponent.Emote3AnimationSpeed = AnimationProfileFile.Emote3AnimationSpeed;
            EmeraldAIComponent.WalkAnimationSpeed = AnimationProfileFile.WalkAnimationSpeed;
            EmeraldAIComponent.RunAnimationSpeed = AnimationProfileFile.RunAnimationSpeed;
            EmeraldAIComponent.NonCombatWalkAnimationSpeed = AnimationProfileFile.NonCombatWalkAnimationSpeed;
            EmeraldAIComponent.NonCombatRunAnimationSpeed = AnimationProfileFile.NonCombatRunAnimationSpeed;
            EmeraldAIComponent.CombatWalkAnimationSpeed = AnimationProfileFile.CombatWalkAnimationSpeed;
            EmeraldAIComponent.CombatRunAnimationSpeed = AnimationProfileFile.CombatRunAnimationSpeed;
            EmeraldAIComponent.RangedCombatWalkAnimationSpeed = AnimationProfileFile.RangedCombatWalkAnimationSpeed;
            EmeraldAIComponent.RangedCombatRunAnimationSpeed = AnimationProfileFile.RangedCombatRunAnimationSpeed;
            EmeraldAIComponent.Hit1AnimationSpeed = AnimationProfileFile.Hit1AnimationSpeed;
            EmeraldAIComponent.Hit2AnimationSpeed = AnimationProfileFile.Hit2AnimationSpeed;
            EmeraldAIComponent.Hit3AnimationSpeed = AnimationProfileFile.Hit3AnimationSpeed;
            EmeraldAIComponent.CombatHit1AnimationSpeed = AnimationProfileFile.CombatHit1AnimationSpeed;
            EmeraldAIComponent.CombatHit2AnimationSpeed = AnimationProfileFile.CombatHit2AnimationSpeed;
            EmeraldAIComponent.CombatHit3AnimationSpeed = AnimationProfileFile.CombatHit3AnimationSpeed;
            EmeraldAIComponent.RangedCombatHit1AnimationSpeed = AnimationProfileFile.RangedCombatHit1AnimationSpeed;
            EmeraldAIComponent.RangedCombatHit2AnimationSpeed = AnimationProfileFile.RangedCombatHit2AnimationSpeed;
            EmeraldAIComponent.RangedCombatHit3AnimationSpeed = AnimationProfileFile.RangedCombatHit3AnimationSpeed;

            //Mirror Animation Settings
            EmeraldAIComponent.MirrorWalkLeft = AnimationProfileFile.MirrorWalkLeft;
            EmeraldAIComponent.MirrorWalkRight = AnimationProfileFile.MirrorWalkRight;
            EmeraldAIComponent.MirrorRunLeft = AnimationProfileFile.MirrorRunLeft;
            EmeraldAIComponent.MirrorRunRight = AnimationProfileFile.MirrorRunRight;
            EmeraldAIComponent.MirrorCombatWalkLeft = AnimationProfileFile.MirrorCombatWalkLeft;
            EmeraldAIComponent.MirrorCombatWalkRight = AnimationProfileFile.MirrorCombatWalkRight;
            EmeraldAIComponent.MirrorCombatRunLeft = AnimationProfileFile.MirrorCombatRunLeft;
            EmeraldAIComponent.MirrorCombatRunRight = AnimationProfileFile.MirrorCombatRunRight;
            EmeraldAIComponent.MirrorCombatTurnLeft = AnimationProfileFile.MirrorCombatTurnLeft;
            EmeraldAIComponent.MirrorCombatTurnRight = AnimationProfileFile.MirrorCombatTurnRight;
            EmeraldAIComponent.MirrorRangedCombatWalkLeft = AnimationProfileFile.MirrorRangedCombatWalkLeft;
            EmeraldAIComponent.MirrorRangedCombatWalkRight = AnimationProfileFile.MirrorRangedCombatWalkRight;
            EmeraldAIComponent.MirrorRangedCombatRunLeft = AnimationProfileFile.MirrorRangedCombatRunLeft;
            EmeraldAIComponent.MirrorRangedCombatRunRight = AnimationProfileFile.MirrorRangedCombatRunRight;
            EmeraldAIComponent.MirrorRangedCombatTurnLeft = AnimationProfileFile.MirrorRangedCombatTurnLeft;
            EmeraldAIComponent.MirrorRangedCombatTurnRight = AnimationProfileFile.MirrorRangedCombatTurnRight;
            EmeraldAIComponent.MirrorTurnLeft = AnimationProfileFile.MirrorTurnLeft;
            EmeraldAIComponent.MirrorTurnRight = AnimationProfileFile.MirrorTurnRight;
            EmeraldAIComponent.ReverseWalkAnimation = AnimationProfileFile.ReverseWalkAnimation;
            EmeraldAIComponent.ReverseRangedWalkAnimation = AnimationProfileFile.ReverseRangedWalkAnimation;

            //Animation Specific Settings
            EmeraldAIComponent.UseWarningAnimationRef = (EmeraldAISystem.YesOrNo)AnimationProfileFile.UseWarningAnimationRef;
            EmeraldAIComponent.UseRunAttacksRef = (EmeraldAISystem.UseRunAttacks)AnimationProfileFile.UseRunAttacksRef;
            EmeraldAIComponent.UseHitAnimations = (EmeraldAISystem.YesOrNo)AnimationProfileFile.UseHitAnimations;
            EmeraldAIComponent.UseEquipAnimation = (EmeraldAISystem.YesOrNo)AnimationProfileFile.UseEquipAnimation;
            EmeraldAIComponent.UseBlockingRef = (EmeraldAISystem.YesOrNo)AnimationProfileFile.UseBlockingRef;
            EmeraldAIComponent.WeaponTypeRef = (EmeraldAISystem.WeaponType)AnimationProfileFile.WeaponTypeRef;           

            //Animation Lists
            EmeraldAIComponent.IdleAnimationList.Clear();
            for (int i = 0; i < AnimationProfileFile.IdleAnimationList.Count; i++)
            {
                EmeraldAIComponent.IdleAnimationList.Add(new EmeraldAISystem.AnimationClass(AnimationProfileFile.IdleAnimationList[i].AnimationSpeed, AnimationProfileFile.IdleAnimationList[i].AnimationClip));
            }

            EmeraldAIComponent.AttackAnimationList.Clear();
            for (int i = 0; i < AnimationProfileFile.AttackAnimationList.Count; i++)
            {
                EmeraldAIComponent.AttackAnimationList.Add(new EmeraldAISystem.AnimationClass(AnimationProfileFile.AttackAnimationList[i].AnimationSpeed,
                    AnimationProfileFile.AttackAnimationList[i].AnimationClip));
            }

            EmeraldAIComponent.RunAttackAnimationList.Clear();
            for (int i = 0; i < AnimationProfileFile.RunAttackAnimationList.Count; i++)
            {
                EmeraldAIComponent.RunAttackAnimationList.Add(new EmeraldAISystem.AnimationClass(AnimationProfileFile.RunAttackAnimationList[i].AnimationSpeed,
                    AnimationProfileFile.RunAttackAnimationList[i].AnimationClip));
            }

            EmeraldAIComponent.DeathAnimationList.Clear();
            for (int i = 0; i < AnimationProfileFile.DeathAnimationList.Count; i++)
            {
                EmeraldAIComponent.DeathAnimationList.Add(new EmeraldAISystem.AnimationClass(AnimationProfileFile.DeathAnimationList[i].AnimationSpeed,
                    AnimationProfileFile.DeathAnimationList[i].AnimationClip));
            }

            EmeraldAIComponent.CombatHitAnimationList.Clear();
            for (int i = 0; i < AnimationProfileFile.CombatHitAnimationList.Count; i++)
            {
                EmeraldAIComponent.CombatHitAnimationList.Add(new EmeraldAISystem.AnimationClass(AnimationProfileFile.CombatHitAnimationList[i].AnimationSpeed,
                    AnimationProfileFile.CombatHitAnimationList[i].AnimationClip));
            }

            EmeraldAIComponent.HitAnimationList.Clear();
            for (int i = 0; i < AnimationProfileFile.HitAnimationList.Count; i++)
            {
                EmeraldAIComponent.HitAnimationList.Add(new EmeraldAISystem.AnimationClass(AnimationProfileFile.HitAnimationList[i].AnimationSpeed,
                    AnimationProfileFile.HitAnimationList[i].AnimationClip));
            }

            EmeraldAIComponent.RangedAttackAnimationList.Clear();
            for (int i = 0; i < AnimationProfileFile.RangedAttackAnimationList.Count; i++)
            {
                EmeraldAIComponent.RangedAttackAnimationList.Add(new EmeraldAISystem.AnimationClass(AnimationProfileFile.RangedAttackAnimationList[i].AnimationSpeed,
                    AnimationProfileFile.RangedAttackAnimationList[i].AnimationClip));
            }

            EmeraldAIComponent.RangedCombatHitAnimationList.Clear();
            for (int i = 0; i < AnimationProfileFile.RangedCombatHitAnimationList.Count; i++)
            {
                EmeraldAIComponent.RangedCombatHitAnimationList.Add(new EmeraldAISystem.AnimationClass(AnimationProfileFile.RangedCombatHitAnimationList[i].AnimationSpeed,
                    AnimationProfileFile.RangedCombatHitAnimationList[i].AnimationClip));
            }

            EmeraldAIComponent.RangedRunAttackAnimationList.Clear();
            for (int i = 0; i < AnimationProfileFile.RangedRunAttackAnimationList.Count; i++)
            {
                EmeraldAIComponent.RangedRunAttackAnimationList.Add(new EmeraldAISystem.AnimationClass(AnimationProfileFile.RangedRunAttackAnimationList[i].AnimationSpeed,
                    AnimationProfileFile.RangedRunAttackAnimationList[i].AnimationClip));
            }

            if (EmeraldAIComponent.AIAnimator != null)
            {
                EmeraldAIAnimatorGenerator.GenerateAnimatorController(EmeraldAIComponent);
                serializedObject.Update();
                EmeraldAIComponent.AnimatorControllerGenerated = true;
            }
        }
    }
}
 