using UnityEngine;
using System.Collections;

public class CoinActions_CS : MonoBehaviour 
{
	// Script for managing coin movements.

	// Public Variables
	public float magnetStrength = 5f;
	public float distanceStretch = 10f;	// Strength, based on the distance
	public int magnetDirection = 1;	// 1 = attact, -1 = repel
	public bool looseMagnet = true;

	// Private Variables
	private Transform trans;
	private Rigidbody thisRd;
	private Transform magnetTrans;
	private bool magnetInZone;

	void Awake()
	{
		trans = transform;
		thisRd = trans.GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (magnetInZone)
		{
			Vector3 directionToMagnet = magnetTrans.position - trans.position;
			float distance = Vector3.Distance(magnetTrans.position, trans.position);
			float magnetDistanceStr = (distanceStretch / distance) * magnetStrength;

			thisRd.AddForce(magnetDistanceStr * (directionToMagnet * magnetDirection), ForceMode.Force);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Magnet")
		{
			magnetTrans = other.transform;
			magnetInZone = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Magnet" && looseMagnet)
		{
			magnetInZone = false;
		}
	}
}






