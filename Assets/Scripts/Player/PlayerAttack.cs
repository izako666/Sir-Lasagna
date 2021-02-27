using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator swordAnimator;
    public Transform eyes;
   public ParticleSystem particle;
    void Start()
    {
        
    }

    void Update()
    {
        
        if (Input.GetButtonDown("left click")) {
            if (swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {

                swordAnimator.Play("sword_attack_1", 0, 0);
                attack();
            }

           else if (swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("sword_attack_1")) {

                swordAnimator.Play("sword_attack_2", 0, 0);
                attack();
            }
            else if (swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("sword_attack_2"))
            {

                swordAnimator.Play("sword_attack_3", 0, 0);
                attack();
            }
            else if (swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("sword_attack_3"))
            {

                swordAnimator.Play("idle", 0, 0);
            }

            

        }
    }

    private void attack() {

        RaycastHit[] raycasts = Physics.RaycastAll(this.transform.position, eyes.position - this.transform.position, 4
            );


        foreach (RaycastHit raycast in raycasts)
        {
            EntityManager manager = raycast.collider.gameObject.GetComponent<EntityManager>();

            if (manager == null)
                return;

            if (manager.Equals(this.gameObject.GetComponent<EntityManager>()))
            {

                return;
            }

            EntityStats stats = manager.getStats();
            stats.getStat("health").addValue(-this.GetComponent<EntityManager>().getStats().getStat("attack").value);

            particle.Play();
        }

    }
}
