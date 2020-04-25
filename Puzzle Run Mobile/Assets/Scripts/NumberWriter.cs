using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWriter : MonoBehaviour
{
    private Text uiText;
    private float numberToWrite;
    private float timePerNumber;
    private float currentNumber;
    private float timer;
    private bool isTime;

    public bool IsReady()
    {
        return uiText == null;
    }

    public void Write(Text uiText, float numberToWrite, float timeToWrite, bool isTime = false)
    {
        this.uiText = uiText;
        this.numberToWrite = numberToWrite;
        this.isTime = isTime;

        currentNumber = 0;        
        timePerNumber = (numberToWrite != 0) ? timeToWrite / numberToWrite : 0;
    }

    private void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            while (timer <= 0)
            {
                if (isTime)
                {
                    TimeSpan timeSpan = TimeSpan.FromSeconds(currentNumber);
                    uiText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
                }
                else
                    uiText.text = currentNumber.ToString();

                timer += timePerNumber;
                currentNumber++;

                if (currentNumber > numberToWrite)
                {
                    uiText = null;
                    return;
                }  
            }
        }
    }
}
