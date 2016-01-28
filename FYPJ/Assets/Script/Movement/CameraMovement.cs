using UnityEngine;

using System.Collections;

public class CameraMovement : MonoBehaviour {

	//public GameObject player;
	public float rotSpeed = 0.1f;
    public Vector3 axis = new Vector3(0, 1, 0);

    void Start()
    {
        //player.GetComponent<PlayerScript>().camMovement = this;
        //Global.playerScript.camMovement = this;
    }

	void Update(){
		
        /*
		if(Input.GetKey(KeyCode.E))
		{
			gameObject.transform.RotateAround(player.transform.position, axis, rotSpeed);
		}
         */
	}

    public void _rotAroundPlayer(bool clockwise)
    {
        if (clockwise)
        {
            gameObject.transform.RotateAround(Global.playerScript.gameObject.transform.position, axis, rotSpeed);
        }
        else
        {
            gameObject.transform.RotateAround(Global.playerScript.gameObject.transform.position, axis, -rotSpeed);
        }
    }

    public void _rotAroundPlayer(bool clockwise, float angle)
    {
        if (clockwise)
        {
            gameObject.transform.RotateAround(Global.playerScript.gameObject.transform.position, axis, angle);
        }
        else
        {
            gameObject.transform.RotateAround(Global.playerScript.gameObject.transform.position, axis, angle);
        }
    }

}


