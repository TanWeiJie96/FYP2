using UnityEngine;
using System.Collections;


public class Motor : MonoBehaviour {
	//basic needs
	public Transform TransToMove;
    public Rigidbody RbToMove;

	public CollectPowerUp cpp;

	public float amtOfAccel = 1.0f; //ammount of time accelerated 
    public float maxMag = 50.0f;    //maximum speed it can go to
    public float jumpStr = 500f;    //strength in jumping
    public float jumpDec = 0.8f;    //speed in decreasing of altitudue

	public BasicVar cur;
	public BasicVar cons;
	public BasicVar inc;

	//for deceleration when player has not select the direction
	public bool slowDown = false;
    public bool stopMoving = false;
    public bool jumping = false;


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
	void FixedUpdate () {

		//_keyInput ();
        if (!stopMoving)
        {
            _relation();
        }
        else
        {
            //cur.vel = Vector3.zero;
            //RbToMove.AddForce(cur.vel); 
            RbToMove.velocity = Vector3.zero;
            RbToMove.angularVelocity = Vector3.zero;
        }

	}
    /*
    public void _stopMoving(bool stopMov)
    {
        stopMoving = stopMov;
        //cur.vel = Vector3.zero;
        //RbToMove.AddForce(cur.vel);

        RbToMove.velocity = Vector3.zero;
        RbToMove.angularVelocity = Vector3.zero; 
    }
    */
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
        //Debug.Log("Rigid body force: " + RbToMove.GetComponent<ConstantForce>().force);
        if (cur.vel.magnitude < maxMag)
        {
            //Debug.Log("cur magnitude:" + cur.vel.magnitude);
            if (inc.dir != Vector3.zero)
            {
                for (int i = 0; i < amtOfAccel; ++i)
                {
                    //Debug.Log ("direction update");
                    inc.vel = inc.dir * inc.speed;
                    cur.vel += inc.vel;

                }
                inc.dir = Vector3.zero;
            }
        }
        else
        {
            //Debug.Log("max magnitude reached: " + cur.vel.magnitude);
        }

        if (slowDown && cur.vel.magnitude > 0.01)
        {
            //Debug.Log ("cur magnitude:" + cur.magnitude.magnitude);
            cur.vel.Scale(new Vector3(0.9f, 1.0f, 0.9f));
            //Debug.Log("slowing down...");
        }
        else
        {
            slowDown = false;
        }
        if (jumping == true)
        {
            if (cur.vel.y < 0.0001)
            {
                jumping = false;
            }
            else
            {
                cur.vel.Scale(new Vector3(1.0f, jumpDec, 1.0f));
            }
        }
		//Move the object according to current magnitude
        //TransToMove.position += cur.vel;
        RbToMove.AddForce(cur.vel); 
	}

    public void _jump()
    {
        Global.playerScript.motor.cur.vel += new Vector3(0.0f, jumpStr, 0.0f);
        Global.playerScript.motor._movetowards(new Vector3(0.0f, 1.0f, 0.0f));
        jumping = true;
    }
}
