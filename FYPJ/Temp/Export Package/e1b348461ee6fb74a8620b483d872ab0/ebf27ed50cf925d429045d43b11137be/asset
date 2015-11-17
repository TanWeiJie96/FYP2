using UnityEngine;
using System.Collections;

public class MagnetChangeDir_CS : MonoBehaviour 
{
	// Public Variables
	public Vector3 magnetDirection;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Magnet")
			other.GetComponent<MagnetActions_CS>().newPosition = magnetDirection;
	}

}
