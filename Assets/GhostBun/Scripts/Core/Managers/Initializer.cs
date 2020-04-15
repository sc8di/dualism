using UnityEditor;
using UnityEngine;

// Доработать/избравиться от костыля.

[InitializeOnLoad]
public class Initializer : MonoBehaviour
{
    private static GameObject gameManager;

    private static void Awake()
    {
        DontDestroyOnLoad(gameManager);
    }

    [RuntimeInitializeOnLoadMethod]
    static void CreateGameManager()
    {
        gameManager = Instantiate(Resources.Load("GameManager", typeof(GameObject))) as GameObject;
    }

    void OnDestroy()
    {
        Destroy(gameManager);
    }
}
