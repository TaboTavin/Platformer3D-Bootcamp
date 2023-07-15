using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPowerUp : MonoBehaviour
{
    //Timer
    public float countdownTime = 5f;
    private float currentTime;

    private bool isTimerRunning = false;
    //Timer de power Up

    private void Update()
    {
        //Verificar si el bool de PowerUp esta Activo y el timer no este en marcha.
        if (PowerUp.sharedInstance.powerUpActive && !isTimerRunning)
        {
            StartTimer();
        }

        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                StopTimer();
                PowerUp.sharedInstance.powerUpActive = false;
            }
        }
    }

    private void StartTimer()
    {
        currentTime = countdownTime;
        isTimerRunning = true;
        Debug.Log("PowerUp Activado");
    }

    private void StopTimer()
    {
        isTimerRunning = false;
        Debug.Log("PowerUp DesActivado");
    }

}
