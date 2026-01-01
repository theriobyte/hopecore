using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10f; // Timer duration in seconds
    public bool timerIsRunning = false;
    private void Start()
    {
        timerIsRunning = true; // Start the timer
    }
    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Decrease time
                DisplayTime(timeRemaining); // Optional: Display the time
            }
            else
            {
                UnityEngine.Debug.Log("Time's up!");
                timeRemaining = 0;
                timerIsRunning = false; // Stop the timer
            }
        }
    }
    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        UnityEngine.Debug.Log($"{minutes:00}:{seconds:00}"); // Display in MM:SS format
    }
}