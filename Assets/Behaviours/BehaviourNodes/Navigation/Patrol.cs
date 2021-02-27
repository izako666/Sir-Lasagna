using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Action("MyActions/Patrol")]
[Help("Patrols around a specific area")]

public class Patrol : BasePrimitiveAction
{

    public NavMeshAgent navAgent;
    [InParam("Game Object")]
    public GameObject gameObject;
    [InParam("Min Range")]
    public float minRange;
    [InParam("Max Range")]
    public float maxRange;
    [InParam("Home Position")]
    public Vector3 home;

    public override void OnStart()
    {
        navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (navAgent == null)
        {
            Debug.LogWarning("The " + gameObject.name + " game object does not have a Nav Mesh Agent component to navigate. One with default values has been added", gameObject);
            navAgent = gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>();
        }
        if (Vector3.Distance(home, navAgent.transform.position) > 4)
        {

            navAgent.SetDestination(home);
        }
        else {

            navAgent.SetDestination(getRandPosition(minRange,maxRange));

        }

#if UNITY_5_6_OR_NEWER
        navAgent.isStopped = false;
#else
                navAgent.Resume();
#endif
    }

    private Vector3 getRandPosition(float minR, float maxR)
    {
        double minNormalized = IzakoUtil.fromRangeToRange(0, maxR, 0, 1, minR);
        Vector3 normalizedArea = UnityEngine.Random.insideUnitSphere;
        if (Math.Abs(normalizedArea.x) < minNormalized) {

            normalizedArea.x *= 2;
        
        }
       

        if (Math.Abs(normalizedArea.z) < minNormalized)
        {

            normalizedArea.z *= 2;

        }

        Vector3 randomDirection = normalizedArea * maxR;
        randomDirection += gameObject.transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, maxR, 1);
        Vector3 finalPosition = hit.position;
        return finalPosition;
    }

    public override TaskStatus OnUpdate()
    {

        return TaskStatus.COMPLETED;
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
