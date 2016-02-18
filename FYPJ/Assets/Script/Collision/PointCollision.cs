using UnityEngine;
using System.Collections;
using System;

public class PointCollision : OnColReactTemplete{
    public override void onTriEnter(Collider other)
    {
        //Debug.Log("WHY");
        if (other.gameObject.tag == "Point")
        {
            Global.scoreSystem._incrScore(other.gameObject.GetComponent<Points>().point);
			SoundManager.instance._playSingle(3);
            other.gameObject.SetActive(false);
        }
    }

}
