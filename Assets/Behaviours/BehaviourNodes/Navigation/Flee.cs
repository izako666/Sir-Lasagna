using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Action("MyActions/Flee")]
[Help("Flees from an entity")]

public class Flee : BasePrimitiveAction
{

    public NavMeshAgent navAgent;
    [InParam("Game Object")]
    public GameObject gameObject;
    [InParam("Min Range")]
    public float minRange;
    [InParam("Radius")]
    public float maxRange;
    [InParam("Entity")]
    public GameObject entity;

    [InParam("Eyes")]
    public Transform eyes;

    public override void OnStart()
    {
        navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (navAgent == null)
        {
            Debug.LogWarning("The " + gameObject.name + " game object does not have a Nav Mesh Agent component to navigate. One with default values has been added", gameObject);
            navAgent = gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>();
        }
        navAgent.SetDestination(getPosition(minRange, maxRange));

#if UNITY_5_6_OR_NEWER
        navAgent.isStopped = false;
#else
                navAgent.Resume();
#endif
    }

    private Vector3 getPosition(float minR, float maxR)
    {
        Vector3 normalizedArea = UnityEngine.Random.insideUnitSphere;

       Vector3 direction =  -(eyes.position - gameObject.transform.position) * minR * 2;
         
       
        direction += gameObject.transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(direction, out hit, maxR, 1);
        Vector3 finalPosition = hit.position;
        return finalPosition;
    }

    public override TaskStatus OnUpdate()
    {
        if (!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
            return TaskStatus.COMPLETED;
        return TaskStatus.RUNNING;
    }

    public override void OnAbort()
    {
#if UNITY_5_6_OR_NEWER
        navAgent.isStopped = true;
#else
                navAgent.Stop();
#endif
    }

}
