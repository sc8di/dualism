using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(MissionManager))]
//[RequireComponent(typeof(UserInputManager))]
//[RequireComponent(typeof(PowerManager))]
//[RequireComponent(typeof(DataManager))]
//[RequireComponent(typeof(ItemsManager))]
//[RequireComponent(typeof(NpcManager))]
//[RequireComponent(typeof(GhostBunManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static AudioManager Audio { get; private set; }
    public static MissionManager Mission { get; private set; }
    //public static UserInputManager UserInput { get; private set; }
    //public static PowerManager Powers { get; private set; }
    //public static DataManager Data { get; private set; }
    //public static ItemsManager Items { get; private set; }
    //public static NpcManager NPC { get; private set; }
    //public static GhostBunManager GhostBuns { get; private set; }

    private List<IGameManager> _startSequence;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        Player = GetComponent<PlayerManager>();
        Audio = GetComponent<AudioManager>();
        Mission = GetComponent<MissionManager>();
        //UserInput = GetComponent<UserInputManager>();
        //Powers = GetComponent<PowerManager>();
        //Data = GetComponent<DataManager>();
        //Items = GetComponent<ItemsManager>();
        //NPC = GetComponent<NpcManager>();
        //GhostBuns = GetComponent<GhostBunManager>();
        
        _startSequence = new List<IGameManager>();
        _startSequence.Add(Player);
        _startSequence.Add(Audio);
        _startSequence.Add(Mission);
        //_startSequence.Add(UserInput);
        //_startSequence.Add(Powers);
        //_startSequence.Add(Data);
        //_startSequence.Add(Items);
        //_startSequence.Add(NPC);
        //_startSequence.Add(GhostBuns);

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
