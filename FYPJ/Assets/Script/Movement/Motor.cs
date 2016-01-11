using UnityEngine;
using System.Collections;


public class Motor : MonoBehaviour {
	//basic needs
	public Transform TransToMove;

	public CollectPowerUp cpp;

	public float amtOfAccel = 1.0f; //ammount of time accelerated 

	public BasicVar cur;
	public BasicVar cons;
	public BasicVar inc;

	//for deceleration when player has not select the direction
	public bool slowDown = false;

    public bool stopMoving = false;

	// Use this for initialization
	void Start () {
		/*
		if (cur.speed < cons.speed)
			cur.speed = cons.speed;
		if(cur.dir.
*/
		//cur.magnitude = cons.magnitude;
	}
	
	// Update is called once per frame
	void Update () {

		//_keyInput ();
        if(!stopMoving)
		    _relation ();
		else
		{
			cur.vel = Vector3.zero;
		}

	}

    public void _stopMoving(bool stopMov)
    {
        stopMoving = stopMov;
        cur.vel = Vector3.zero;
    }

    public void _movetowards(Vector3 dir)
    {
        inc.dir = dir;	
        //inc.dir.Scale(new Vector3(cons.accel.x, 0, cons.accel.x));
    }

	void _keyInput()
	{

		//Debug.Log("direction input");
		if (Input.GetKey (KeyCode.A)) {
			//Debug.Log("direction w");
			inc.dir = new Vector3 (-cons.accel.x, 0, 0);
			slowDown = false;
		}
		if (Input.GetKey (KeyCode.D)) {
			//Debug.Log("direction s");
			inc.dir = new Vector3 (cons.accel.x, 0, 0);
			slowDown = false;
		} 
		if (Input.GetKey (KeyCode.W)) {
			//Debug.Log("direction a");
			inc.dir = new Vector3 (0, 0, cons.accel.x);
			slowDown = false;
		} 
		if (Input.GetKey (KeyCode.S)) {
			//Debug.Log("direction d");
			inc.dir = new Vector3 (0, 0, -cons.accel.x);
			slowDown = false;
		} 

		if(Input.anyKey == false){
			slowDown = true;
		}
	}

	void _relation()
	{
		if (inc.dir != Vector3.zero) {
			for (int i = 0; i < amtOfAccel; ++i)
			{
				//Debug.Log ("direction update");
				inc.vel = inc.dir * inc.speed;
				cur.vel += inc.vel;
				
			}
			inc.dir = Vector3.zero;
		}


        if (slowDown && cur.vel.magnitude > 0.01)
        {
			//Debug.Log ("cur magnitude:" + cur.magnitude.magnitude);
            cur.vel.Scale(new Vector3(0.99f, 0.99f, 0.99f));
			//Debug.Log ("slowing down...");
		} else {
			slowDown = false;
		}
		//Move the object according to current magnitude
        TransToMove.position += cur.vel;

	}

	void OnCollisionEnter(Collision collision){


	}
    /*
    public void _collisionResult(Collision collision)
    {
        if (collision.gameObject.tag == "Slope" || collision.gameObject.tag == "Floor")
        {
            //gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);
            Debug.Log("No Direction change");
        }
        if (collision.gameObject.tag == "Wall")
        {
            cur.vel.x = -cur.vel.x;
            cur.vel.Scale(new Vector3(0.1f, 0.1f, 0.1f));
            Debug.Log("Hit wall");
        }
    }
     */
}
