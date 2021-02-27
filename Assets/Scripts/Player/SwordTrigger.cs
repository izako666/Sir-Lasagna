using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
    public ParticleSystem particle;
    public void OnTriggerEnter(Collider other)
    {
        EntityManager manager = other.gameObject.GetComponent<EntityManager>();

        if (manager == null)
            return;

        EntityStats stats = manager.getStats();
        stats.getStat("health").addValue(-2);
        particle.Play();

        
    }


    public void OnTriggerExit(Collider other)
    {
        
    }
}
