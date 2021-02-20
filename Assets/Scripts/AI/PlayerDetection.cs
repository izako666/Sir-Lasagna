using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    public EntityManager entity;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerManager>() != null) {

            entity.player = other.gameObject.GetComponent<PlayerManager>();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerManager>() != null)
        {

            entity.player = null;
        }

    }
}
