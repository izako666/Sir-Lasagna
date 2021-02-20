using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator swordAnimator;
    void Start()
    {
        
    }

    void Update()
    {
        
        if (Input.GetButtonDown("left click")) {
            if (swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("attack_state")) {

                swordAnimator.Play("idle", 0, 0);
            }
            swordAnimator.SetTrigger("attack");
            

        }
    }
}
