using UnityEngine;
using System.Collections;
using System;

public class CollectPowerUp : OnColReactTemplete
{

    public override void onTriEnterPower(Collider power)
    {
        if (power.tag == "Speed")
        {
            Debug.Log("Speed Power Up Got!");
        }
    }

    public override void onTriEnter(Collider other)
    {
   
    }

    public override void onTriExit(Collider other)
    {

    }


    public override void onColRec(Collision collision)
    {

    }
}
