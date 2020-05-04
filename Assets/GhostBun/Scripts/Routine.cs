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
    [SerializeField] public WaypointOperation[] waypoints;
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
        public bool activated;
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
            }
            Debug.Log(GetGameTimeInString());
            for (int i = 0; i < waypoints.Length; i++)
            {
                if (!waypoints[i].activated && waypoints[i].hoursActivation == currentGameHour && waypoints[i].minutesActivation == currentGameMinute)
                {
                    waypoints[i].activated = true;

                    //Операции с вейпоинтами
                }
            }
            timeFromLastGameMinute = 0;
        }
    }
}
