using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager : MonoBehaviour
{

    public abstract GameObject getObject();
    public abstract void onBirth();

    public abstract void onDeath();
    public abstract EntityStats getStats();
}
