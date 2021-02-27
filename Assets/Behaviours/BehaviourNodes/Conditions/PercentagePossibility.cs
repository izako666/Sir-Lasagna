using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("MyConditions/Random Chance")]
[Help("gets a random between true and false depending on the percentage given")]
public class PercentagePossibility : GOAction
{
    [InParam("Percentage")]
    [Help("the chance in percentage of returning true")]
    public float percentage;

    public override TaskStatus OnUpdate()
    {
        float random = Random.Range(0, 100);

        if (random <= percentage) {

            return TaskStatus.COMPLETED;

        }

        return TaskStatus.FAILED;
    }
}