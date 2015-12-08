using UnityEngine;
using System.Collections;
using System;

public class CollectPowerUp : OnColReactTemplete
{

    public override void onTriEnterPower(Collider other)
    {
        Debug.Log("wtf");
        if (other.tag == "Speed")
        {
            Debug.Log("Speed Power Up Got!");
        }
    }

}

//public class CollectPowerUp : MonoBehaviour {

//    public void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "Speed")
//        {
//            Debug.Log("Speed Power Up Got!");
//        }
//    }
//}
