using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzakoUtil
{

    public static double fromRangeToRange(double oldMin, double oldMax, double min, double max, double oldValue)
    {

        double newValue = (((oldValue - oldMin) * (max - min)) / (oldMax - oldMin)) + min;
        return newValue;
    }

}
