using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour, IGameManager
{
    private int _currentLevel;
    private int _maxLevel;

    public string CurrentScene { get; private set; }
    public ManagerStatus Status { get; private set; }

    /// <summary>
    /// Инициализация менеджера.
    /// </summary>
    public void Startup()
    {
        Debug.Log("Mission manager starting...");

        _maxLevel = SceneManager.sceneCountInBuildSettings;
        CurrentScene = SceneManager.GetActiveScene().name;
        
        Status = ManagerStatus.Started;
    }

    
    /// <summary>
    /// Следующий уровень.
    /// </summary>
    public void GoToNext()
    {
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        
        if (_currentLevel < _maxLevel)
        {
            _currentLevel++;
            SceneManager.LoadScene(_currentLevel);
            CurrentScene = SceneManager.GetSceneByBuildIndex(_currentLevel).name;
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
        SceneManager.LoadScene(_currentLevel);
    }
}
