using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : Manager
{

    public GameObject sirLasagna;
    public PlayerManager player = null;
    public EntityStats stats;
    public override GameObject getObject()
    {
        return this.gameObject;
    }


    public override void onBirth()
    {
        sirLasagna = GameObject.Find("SirLasagna");

        GameManager gameManager = sirLasagna.GetComponent<GameManager>();

        gameManager.entities.Add(this);
    }

    public override void onDeath()
    {
        GameManager gameManager = sirLasagna.GetComponent<GameManager>();


        gameManager.entities.Remove(gameManager.entities.Find((e) => { return e.getName() == this.getName(); }));
        GameObject.Destroy(this.gameObject, 0f);

    }

    public override EntityStats getStats()
    {
        return stats;
    }

    public string getName() {

        return "entity";
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
}
