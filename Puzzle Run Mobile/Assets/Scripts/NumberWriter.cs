using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberWriter : MonoBehaviour
{
    private TextMeshProUGUI uiText;
    private int intToWrite;
    private int currentInt;
    private float floatToWrite;
    private float currentFloat;
    private float timePerSum;
    private float timer;
    private bool isTime;

    public bool IsReady()
    {
        return uiText == null;
    }

    public void WriteTime(TextMeshProUGUI uiText, float floatToWrite, float timePerSum)
    {
        this.uiText = uiText;
        this.floatToWrite = floatToWrite;
        this.timePerSum = timePerSum;
        this.isTime = true;

        currentFloat = 0;
    }

    public void WriteInt(TextMeshProUGUI uiText, int intToWrite, float timePerSum)
    {
        this.uiText = uiText;
        this.intToWrite = intToWrite;
        this.timePerSum = timePerSum;
        this.isTime = false;

        currentInt = 0;
    }

    private void Update()
    {
        if (uiText != null)
        {
            if (isTime) 
                UpdateTime();
            else 
                UpdateInt();
        }
    }

    private void UpdateTime()
    {
        timer -= Time.deltaTime;
        while (timer <= 0)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(currentFloat);
            uiText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);

            timer += timePerSum;
            currentFloat++;

            if (floatToWrite > 1000 && currentFloat > 100 && currentFloat + 10 < floatToWrite) currentFloat += 10;
            if (floatToWrite > 10000 && currentFloat > 1000 && currentFloat + 100 < floatToWrite) currentFloat += 100;
            if (floatToWrite > 100000 && currentFloat > 10000 && currentFloat + 1000 < floatToWrite) currentFloat += 1000;

            if (currentFloat > floatToWrite)
            {
                uiText = null;
                return;
            }  
        }
    }

    private void UpdateInt()
    {
        timer -= Time.deltaTime;
        while (timer <= 0)
        {
            uiText.text = currentInt.ToString();

            timer += timePerSum;
            currentInt++;

            if (intToWrite > 1000 && currentInt > 100 && currentInt + 10 < intToWrite) currentInt += 10;
            if (intToWrite > 10000 && currentInt > 1000 && currentInt + 100 < intToWrite) currentInt += 100;
            if (intToWrite > 100000 && currentInt > 10000 && currentInt + 1000 < intToWrite) currentInt += 1000;
            if (intToWrite > 1000000 && currentInt > 100000 && currentInt + 10000 < intToWrite) currentInt += 10000;
            if (intToWrite > 10000000 && currentInt > 1000000 && currentInt + 100000 < intToWrite) currentInt += 100000;
            if (intToWrite > 100000000 && currentInt > 10000000 && currentInt + 1000000 < intToWrite) currentInt += 1000000;

            if (currentInt > intToWrite)
            {
                uiText = null;
                return;
            }  
        }
    }
}
