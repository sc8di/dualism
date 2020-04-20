using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }
    
    /// <summary>
    /// Текущий уровень.
    /// </summary>
    public int CurrentLevel { get; private set; }
    /// <summary>
    /// Последний уровень.
    /// </summary>
    public int MaxLevel { get; private set; }

    /// <summary>
    /// Инициализация менеджера.
    /// </summary>
    public void Startup()
    {
        Debug.Log("Mission manager starting...");

        UpdateData(0, 2);

        Status = ManagerStatus.Started;
    }

    /// <summary>
    /// Обновление данных по уровням.
    /// </summary>
    /// <param name="curLevel">Текущий уровень.</param>
    /// <param name="maxLevel">Конечный уровень.</param>
    public void UpdateData(int curLevel, int maxLevel)
    {
        CurrentLevel = curLevel;
        MaxLevel = maxLevel;
    }
    
    /// <summary>
    /// Следующий уровень.
    /// </summary>
    public void GoToNext()
    {
        if (CurrentLevel < MaxLevel)
        {
            CurrentLevel++;
            string name = $"Level{CurrentLevel}";
            Debug.Log($"Loading {name}.");
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.Log("Last level.");
            Messenger.Broadcast(GameEvent.GAME_COMPLETE);
        }
    }

    /// <summary>
    /// Завершение уровня.
    /// </summary>
    public void ReachObjective()
    {
        Messenger.Broadcast(GameEvent.LEVEL_COMPLETE);
    }

    /// <summary>
    /// Рестарт текущего уровня.
    /// </summary>
    public void RestartCurrentLevel()
    {
        string name = $"Level{CurrentLevel}";
        Debug.Log($"Loading {name}.");
        SceneManager.LoadScene(name);
    }
}
