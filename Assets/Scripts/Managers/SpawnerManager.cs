using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnerManager : Manager
{
     
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

    public void spawn(GameObject obj) {

        Instantiate(obj);
        obj.GetComponent<EntityManager>().onBirth();
        obj.transform.position = this.getObject().transform.position;


    }
}
