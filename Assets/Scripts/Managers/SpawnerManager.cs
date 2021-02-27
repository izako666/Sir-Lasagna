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

        GameObject newObj = Instantiate(obj);
        newObj.name = newObj.name + Random.Range(1, 99999).ToString();
        newObj.transform.position = this.getObject().transform.position;
        newObj.GetComponent<EntityManager>().onBirth();
        newObj.GetComponent<EntityManager>().setBehaviourParams();


    }
}
