using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnersManager : Manager
{

    public SpawnerManager n;
    public SpawnerManager ne;
    public SpawnerManager nw;
    public SpawnerManager s;
    public SpawnerManager se;
    public SpawnerManager sw;
    public SpawnerManager w;
    public SpawnerManager e;

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

    public void spawn(Directions direction, GameObject obj)
    {
        if (Directions.NORTH == direction) {
            n.spawn(obj);
        }
        if (Directions.SOUTH == direction)
        {
            s.spawn(obj);
        }
        if (Directions.NORTHWEST == direction)
        {
            nw.spawn(obj);
        }
        if (Directions.NORTHEAST == direction)
        {
            ne.spawn(obj);
        }
        if (Directions.SOUTHWEST == direction)
        {
            sw.spawn(obj);
        }
        if (Directions.SOUTHEAST == direction)
        {
            se.spawn(obj);
        }
        if (Directions.WEST == direction)
        {
            w.spawn(obj);
        }
        if (Directions.EAST == direction)
        {
            e.spawn(obj);
        }


    }
}
