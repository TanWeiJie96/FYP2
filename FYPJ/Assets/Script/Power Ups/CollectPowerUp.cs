using UnityEngine;
using System.Collections;
using System;

public class CollectPowerUp : OnColReactTemplete
{
	// Power-up Variables
	public bool changeSpe = false;
	public bool changeInvis = false;
	public bool changeBomb = false;

	// Power-up GameObjects
	public GameObject speedUp;
	public GameObject turnInvisible;
	public GameObject shootBomb;
	public GameObject wall1;
	private GameObject clone;

	// Bomb Variables
	public GameObject bombP;
	public float fireDelay;
	public float rateOfFire = 0.5f;
	public float speedOfBomb = 20.0f;

	//-------------------------------------------------

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

		if (other.tag == "Bomb")
		{
			changeBomb = true;
			shootBomb.SetActive(false);
		}
    }

	void Update()
	{
		if (changeSpe == true)
			timer -= Time.deltaTime;

		if (changeInvis == true)
		{
			wall1.GetComponent<Collider>().isTrigger = true;
		}

		if (timer <= 0.0f)
		{
			Global.playerScript.motor.amtOfAccel = 1;
			timer = 0.0f;
			changeSpe = false;
			changeInvis = false;
			wall1.GetComponent<Collider>().isTrigger = false;
		}

		if (Input.GetKey(KeyCode.B) )
		{
			clone = (GameObject)Instantiate(bombP, transform.position, transform.rotation);
			clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0,0,speedOfBomb));
			Physics.IgnoreCollision(clone.GetComponent<Collider>(), transform.root.GetComponent<Collider>());

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
