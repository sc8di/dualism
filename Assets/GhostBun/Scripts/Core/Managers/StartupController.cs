using UnityEngine;
using UnityEngine.UI;

public class StartupController : MonoBehaviour
{
    [Tooltip("Для отображения прогресса по загрузке менеджеров.")]
    [SerializeField] private Slider _progressBar;

    private void Awake()
    {
        Messenger<int, int>.AddListener(StartupEvent.MANAGERS_PROGRESS, OnManagersProgress);
        Messenger.AddListener(StartupEvent.MANAGERS_STARTED, OnManagersStarted);
    }

    private void OnDestroy()
    {
        Messenger<int, int>.RemoveListener(StartupEvent.MANAGERS_PROGRESS, OnManagersProgress);
        Messenger.RemoveListener(StartupEvent.MANAGERS_STARTED, OnManagersStarted);
    }

    /// <summary>
    /// Задание позиции ползунка ProgressBar'a.
    /// </summary>
    /// <param name="countReady"></param>
    /// <param name="countModules"></param>
    private void OnManagersProgress(int countReady, int countModules)
    {
        float progress = (float) countReady / countModules;
        _progressBar.value = progress;
    }

    /// <summary>
    /// По достижении загрузки всех менеджеров, переход на следующий уровень.
    /// </summary>
    private void OnManagersStarted()
    {
        Managers.Mission.GoToNext();
    }
}
