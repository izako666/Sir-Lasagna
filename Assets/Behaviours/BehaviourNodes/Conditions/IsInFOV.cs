using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("MyConditions/Is In FOV")]
[Help("Checks whether this entity is in the entity's field of vision")]
public class IsInFOV : GOAction
{

    [InParam("Entity")]
    [Help("The entity to be checked")]
    public GameObject entity;

    public override TaskStatus OnUpdate()
    {


        EntityManager manager = gameObject.GetComponent<EntityManager>();

        if (manager != null)
        {

            TriggerColliderManager collider = manager.FOV.GetComponent<TriggerColliderManager>();

            EntityManager entityManager = entity.GetComponent<EntityManager>();
            foreach (EntityManager otherEntity in collider.entities) {

                if (entityManager.getName().Equals(otherEntity.getName())) {

                    return TaskStatus.COMPLETED;
                }
            }

            if (collider.player != null && entityManager.getName().Equals(collider.player.getName())) {
                return TaskStatus.COMPLETED;
            }
            
        }

        return TaskStatus.FAILED;
    }
}
