using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("MyConditions/Can See")]
[Help("Checks whether this entity can see an entity.")]

public class CanSee : GOAction
{

    [InParam("Entity")]
    [Help("The entity to be seen")]
    public GameObject entity;

    [InParam("distance")]
    [Help("the distance it can see for")]
    public float distance;


    public BoxCollider collider;
    public override TaskStatus OnUpdate()
    {

        
        EntityManager manager = gameObject.GetComponent<EntityManager>();

        if (manager != null) {

            return manager.canSeeEntity(entity.transform, distance) ? TaskStatus.COMPLETED : TaskStatus.FAILED;
        }

        return TaskStatus.FAILED;
    }
}
