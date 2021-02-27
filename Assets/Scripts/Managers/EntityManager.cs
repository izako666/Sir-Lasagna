using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : Manager
{

    public GameObject sirLasagna;
    public PlayerManager player = null;
    public EntityStats stats;

    public GameObject FOV;
    public override GameObject getObject()
    {
        return this.gameObject;
    }


    public override void onBirth()
    {
        sirLasagna = GameObject.FindWithTag("SirLasagna");

        GameManager gameManager = sirLasagna.GetComponent<GameManager>();

        gameManager.entities.Add(this);

    }

    public override void onDeath()
    {

        if (this != null && this.gameObject != null && this.gameObject.GetComponent<EntityManager>() != null) {

            GameManager gameManager = sirLasagna.GetComponent<GameManager>();

            string name = this.getName();
            gameManager.entities.Remove(gameManager.entities.Find((e) => { return e.getName().Equals(name); }));

        }

        GameObject.Destroy(this.gameObject);

    }

    public override EntityStats getStats()
    {
        return stats;
    }

    public virtual string  getName() {

        return "entity";
    }

    public bool canSeeEntity(Transform entity, float distance) {
        RaycastHit hit;
        Physics.Raycast(transform.position, entity.position - transform.position, out hit, distance);
        Debug.DrawRay(transform.position, entity.position - transform.position, Color.green, 20);

        if (hit.collider == null)
            return false;

      

            if (hit.collider.gameObject.Equals(entity.gameObject))
            {

                return true;
            }


        
        return false;    
    
    }

    public virtual void setBehaviourParams() { }
}
