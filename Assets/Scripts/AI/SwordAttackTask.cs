using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwordAttackTask : MonoBehaviour
{
    public NavMeshAgent agent;
    public EntityManager entity;
    public Animator sword;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        entity = GetComponent<EntityManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (entity.player != null && Vector3.Distance(agent.transform.position, entity.player.transform.position) <= 1.5)
        {
            if (!sword.GetCurrentAnimatorStateInfo(0).IsName("attack_state"))
            {
                agent.transform.LookAt(entity.player.transform);
                sword.SetTrigger("attack");
            }
            
        }


    }
}
