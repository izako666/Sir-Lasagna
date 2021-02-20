using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public Stat health = new Stat(20, null);
    public Stat attack = new Stat(2, null);

    public  void Start()
    {
      health = new Stat(20, this);
      attack = new Stat(2, this);

}
public Stat getStat(string name)
    {
        if (name == "health")
        {

            return health;
        }
        if (name == "attack")
        {

            return attack;
        }
        return null;
    }
}
