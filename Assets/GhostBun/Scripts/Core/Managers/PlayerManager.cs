using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    private int _timesPlayerDetected = 0;
    private float _timerChangeNeeds;
    [SerializeField] private int maximumDetections = 7;
    
    public ManagerStatus Status { get; private set; }
    public float Timer;
    public float NeedChanger;
    public List<Need> Needs;

    /// <summary>
    /// Инициализация менеджера.
    /// </summary>
    public void Startup()
    {
        Debug.Log($"Player manager starting...");

        SetNewNeeds();

        Status = ManagerStatus.Started;
    }

    public void SetNewNeeds()
    {
        Needs = new List<Need>();

        for (int i = 0; i < 5; i++)
        {
            Needs.Add(new Need(100f, $"need{i+1}"));
        }
    }

    private void FixedUpdate()
    {
        _timerChangeNeeds += Time.fixedDeltaTime;
        
        if (Managers.Mission.CurrentScene != "Menu" && _timerChangeNeeds > Timer)
        {
            DecreaseNeedsValue(NeedChanger);
            Messenger.Broadcast(GameEvent.NEEDS_UPDATED);
            _timerChangeNeeds = 0;
        }
    }

    public float AverageNeedsValue()
    {
        float average = 0;

        for (int i = 0; i < Needs.Count; i++)
        {
            average += Needs[i].Value;
        }

        average = average / Needs.Count;
        
        return average;
    }

    public void ChangeNeed(int index, float value)
    { 
        if (Needs[index].Value + value > 100f)
            Needs[index].Value = 100;
        else
            Needs[index].Value += value;
        
        Messenger.Broadcast(GameEvent.NEEDS_UPDATED);
    }

    private void DecreaseNeedsValue(float value)
    {
        foreach (var need in Needs)
        {
            if (need.Value <= 0) break;
            
            need.Value -= value;
            if (need.Value <= 0)
            {
                need.Value = 0;
                Messenger.Broadcast(GameEvent.LEVEL_FAILED);
                break;
            }
        }
    }

    public void PlayerDetected()
    {
        _timesPlayerDetected++;
        if (_timesPlayerDetected >= maximumDetections)
        {
            Messenger.Broadcast(GameEvent.LEVEL_FAILED);
        }

    }
}

 public class Need
 {
     public float Value;
     public string Name;

     public Need(float value, string name)
     {
         Value = value;
         Name = name;
     }
 }
