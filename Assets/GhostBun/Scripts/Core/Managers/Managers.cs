using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(MissionManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static AudioManager Audio { get; private set; }
    public static MissionManager Mission { get; private set; }

    private List<IGameManager> _startSequence;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        Player = GetComponent<PlayerManager>();
        Audio = GetComponent<AudioManager>();
        Mission = GetComponent<MissionManager>();
        
        _startSequence = new List<IGameManager>();
        _startSequence.Add(Player);
        _startSequence.Add(Audio);
        _startSequence.Add(Mission);

        StartCoroutine(StartupManagers());

        Audio.NextMusic();
    }

    /// <summary>
    /// Иницализация всех менеджеров.
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartupManagers()
    {        
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int countModules = _startSequence.Count;
        int countReady = 0;

        while (countReady < countModules)
        {
            int lastReady = countReady;
            countReady = 0;

            foreach (IGameManager manager in _startSequence)
            {
                if (manager.Status == ManagerStatus.Started) countReady++;
            }

            if (countReady > lastReady)
            {
                Debug.Log($"Progress: {countReady}/{countModules}");
                try { Messenger<int, int>.Broadcast(StartupEvent.MANAGERS_PROGRESS, countReady, countModules); }
                catch { Debug.Log("Progress bar for Managers do not exist."); }              
            }
            yield return null;
        }
        Debug.Log($"All managers started up");

        try { Messenger.Broadcast(StartupEvent.MANAGERS_STARTED); }
        catch { Debug.Log("Managers started in silent."); }        
    }
}
