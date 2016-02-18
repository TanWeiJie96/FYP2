using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {
    //vehicle profile
    public VehicleProfile vehicleProfile;

    public Motor motor;
    public CameraMovement camMovement;
    
    public GameObject playerModel;
    public List<GameObject> modelChoice;

    public GameObject arrow;
    public bool arrowSpin = true;

    public CollisionReaction colReac;

    public float angleToGoTo = 0;

    //for dir of player
    public float radians = 0;

    // Use this for initialization
    void Awake () {
        motor.RbToMove = gameObject.GetComponent<Rigidbody>();
	}


	// Update is called once per frame
	void Update () {
        playerModel.transform.localPosition = Vector3.zero;
        //Debug.Log(playerModel.transform.localPosition);

        if(arrowSpin)
            arrow.transform.Rotate(new Vector3(0, vehicleProfile.arrowSpinVel, 0));

        if (angleToGoTo != gameObject.transform.eulerAngles.y)
        {
            float myAngle = Mathf.LerpAngle(playerModel.gameObject.transform.eulerAngles.y, angleToGoTo, Time.deltaTime);
            Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);
            playerModel.gameObject.transform.rotation = currentRotation;
        }

    }

    public void _createCar(VehicleProfile vt)
    {
        vehicleProfile = vt;

        GameObject newVehicle = Instantiate(vehicleProfile.vehicleModel);
        newVehicle.transform.parent = gameObject.transform;

        //reset all position after puting to the right parent
		newVehicle.transform.localRotation = Quaternion.identity;
        newVehicle.transform.localPosition = Vector3.zero;

        //init motor parameters
        motor.jumpStr = vehicleProfile.motorJumpStr;
        motor.jumpDec = vehicleProfile.motorJumpDec;
        motor.amtOfAccel = vehicleProfile.motorAmtAccel;


        playerModel = newVehicle;
        Debug.Log(playerModel.transform.localPosition);
    }

      
    public void _camRotAroundPlayer(bool cw)
    {
        camMovement._rotAroundPlayer(cw);
    }

    public void _camRotAroundPlayer(bool cw, float angle)
    {
        camMovement._rotAroundPlayer(cw, angle);
    }



    public void _motorGoTowardDir()
    {
       
		
        angleToGoTo = arrow.transform.eulerAngles.y;
        radians = arrow.transform.eulerAngles.y * (Mathf.PI / 180);

        arrowSpin = false;
        motor.slowDown = false;
        //Arrow.SetActive(false);
        //Debug.Log(arrow.transform.eulerAngles.y);
        Vector3 dir = new Vector3(Mathf.Sin(radians), 0, Mathf.Cos(radians));
        motor._movetowards(dir);
        //Debug.Log(dir);
    }

    public void _motorSlowsDowm()
    {
		
         arrowSpin = true;
         motor.slowDown = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("OnCollisionEnter");
        //colReac
        for (int i = 0; i < colReac.onColReacList.Capacity; ++i)
        {
            colReac.onColReacList[i].onColRec(collision);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        //Debug.Log("OnCollisionStay");
        //colReac
        for (int i = 0; i < colReac.onColReacList.Capacity; ++i)
        {
            colReac.onColReacList[i].onColStay(collision);
        }
    }


	void OnTriggerStay (Collider other)
	{
		//Debug.Log ("OnTriggerStay");
		for (int i = 0; i < colReac.onColReacList.Capacity; ++i)
		{
			//Debug.Log("checking list");
			colReac.onColReacList[i].onTriStay(other);
			
		}
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("On trigger enter");
        for (int i = 0; i < colReac.onColReacList.Capacity; ++i)
        {
            //Debug.Log("checking list");
            colReac.onColReacList[i].onTriEnter(other);
            
        }

        for (int j = 0; j < colReac.onColReacList.Capacity; ++j)
        {
            colReac.onColReacList[j].onTriEnterPower(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //  Debug.Log("OnTriggerExit");
        for (int i = 0; i < colReac.onColReacList.Capacity; ++i)
        {
            colReac.onColReacList[i].onTriExit(other);
        }
    }
}
