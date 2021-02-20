using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAnimation : MonoBehaviour
{
    public PlayerStats stats;

    public Image health_bar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health_bar.fillAmount = (float)(fromRangeToRange(0,stats.health.maxValue, 0, 1, stats.health.value));
    }


    public static double fromRangeToRange(double oldMin, double oldMax, double min, double max, double oldValue)
    {

        double newValue = (((oldValue - oldMin) * (max - min)) / (oldMax - oldMin)) + min;
        return newValue;
    }
}
