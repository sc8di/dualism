using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    /// <summary>
    /// Переменная для сохранения позиции игрока по последнему чекпоинту.
    /// </summary>
    public Vector3 LastSavePosition  { get; private set; }

    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int Score { get; private set; }

    /// <summary>
    /// Инициализация менеджера.
    /// </summary>
    public void Startup()
    {
        Debug.Log($"Player manager starting...");

        UpdateData(3, 3);

        Status = ManagerStatus.Started;
    }

    /// <summary>
    /// Обновление данных по здоровью.
    /// </summary>
    /// <param name="health"></param>
    /// <param name="maxHealth"></param>
    public void UpdateData(int health, int maxHealth)
    {
        Health = health;
        MaxHealth = maxHealth;
    }

    /// <summary>
    /// Изменение данных по?
    /// </summary>
    /// <param name="value"></param>
    public void ChangeScore(int value)
    {
        Score += value;

        if (Score < 0)
            Score = 0;

        Messenger.Broadcast(GameEvent.SCORE_UPDATED);

        if (Score == 0)
            Messenger.Broadcast(GameEvent.LEVEL_FAILED); 
    }

    /// <summary>
    /// Изменение количества жизней.
    /// </summary>
    /// <param name="value"></param>
    public void ChangeHealth(int value)
    {
        Health += value;
        
        if (Health > MaxHealth)
            Health = MaxHealth;
        else if (Health < 0)
            Health = 0;
        
        if (Health == 0)
            Messenger.Broadcast(GameEvent.LEVEL_FAILED);
        else 
            StartCoroutine(Respawn());
        
        Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
    }

    /// <summary>
    /// Апдейт последней позиции при активации чекпоинта.
    /// </summary>
    /// <param name="checkpoint"></param>
    public void UpdateLastAutosavePosition(Vector3 checkpoint)
    {
        LastSavePosition = checkpoint;
    }
    
    /// <summary>
    /// Респаун игрока с возвращением на чекпоинт.
    /// </summary>
    /// <returns></returns>
    private static IEnumerator Respawn()
    {
        Debug.Log("Player dead. A little.");
        
        yield return new WaitForSeconds(2);

        Messenger.Broadcast(GameEvent.RETURN_TO_CHECKPOINT);
    }

    /// <summary>
    /// Респаун в начало уровня.
    /// </summary>
    public void RespawnFull()
    {
        UpdateData(MaxHealth, MaxHealth);
    }
}
