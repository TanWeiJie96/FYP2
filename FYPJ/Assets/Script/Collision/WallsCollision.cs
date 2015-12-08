using UnityEngine;
using System.Collections;
using System;

public class WallsCollision : OnColReactTemplete { 
    
    public override void onColRec(Collision collision)
    {
        //Global.playerScript.motor._collisionResult(collision);
        if (collision.gameObject.tag == "Slope" || collision.gameObject.tag == "Floor")
        {
            //gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);
            Debug.Log("No Direction change");
        }
        if (collision.gameObject.tag == "Wall")
        {
            BasicVar cur = Global.playerScript.motor.cur;

            cur.vel.x = -cur.vel.x;
            cur.vel.Scale(new Vector3(0.1f, 0.1f, 0.1f));

            Global.playerScript.motor.cur = cur;


            Debug.Log("Hit wall");
        }
    }

    public override void onTriEnter(Collider other)
    {
        
    }

    public override void onTriExit(Collider other)
    {

    }

    public override void onTriEnterPower(Collider other)
    {

    }
}
