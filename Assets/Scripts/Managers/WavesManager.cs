using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WavesManager : Manager
{
    public GameManager game;
    public List<WaveValue> WAVES = new List<WaveValue>();
    public List<EntityManager> AVAILABLE_ENEMIES = new List<EntityManager>();
    public override GameObject getObject()
    {
        return this.gameObject;
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

    void Start()
    {
        
    }

    void Update()
    {
        if (game.entities.Count == 0)
        {
            WaveValue wave = WAVES[0];

            for (int i = 0; i < wave.ENTITY_LIST.Count; i++)
            {
                EntityManager entity = wave.ENTITY_LIST[i];
                Directions direction = wave.DIRECTIONS_LIST[i];
                game.spawnersManager.spawn(direction, entity.gameObject);

                print(entity.getName() + "was spawned at" + direction.ToString());
            }

            WAVES.Remove(WAVES[0]);
        }
    }

    [Serializable]
    public  class WaveValue {

        public List<EntityManager> ENTITY_LIST;
        public List<Directions> DIRECTIONS_LIST;
    }
}