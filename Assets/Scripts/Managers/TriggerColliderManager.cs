using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColliderManager : Manager
{

    public List<EntityManager> entities;
    public PlayerManager player;

    public override GameObject getObject()
    {
        return gameObject;
    }

    public override EntityStats getStats()
    {
        return null;
    }

    public override void onBirth()
    {
    }

    public override void onDeath()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        EntityManager manager = other.gameObject.GetComponent<EntityManager>();

        if (manager != null && manager is PlayerManager)
        {

            this.player = (PlayerManager)manager;
        }
        else if (manager != null) {

            this.entities.Add(manager);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        EntityManager manager = other.gameObject.GetComponent<EntityManager>();

        if (manager != null && manager is PlayerManager)
        {

            this.player = null;
        }
        else if (manager != null)
        {

            this.entities.Remove(this.entities.Find((e) => { return e.getName() == manager.getName(); }));
        }

    }
}
