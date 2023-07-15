using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTimer : MonoBehaviour
{
    private float currentTime;
    public float countdownTime = 5f;

    private bool isTimerRunning = false;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if(isTimerRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                StopTimer();
                Debug.Log("Timer Termino");
                // Haz perdido. Tu tiempo termino
                CanvasUIManager.sharedInstance.MostrarMuerto();
            }
        }
    }

    private void StartTimer()
    {
        currentTime = countdownTime;
        isTimerRunning = true;
    }

    private void StopTimer()
    {
        isTimerRunning = false;
    }

}
