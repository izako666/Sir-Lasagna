using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleEnemyStats : EntityStats
{
   new  void   Start()
    {
        base.Start();
        health.baseValue = 10;
        health.maxValue = 10;
        health.setValue(health.maxValue);
    }

    
}
