using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : EntityManager
{
    public override GameObject getObject()
    {
        return this.gameObject;
    }

    public override void onBirth()
    {
       GameManager manager =  sirLasagna.GetComponent<GameManager>();

        manager.player = this;
    }

    public override void onDeath()
    {
        GameManager manager = sirLasagna.GetComponent<GameManager>();

        manager.player = null;
        GameObject.Destroy(this.gameObject, 0f);


    }

    public override EntityStats getStats()
    {
        return stats;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.onBirth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
