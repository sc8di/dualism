using System.Collections;
using TMPro;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class UIController : MonoBehaviour
{
    //[SerializeField] private SettingsPopup popup;
    [SerializeField] private TextMeshProUGUI levelEnding;
    [SerializeField] private GameObject[] lifes;

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
        //popup.gameObject.SetActive(false);
        
        OnHealthUpdated(); // StressUpdated?
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isShowingSettings = false; // popup.gameObject.activeSelf;
            //popup.gameObject.SetActive(!isShowingSettings);

            if (isShowingSettings)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    private void OnHealthUpdated() // OnStressUpdated.
    {
        if (Managers.Player.health < Managers.Player.maxHealth)
        {
            lifes[Managers.Player.health].SetActive(false);
        }
    }

    private void OnLevelComplete()
    {
        StartCoroutine(CompleteLevel());
    }

    private IEnumerator CompleteLevel()
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
