using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    private int _timesPlayerDetected = 0;
    private float _timerChangeNeeds;
    
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
        
        Needs = new List<Need>();

        for (int i = 0; i < 5; i++)
        {
            Needs.Add(new Need(100f, $"need{i+1}"));
        }

        Status = ManagerStatus.Started;
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
        Needs[index].Value += value;
    }

    private void DecreaseNeedsValue(float value)
    {
        foreach (var need in Needs)
        {
            need.Value -= value;
            if (need.Value <= 0)
            {
                need.Value = 0;
                Messenger.Broadcast(GameEvent.LEVEL_FAILED);
            }
        }
    }

    /// <summary>
    /// Обновление данных по здоровью.
    /// </summary>
    /// <param name="health"></param>
    /// <param name="maxHealth"></param>
    public void UpdateData(int health, int maxHealth)
    {
    }
    
    /// <summary>
    /// Изменение количества жизней.
    /// </summary>
    /// <param name="value"></param>
    public void ChangeHealth(int value)
    {
        /*Health += value;
        
        if (Health > MaxHealth)
            Health = MaxHealth;
        else if (Health < 0)
            Health = 0;
        
        if (Health == 0)
            Messenger.Broadcast(GameEvent.LEVEL_FAILED);
        else 
            StartCoroutine(Respawn());
        
        Messenger.Broadcast(GameEvent.NEEDS_UPDATED);*/
    }

    public void PlayerDetected()
    {
        _timesPlayerDetected++;
        Debug.Log($"Player Detected! Total detections: {_timesPlayerDetected}");
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
