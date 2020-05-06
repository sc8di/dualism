using System;
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
    [SerializeField] private GameObject _startWords;
    [SerializeField] private GameObject _failLevelWords;
    [SerializeField] private GameObject _endWords;
    [SerializeField] private TextMeshProUGUI _clock;
    [SerializeField] private Routine _routine;
    [SerializeField] private RadialSlider[] _slidersOfNeeds;
    private bool _isShowMenu;
    
    public bool IsShowUI;

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
        Managers.Player.SetNewNeeds();
        
        foreach (var slider in _slidersOfNeeds)
        {
            Debug.Log(slider.name);
            slider.currentValue = 100;
        }
        
        _popup.SetActive(false);
        _isShowMenu = false;
        IsShowUI = true;

        _startWords.SetActive(true);
        _endWords.SetActive(false);

        SetTimeScale(0);
        _failLevelWords.SetActive(false);
    }

    public void StartGame()
    {
        _startWords.SetActive(false);
        SetTimeScale(1);
        IsShowUI = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _popup != null)
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        _isShowMenu = !_isShowMenu;
        _popup.gameObject.SetActive(_isShowMenu);

        if (_isShowMenu)
        {
            IsShowUI = true;
            SetTimeScale(0);
        }
        else
        {
            IsShowUI = false;
            SetTimeScale(1);
        }
    }

    private void SetTimeScale(int value)
    {
        Time.timeScale = value;
    }

    private void FixedUpdate()
    {
        _clock.text = _routine.GetGameTimeInString();
    }

    private void OnNeedsUpdated() // OnStressUpdated.
    {
        for (int i = 0; i < _slidersOfNeeds.Length; i++)
        {
            _slidersOfNeeds[i].SliderValue = Managers.Player.Needs[i].Value;
            _slidersOfNeeds[i].UpdateUI();
        }
    }

    public void RestartLevel()
    {
        Managers.Mission.RestartCurrentLevel();
        SetTimeScale(1);
    }

    private void OnLevelComplete()
    {
        _endWords.SetActive(true);
        SetTimeScale(0);
        IsShowUI = true;
    }

    private void OnLevelFailed()
    {
        StartCoroutine(FailLevel());
    }

    private IEnumerator FailLevel()
    {
        _failLevelWords.SetActive(true);
        IsShowUI = true;

        yield return new WaitForSeconds(3);

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
