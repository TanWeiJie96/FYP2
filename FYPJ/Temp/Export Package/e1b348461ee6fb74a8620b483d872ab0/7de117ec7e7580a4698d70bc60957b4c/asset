using UnityEngine;
using System.Collections;

public class MagnetActions_CS : MonoBehaviour
{
	// Script for managing Magnet movement

	// Public Variables
	public Vector3 newPosition;	// The target position

	// Private Variables
	private Transform trans;	// Will hold this.transform.

	void Awake()
	{
		trans = transform;
	}

	void Update()
	{
		trans.position = Vector3.Lerp (trans.position, newPosition, Time.deltaTime * 1.5f);

		if (Mathf.Abs(newPosition.x - trans.position.x) < 0.05)
			trans.position = newPosition;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Coin")
			Destroy(other.gameObject);
	}

}





