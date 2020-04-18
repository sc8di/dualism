using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    private string _filename;

    public void Startup()
    {
        Debug.Log("Data manager starting...");

        //_filename = Path.Combine(Application.persistentDataPath, "game.dat");

        Status = ManagerStatus.Started;
    }

    public void SaveGameState()
    {
        //Dictionary<string, object> gameState = new Dictionary<string, object>();
        //gameState.Add();
        // Добавить данные в словарь.

        // Записать всё в файл.
        //FileStream stream = File.Create(_filename);
        //BinaryFormatter formatter = new BinaryFormatter();
        //formatter.Serialize(stream, gameState);
        //stream.Close();
    }

    public void LoadGameState()
    {
        if (!File.Exists(_filename))
        {
            Debug.Log("No saved game.");
            return;
        }

        //BinaryFormatter formatter = new BinaryFormatter();
        //FileStream stream = File.Open(_filename, FileMode.Open);
        //Dictionary<string, object> gameState = formatter.Deserialize(stream) as Dictionary<string, object>;
        //stream.Close();
        
        // Присвоение данных из файла. Рестарт уровня?
        //Managers.Mission.RestartCurrentLevel();
    }
}
