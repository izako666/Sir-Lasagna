using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("MyActions/Heal")]
[Help("Heals the entity till a certain amount")]
public class Heal : GOAction
{

    [InParam("Health Increment")]
    public float increment;

    [InParam("Health Target")]
    public float target;

    public override void OnStart()
    {
        EntityStats stats = gameObject.GetComponent<EntityManager>().getStats();
        Stat health = stats.getStat("health");

        health.addValue(increment);
    }
    public override TaskStatus OnUpdate()
    {
        EntityStats stats = gameObject.GetComponent<EntityManager>().getStats();

        Stat health = stats.getStat("health");

        return health.value >= target ? TaskStatus.COMPLETED : TaskStatus.FAILED;
    }

}
