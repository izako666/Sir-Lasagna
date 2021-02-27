using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettuceManager : EntityManager
{

    public override string getName()
    {

        return gameObject.name;
    }


    public override void onBirth()
    {
        base.onBirth();
    }

    public override void setBehaviourParams() {
        BehaviorExecutor behaviorExecutor = GetComponent<BehaviorExecutor>();
        GameManager gManager = sirLasagna.GetComponent<GameManager>();

       behaviorExecutor.SetBehaviorParam("gameObject", gameObject);
        behaviorExecutor.SetBehaviorParam("homePosition", transform.position);
        behaviorExecutor.SetBehaviorParam("player", gManager.player.gameObject);



    }


}
