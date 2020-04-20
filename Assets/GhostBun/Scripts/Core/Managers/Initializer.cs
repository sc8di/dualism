using UnityEditor;
using UnityEngine;

// Доработать/избравиться от костыля.

[InitializeOnLoad]
public class Initializer : MonoBehaviour
{
    private static GameObject _gameManager;

    private static void Awake()
    {
        DontDestroyOnLoad(_gameManager);
    }

    [RuntimeInitializeOnLoadMethod]
    static void CreateGameManager()
    {
        _gameManager = Instantiate(Resources.Load("GameManager", typeof(GameObject))) as GameObject; // Убрать это дерьмо. Никаких обращений по именам.
    }

    void OnDestroy()
    {
        Destroy(_gameManager);
    }
}
