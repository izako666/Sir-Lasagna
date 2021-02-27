using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Action("MyActions/Attack")]
[Help("Attacks forward")]

public class Attack : GOAction
{

    [InParam("distance")]
    public float distance;

    [InParam("eyes")]
    public Transform eyes;

    public override void OnStart()
    {
        EntityManager manager = gameObject.GetComponent<EntityManager>();
        RaycastHit[] raycasts = Physics.RaycastAll(gameObject.transform.position, eyes.position - gameObject.transform.position, distance
    );

        EntityStats stats = manager.getStats();

        foreach (RaycastHit hit in raycasts) {

            if (hit.collider.gameObject.GetComponent<EntityManager>() != null) {


                EntityManager hitManager = hit.collider.gameObject.GetComponent<EntityManager>();

                hitManager.getStats().getStat("health").addValue(-stats.getStat("attack").value);
            }
        }

    }

 
    public override TaskStatus OnUpdate()
    {

        return TaskStatus.COMPLETED;
    }

   

}
