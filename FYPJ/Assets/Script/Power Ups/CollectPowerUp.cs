using UnityEngine;
using System.Collections;
using System;

public class CollectPowerUp : OnColReactTemplete
{
	public bool changeSpe = false;
	public GameObject speedUp;
	public float timer = 1.0f;

	public override void onTriEnter(Collider other)
    {	
        if (other.tag == "Speed")
        {	
			changeSpe = true;
			speedUp.SetActive(false);

			Debug.Log ("Timer: " + timer);
        }
    }

	void Update()
	{
		if (changeSpe == true)
			timer -= Time.deltaTime;

		if (timer <= 0.0f)
		{
			timer = 0.0f;
			changeSpe = false;
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
