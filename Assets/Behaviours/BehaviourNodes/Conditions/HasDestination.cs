using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Action("MyConditions/Has Destination")]
[Help("Checks whether this entity has a destination.")]
public class HasDestination : GOAction
{
    public NavMeshAgent navAgent;
    // this is actually a hasn't destination node cuz im too lazy to figure out how to make an inverter
    public override void OnStart()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    public override TaskStatus OnUpdate()
    {



        return navAgent.hasPath ? TaskStatus.FAILED : TaskStatus.COMPLETED;
    }
}
