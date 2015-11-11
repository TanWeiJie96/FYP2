using UnityEngine;
using System.Collections;

public class WallsCollision : OnCollisionReaction{
    public override void onColRec(Collision collision)
    {
        Global.playerScript.motor.COLLISION(collision);
    }
}
