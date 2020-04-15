using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    [Tooltip("Источник звуков.")]
    [SerializeField] private AudioSource soundSource;
    [Tooltip("Первый источник музыки.")]
    [SerializeField] private AudioSource musicFirstSource;
    [Tooltip("Второй источник музыки.")]
    [SerializeField] private AudioSource musicSecondSource;
    [Tooltip("Массив треков.")]
    [SerializeField] private AudioClip[] clips;

    private AudioSource _firstMusic;
    private AudioSource _secondMusic;

    [Tooltip("Скорость плавного перехода между треками.")]
    public float crossFadeRate = 1.5f;
    private bool _crossFading;

    private float _musicVolume;
    private int _currentClipNumber = -1;
    private bool toggleMusic = true;

    /// <summary>
    /// Изменение громкости музыки.
    /// </summary>
    public float musicVolume
    {
        get { return _musicVolume; }
        set
        {
            _musicVolume = value;
            if (musicFirstSource != null && !_crossFading)
            {
                musicFirstSource.volume = _musicVolume;
                musicSecondSource.volume = _musicVolume;
            }
        }
    }

    /// <summary>
    /// Переключения мута музыки.
    /// </summary>
    public bool musicMute
    {
        get
        {
            if (musicFirstSource != null)
            {
                return musicFirstSource.mute;
            }

            return false;
        }
        set
        {
            if (musicFirstSource != null)
            {
                musicFirstSource.mute = value;
                musicSecondSource.mute = value;
            }
        }
    }

    /// <summary>
    /// Изменения громкости звука.
    /// </summary>
    public float soundVolume
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }

    /// <summary>
    /// Переключения мута звука.
    /// </summary>
    public bool soundMute
    {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }

    /// <summary>
    /// Инициализация аудио менеджера.
    /// </summary>
    public void Startup()
    {
        Debug.Log("Audio manager starting...");

        musicFirstSource.ignoreListenerVolume = true;
        musicFirstSource.ignoreListenerPause = true;
        musicSecondSource.ignoreListenerVolume = true;
        musicSecondSource.ignoreListenerPause = true;

        soundVolume = 1;
        musicVolume = .1f;

        if (clips.Length != 0)
        {
            musicFirstSource.clip = clips[0];
        }

        _firstMusic = musicFirstSource;
        _secondMusic = musicSecondSource;

        Status = ManagerStatus.Started;
    }

    /// <summary>
    /// Проигрывание звука.
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }

    /// <summary>
    /// Следующий трек.
    /// </summary>
    public void NextMusic()
    {
        if (clips.Length == 0) return;

        if (!toggleMusic) toggleMusic = true;
        
        if (_currentClipNumber >= clips.Length - 1) _currentClipNumber = 0;
        else _currentClipNumber++;
        PlayMusic(Resources.Load("Music/" + clips[_currentClipNumber].name) as AudioClip);
    }

    /// <summary>
    /// Предыдущий трек.
    /// </summary>
    public void PreviousMusic()
    {
        if (clips.Length == 0) return;

        if (!toggleMusic) toggleMusic = true;
        
        if (_currentClipNumber <= 0) _currentClipNumber = clips.Length - 1;
        else _currentClipNumber--;
        PlayMusic(Resources.Load("Music/" + clips[_currentClipNumber].name) as AudioClip);
    }

    /// <summary>
    /// Начало проигрывания музыки.
    /// </summary>
    /// <param name="clip"></param>
    private void PlayMusic(AudioClip clip)
    {
        if (_crossFading)
        {
            return;
        }
        StartCoroutine(CrossFadeMusic(clip));
    }

    /// <summary>
    /// Если трек закончился, переход к следующему.
    /// </summary>
    private void FixedUpdate()
    {
        if (toggleMusic && !_firstMusic.isPlaying && !_secondMusic.isPlaying)
        {
            NextMusic();
        }
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
        toggleMusic = false;
    }
}
