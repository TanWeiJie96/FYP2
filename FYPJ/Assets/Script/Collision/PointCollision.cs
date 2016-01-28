using UnityEngine;
using System.Collections;

public class PointCollision : OnColReactTemplete{
    public override void onTriEnter(Collider other)
    {
        //Debug.Log("WHY");
        if (other.gameObject.tag == "Point")
        {
            Global.scoreSystem._incrScore(other.gameObject.GetComponent<Points>().point);
            other.gameObject.SetActive(false);
        }
    }

}
