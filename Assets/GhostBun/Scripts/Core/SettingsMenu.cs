using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _soundVolume;
    [SerializeField] private TextMeshProUGUI _test;
    private Resolution[] _resolutions;
    private int _currentResolutionIndex;
    
    public CustomDropdown ResolutionDropdown;

    private void Start()
    {
        _resolutions = Screen.resolutions;

        foreach (var item in _resolutions)
        {
            Debug.Log(item.width);
        }
        
        _currentResolutionIndex = 4;

        ResolutionDropdown.selectedItemIndex = _currentResolutionIndex;
        ResolutionDropdown.SetupDropdown();

        Screen.SetResolution(1920, 1080, true);

        if (Managers.Audio != null)
        {
            _musicVolume.value = Managers.Audio.MusicVolume;
            _soundVolume.value = Managers.Audio.SoundVolume;
        }
    }

    public void RefreshDropdown()
    {
        ResolutionDropdown.selectedItemIndex = _currentResolutionIndex;
        ResolutionDropdown.SetupDropdown();
    }
        
    public void SetFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        int width = int.Parse(ResolutionDropdown.dropdownItems[resolutionIndex].itemName.Split('x')[0]);
        int height = int.Parse(ResolutionDropdown.dropdownItems[resolutionIndex].itemName.Split('x')[1]);
        
        Screen.SetResolution(width, height, Screen.fullScreen);
        
        Debug.Log($"{width}x{height}");
    }

    /// <summary>
    /// Выключение звука эффектов (в данном случае только UI).
    /// </summary>
    public void OnSoundToggle()
    {
        if (Managers.Audio == null) return;
        Managers.Audio.SoundMute = !Managers.Audio.SoundMute;
    }

    /// <summary>
    /// Значение громкости с ползунка громкости звуков.
    /// </summary>
    /// <param name="volume"></param>
    public void OnSoundValue(float volume)
    {
        if (Managers.Audio == null) return;
        Managers.Audio.SoundVolume = volume;
    }
    
    /// <summary>
    /// Выключение звука музыки.
    /// </summary>
    public void OnMusicToggle()
    {
        if (Managers.Audio == null) return;
        Managers.Audio.MusicMute = !Managers.Audio.MusicMute;
    }

    /// <summary>
    /// Значение громкости с ползунка громкости музыки.
    /// </summary>
    /// <param name="volume"></param>
    public void OnMusicValue(float volume)
    {
        if (Managers.Audio == null) return;
        Managers.Audio.MusicVolume = volume;
    }
}
