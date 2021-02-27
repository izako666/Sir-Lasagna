using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("MyActions/Health Percentage")]
[Help("checks if the health is below a certain percentage")]
public class HealthPercentage : GOAction
{
    [InParam("Percentage")]
    [Help("the percentage")]
    public float percentage;


    public override TaskStatus OnUpdate()
    {
        EntityStats stats = gameObject.GetComponent<EntityManager>().getStats();
        Stat health = stats.getStat("health");
        double healthPercentage = IzakoUtil.fromRangeToRange(0, health.maxValue, 0, 100, health.value);

        return healthPercentage <= percentage ? TaskStatus.COMPLETED : TaskStatus.FAILED;

    }
}