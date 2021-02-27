using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("MyActions/Play Particle")]
[Help("Plays A Particle")]
public class PlayParticle : GOAction
{

    [InParam("particle")]
    public ParticleSystem particle;
    public override void OnStart()
    {
        particle.Play();
    }
    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }

}
