using UnityEngine;

using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public float rotSpeed = 0.1f;
    public Vector3 axis = new Vector3(0, 1, 0);

	void Update(){
		
        /*
		if(Input.GetKey(KeyCode.E))
		{
			gameObject.transform.RotateAround(player.transform.position, axis, rotSpeed);
		}
         */
	}

    public void _rotAroundPlayer()
    {
        gameObject.transform.RotateAround(player.transform.position, axis, rotSpeed);
    }
}
