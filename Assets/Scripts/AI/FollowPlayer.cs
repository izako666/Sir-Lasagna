using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{

    public NavMeshAgent agent;
   public EntityManager entity;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (entity.player != null && Vector3.Distance(agent.transform.position, entity.player.transform.position) > 1.5)
        {

            agent.SetDestination(entity.player.transform.position);
        }
        else if (entity.player != null && Vector3.Distance(agent.transform.position, entity.player.transform.position) <= 1.5)
        {

            agent.SetDestination(agent.transform.position);
        } 
    }
}
