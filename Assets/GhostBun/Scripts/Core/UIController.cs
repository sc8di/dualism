using System.Collections;
using TMPro;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _popup;
    [SerializeField] private TextMeshProUGUI _levelEnding;
    [SerializeField] private GameObject[] _lifes;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated); // Стресс?
        Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.AddListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
        Messenger.AddListener(GameEvent.GAME_COMPLETE, OnGameComplete);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated); // Стресс?
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.RemoveListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
        Messenger.RemoveListener(GameEvent.GAME_COMPLETE, OnGameComplete);
    }
    
    private void Start()
    {
        //popup.SetActive(false);        
        OnHealthUpdated(); // StressUpdated?
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _popup != null)
        {
            _popup.gameObject.SetActive(!_popup.activeInHierarchy);
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    private void OnHealthUpdated() // OnStressUpdated.
    {
        if (Managers.Player.Health < Managers.Player.MaxHealth)
            _lifes[Managers.Player.Health].SetActive(false);
    }

    private void OnLevelComplete()
    {
        StartCoroutine(CompleteLevel());
    }

    private static IEnumerator CompleteLevel()
    {
        // Отображение надписи о завершении уровня.

        yield return new WaitForSeconds(2);
        
        Managers.Mission.GoToNext();
    }

    private void OnLevelFailed()
    {
        StartCoroutine(FailLevel());
    }

    private static IEnumerator FailLevel()
    {
        // Отображение надписи о проигрыше.

        yield return new WaitForSeconds(2);
        
        Managers.Player.RespawnFull();
        Managers.Mission.RestartCurrentLevel();
    }

    public void SaveGame()
    {
        //Managers.Data.SaveGameState();
    }

    public void LoadGame()
    {
        //Managers.Data.LoadGameState();
    }

    private void OnGameComplete()
    {
        // Отображение надписи о завершении игры.
    }
}
