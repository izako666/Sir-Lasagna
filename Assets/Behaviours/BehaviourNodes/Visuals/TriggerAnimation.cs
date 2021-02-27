using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("MyActions/Trigger Animation")]
[Help("Triggers an Animation")]
public class TriggerAnimation : GOAction
{

    [InParam("Animator")]
    public Animator animator;

    [InParam("Trigger")]
    public string trigger;


    [InParam("animation state")]
    public string state;
        public override void OnStart()
        {
        animator.SetTrigger(trigger);
        }
        public override TaskStatus OnUpdate()
        {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(state) ? TaskStatus.RUNNING : TaskStatus.COMPLETED;
        }
    
}
