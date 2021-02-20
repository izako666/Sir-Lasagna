using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{

    public new  void  Start()
    {
        base.Start();
        health.setValue(health.maxValue);
    }

}
