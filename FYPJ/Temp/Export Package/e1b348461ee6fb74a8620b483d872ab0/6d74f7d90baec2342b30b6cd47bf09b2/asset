using UnityEngine;
using System.Collections;

public class GameController_CS : MonoBehaviour 
{
	// Public Variables
	public GameObject coin;

	// Private Variables
	private Rigidbody coinRb;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = 20f;

			Vector3 instancePosition = Camera.main.ScreenToWorldPoint(mousePosition);

			Instantiate (coin, instancePosition, Quaternion.identity);
		}
	}

}
