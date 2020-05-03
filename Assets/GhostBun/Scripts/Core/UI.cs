using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _popup;
    [SerializeField] private TextMeshProUGUI _levelEnding;
    [SerializeField] private RadialSlider[] _slidersOfNeeds;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.NEEDS_UPDATED, OnNeedsUpdated);
        
        Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.AddListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
        Messenger.AddListener(GameEvent.GAME_COMPLETE, OnGameComplete);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.NEEDS_UPDATED, OnNeedsUpdated);
        
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.RemoveListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
        Messenger.RemoveListener(GameEvent.GAME_COMPLETE, OnGameComplete);
    }
    
    private void Start()
    {
        //popup.SetActive(false);

        foreach (var slider in _slidersOfNeeds)
        {
            Debug.Log(slider.name);
            slider.currentValue = 100;
        }
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

    private void OnNeedsUpdated() // OnStressUpdated.
    {
        for (int i = 0; i < _slidersOfNeeds.Length; i++)
        {
            _slidersOfNeeds[i].SliderValue = Managers.Player.Needs[i].Value;
            _slidersOfNeeds[i].UpdateUI();
        }
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
        
        // Перезапуск уровня.
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
