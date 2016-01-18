using UnityEngine;
using System.Collections;
using System;

public class WallsCollision : OnColReactTemplete { 
    
    public override void onColRec(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            BasicVar cur = Global.playerScript.motor.cur;

            //cur.vel.x = -cur.vel.x;
            //cur.vel = Vector3.Reflect(

            cur.vel.Scale(new Vector3(0.9f, 0.9f, 0.9f));

            Global.playerScript.motor.cur = cur;


            Debug.Log("Hit wall");
        }


        if (collision.gameObject.tag == "Floor")
        {
            //Global.playerScript.motor.RbToMove.angularVelocity = Vector3.zero;
            Debug.Log("Hit Floor");
        }
    }

    public override void onColStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            BasicVar cur = Global.playerScript.motor.cur;

            //cur.vel.x = -cur.vel.x;
            //cur.vel = Vector3.Reflect(

            cur.vel.Scale(new Vector3(0.9f, 0.9f, 0.9f));

            Global.playerScript.motor.cur = cur;


            Debug.Log("Stay on " + collision.gameObject.name);
        }

      
    }
}
