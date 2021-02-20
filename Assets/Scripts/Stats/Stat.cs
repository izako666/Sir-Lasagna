using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    public double baseValue = 1d;
    public double value = 1d;
    public double maxValue = 1d;
    public EntityStats parent;

    public Stat(double baseValue,EntityStats parent) {


        this.baseValue = baseValue;
        this.value = baseValue;
        this.maxValue = baseValue;
        this.parent = parent;

    }

    public Stat(double baseValue,double maxValue, EntityStats parent)
    {


        this.baseValue = baseValue;
        this.value = baseValue;
        this.maxValue = maxValue;
        this.parent = parent;

    }

    public void setValue(double val) {
        if (val > maxValue)
        {
            this.value = maxValue;
        }
        else if (val <= 0)
        {
            this.value = 0;

            this.parent.gameObject.GetComponent<EntityManager>().onDeath();
        }
        else {

            this.value = val;
        }
    
    }

    public void addValue(double val) { this.setValue(this.value + val); }

}
