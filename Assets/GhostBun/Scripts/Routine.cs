using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routine : MonoBehaviour
{
    public enum Operation
    {
        Disable,
        Enable,
    }
    [SerializeField] float dayLengthInMinutes;
    [SerializeField] int startingHour;
    [SerializeField] List<WaypointOperation> waypoints;
    [SerializeField] List<GameObjectOperation> gameObjects;
    float timeFromLastGameMinute = 0f;
    float gameMinuteInSeconds = 0f;
    int currentGameHour = 0;
    int currentGameMinute = 0;

    [System.Serializable]
    public struct WaypointOperation
    {
        public Waypoint wp;
        public int hoursActivation;
        public int minutesActivation;
        public Operation operation;
    }

    [System.Serializable]
    public struct GameObjectOperation
    {
        public GameObject go;
        public int hoursActivation;
        public int minutesActivation;
        public Operation operation;
    }

    public string GetGameTimeInString()
    {
        return (currentGameHour < 10 ? $"0{currentGameHour}" : $"{currentGameHour}") + " : " + (currentGameMinute < 10 ? $"0{currentGameMinute}" : $"{currentGameMinute}");
    }

    private void Start()
    {
        gameMinuteInSeconds = dayLengthInMinutes / 9;
        currentGameHour = startingHour;
    }

    private void FixedUpdate()
    {
        timeFromLastGameMinute += Time.fixedDeltaTime;
        if (timeFromLastGameMinute > gameMinuteInSeconds)
        {
            currentGameMinute++;
            if (currentGameMinute > 59)
            {
                currentGameHour++;
                if (currentGameHour > startingHour + dayLengthInMinutes)
                {
                    GameEnded();
                }
                currentGameMinute = 0;
            }
            Debug.Log(GetGameTimeInString());
            CheckWaypointsActivation();
            CheckGameObjectsActivation();
            timeFromLastGameMinute = 0;
        }
    }

    private void GameEnded()
    {
        BroadcastMessage("GameComplete");
    }

    private void CheckWaypointsActivation()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            if (!waypoints[i].wp)
            {
                waypoints.RemoveAt(i);
                i--;
                continue;
            }
            if (waypoints[i].hoursActivation == currentGameHour && waypoints[i].minutesActivation == currentGameMinute)
            {
                //Операции с вейпоинтами
                Debug.Log("WAYPOINT STATE CHANGED" + waypoints[i].wp.name);
                waypoints.RemoveAt(i);
                i--;
            }
        }
    }
    private void CheckGameObjectsActivation()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (!gameObjects[i].go)
            {
                gameObjects.RemoveAt(i);
                i--;
                continue;
            }
            if (gameObjects[i].hoursActivation == currentGameHour && gameObjects[i].minutesActivation == currentGameMinute)
            {
                //Операции с вейпоинтами
                Debug.Log("GAMEOBJECT STATE CHANGED " + gameObjects[i].go.name);
                gameObjects[i].go.SetActive(gameObjects[i].operation == Operation.Enable ? true : false);
                gameObjects.RemoveAt(i);
                i--;
            }
        }
    }
}
