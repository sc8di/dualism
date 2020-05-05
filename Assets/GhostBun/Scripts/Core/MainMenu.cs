using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _settingsAnimations;
    [SerializeField] private SettingsMenu _settingsPopup;
    private string _windowFadeIn = "Demo Window In";
    private string _windowFadeOut = "Demo Window Out";

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Managers.Mission.GoToNext();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowSettings()
    {
        _settingsPopup.RefreshDropdown();
        _settingsAnimations.Play(_windowFadeIn);
    }

    public void HideSettings()
    {
        _settingsAnimations.Play(_windowFadeOut);
    }
}
