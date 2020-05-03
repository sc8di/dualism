using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    [Tooltip("Источник звуков.")]
    [SerializeField] private AudioSource _soundSource;
    [Tooltip("Первый источник музыки.")]
    [SerializeField] private AudioSource _musicFirstSource;
    [Tooltip("Второй источник музыки.")]
    [SerializeField] private AudioSource _musicSecondSource;
    [Tooltip("Массив треков.")]
    [SerializeField] private AudioClip[] _clips;

    private AudioSource _firstMusic;
    private AudioSource _secondMusic;
    private bool _crossFading;
    private float _musicVolume;
    private int _currentClipNumber = -1;
    private bool _toggleMusic = true;

    [Tooltip("Скорость плавного перехода между треками.")]
    public float crossFadeRate = 1.5f;
    public ManagerStatus Status { get; private set; }

    /// <summary>
    /// Изменение громкости музыки.
    /// </summary>
    public float MusicVolume
    {
        get
        {
            return _musicVolume;
        }
        set
        {
            _musicVolume = value;
            if (_musicFirstSource != null && !_crossFading)
            {
                _musicFirstSource.volume = _musicVolume;
                _musicSecondSource.volume = _musicVolume;
            }
        }
    }

    /// <summary>
    /// Переключения мута музыки.
    /// </summary>
    public bool MusicMute
    {
        get
        {
            if (_musicFirstSource != null)
            {
                return _musicFirstSource.mute;
            }
            return false;
        }
        set
        {
            if (_musicFirstSource != null)
            {
                _musicFirstSource.mute = value;
                _musicSecondSource.mute = value;
            }
        }
    }

    /// <summary>
    /// Изменения громкости звука.
    /// </summary>
    public float SoundVolume
    {
        get
        {
            return AudioListener.volume;
        }
        set
        {
            AudioListener.volume = value;
        }
    }

    /// <summary>
    /// Переключения мута звука.
    /// </summary>
    public bool SoundMute
    {
        get 
        { 
            return AudioListener.pause; 
        }
        set 
        { 
            AudioListener.pause = value; 
        }
    }

    /// <summary>
    /// Инициализация аудио менеджера.
    /// </summary>
    public void Startup()
    {
        Debug.Log("Audio manager starting...");

        _musicFirstSource.ignoreListenerVolume = true;
        _musicFirstSource.ignoreListenerPause = true;
        _musicSecondSource.ignoreListenerVolume = true;
        _musicSecondSource.ignoreListenerPause = true;

        SoundVolume = 1;
        MusicVolume = .1f;

        if (_clips.Length != 0)
            _musicFirstSource.clip = _clips[0];

        _firstMusic = _musicFirstSource;
        _secondMusic = _musicSecondSource;

        Status = ManagerStatus.Started;
    }

    /// <summary>
    /// Проигрывание звука.
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySound(AudioClip clip)
    {
        _soundSource.PlayOneShot(clip);
    }

    /// <summary>
    /// Следующий трек.
    /// </summary>
    public void NextMusic()
    {
        if (_clips.Length == 0) 
            return;

        if (!_toggleMusic) 
            _toggleMusic = true;
        
        if (_currentClipNumber >= _clips.Length - 1) 
            _currentClipNumber = 0;
        else 
            _currentClipNumber++;

        PlayMusic(Resources.Load("Music/" + _clips[_currentClipNumber].name) as AudioClip);
    }

    /// <summary>
    /// Предыдущий трек.
    /// </summary>
    public void PreviousMusic()
    {
        if (_clips.Length == 0) 
            return;

        if (!_toggleMusic) 
            _toggleMusic = true;
        
        if (_currentClipNumber <= 0) 
            _currentClipNumber = _clips.Length - 1;
        else 
            _currentClipNumber--;

        PlayMusic(Resources.Load("Music/" + _clips[_currentClipNumber].name) as AudioClip);
    }

    /// <summary>
    /// Начало проигрывания музыки.
    /// </summary>
    /// <param name="clip"></param>
    private void PlayMusic(AudioClip clip)
    {
        if (_crossFading)        
            return;
        
        StartCoroutine(CrossFadeMusic(clip));
    }

    /// <summary>
    /// Если трек закончился, переход к следующему.
    /// </summary>
    private void FixedUpdate()
    {
        if (_toggleMusic && !_firstMusic.isPlaying && !_secondMusic.isPlaying)        
            NextMusic();        
    }

    /// <summary>
    /// Плавный переход от одной компоции к другой.
    /// </summary>
    /// <param name="clip"></param>
    /// <returns></returns>
    private IEnumerator CrossFadeMusic(AudioClip clip)
    {
        _crossFading = true;

        _secondMusic.clip = clip;
        _secondMusic.volume = 0;
        _secondMusic.Play();

        float scaledRate = crossFadeRate * _musicVolume;
        while (_firstMusic.volume > 0)
        {
            _firstMusic.volume -= scaledRate * Time.deltaTime;
            _secondMusic.volume += scaledRate * Time.deltaTime;
            yield return null;
        }

        AudioSource temp = _firstMusic;
        _firstMusic = _secondMusic;
        _firstMusic.volume = _musicVolume;

        _secondMusic = temp;
        _secondMusic.Stop();

        _crossFading = false;
    }

    /// <summary>
    /// Останавливает воспроизведение музыки.
    /// </summary>
    public void StopMusic()
    {
        _firstMusic.Stop();
        _secondMusic.Stop();
        _toggleMusic = false;
    }
}
