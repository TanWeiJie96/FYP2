using UnityEngine;
using System.Collections;
using System;

public class PlayerMagnetAction : MonoBehaviour{

    public float magnetStrength = 5.0f;
    public float magnetDirection = 0; // 1 = Attraction, -1 = Repel, 0 = Neutral
    public float distanceStrength = 10.0f; // Strength, based on the distance
    public bool looseMagnet = true; // able to leave the magnetInZone and move freely
    public bool north = false; // Differentiate Between Red and Blue Magnet 
	public bool changeMagnet = false; // Switch between magnets

    private Transform trans; // playerTransform
    private Rigidbody thisRd; // playerRigidBody
    public Transform magnetTrans; // magnetTransform 
	public bool magnetInZone;

    public GameObject magneticState;

	public Vector3 directionToMagnet;
		
    void Start()
    {
        trans = transform;
        //thisRd = Global.playerScript.gameObject.GetComponent<Rigidbody>();
		magneticState.GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0.1f);
    }


    void Update()
    {
        if (magnetInZone && magnetTrans!=null)
        {
            if (north == false)
            {
                directionToMagnet = magnetTrans.position - trans.position;
            }
            else if (north == true)
            {	
                directionToMagnet = trans.position - magnetTrans.position;
            }    

            float distance = Vector3.Distance(magnetTrans.position, trans.position);
            float magnetDistanceStr = (distanceStrength / distance) * magnetStrength;

            Global.playerScript.motor.RbToMove.AddForce(magnetDistanceStr * (directionToMagnet * magnetDirection), ForceMode.Force);

        }

        //// Neutral
        if (Input.GetKeyDown("z"))
        {
			changeMagnet = !changeMagnet;

			if (changeMagnet == false) // False == Attract
			{
				magnetDirection = 1;			
				magneticState.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 0.1f);
			}
			else if (changeMagnet == true) // True == Repel
			{
				magnetDirection = -1;
				magneticState.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 0.1f);
			}
            //Debug.Log("Change magnetic direction");
            //Debug.Log(magnetDirection);
        }

        //// Repel
        //if (Input.GetKeyDown("x"))
        //{
            //Debug.Log("Change magnetic direction");
            //Debug.Log(magnetDirection);
            //magnetDirection = -1;

            //magneticState.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 0.1f);
        //}

        //// Neutral
        if (Input.GetKeyDown("x"))
        {
            //Debug.Log("Change magnetic direction");
            //Debug.Log(magnetDirection);
            magnetDirection = 0;

            magneticState.GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0.1f);
        }
    }
}
