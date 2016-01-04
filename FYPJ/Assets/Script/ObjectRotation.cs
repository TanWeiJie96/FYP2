using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour {

	public float rotatePerMin = 10.0f;

	void Update()
	{
		transform.Rotate (0, 6*rotatePerMin*Time.deltaTime, 0);
	}
}
