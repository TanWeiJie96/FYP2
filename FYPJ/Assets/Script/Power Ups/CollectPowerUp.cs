using UnityEngine;
using System.Collections;
using System;

public class CollectPowerUp : OnColReactTemplete
{

	public bool changeSpe = false;
	public bool changeInvis = false;
	public GameObject speedUp;
	public GameObject turnInvisible;
	public GameObject wall1;
	public float timer = 3.0f;

	public override void onTriEnter(Collider other)
    {	
        if (other.tag == "Speed")
        {	
			Global.playerScript.motor.amtOfAccel = 3;
			changeSpe = true;
			speedUp.SetActive(false);
        }

		if (other.tag == "Invis")
		{
			changeInvis = true;
			turnInvisible.SetActive(false);
		}
    }

	void Update()
	{
		if (changeSpe == true)
			timer -= Time.deltaTime;

		if (timer <= 0.0f)
		{
			Global.playerScript.motor.amtOfAccel = 1;
			timer = 0.0f;
			changeSpe = false;
		}

		if (changeInvis == true)
		{

		}
	}

//	public override void onTriExit(Collider other)
//	{
//		if (other.tag == "Speed")
//		{
//			changeSpe = false;
//			speedUp.SetActive(false);
//		}
//	}
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
