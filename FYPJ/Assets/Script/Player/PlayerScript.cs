using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public Motor motor;
    public CameraMovement camMovement;
    public GameObject playerModel;

    public GameObject arrow;
    public bool arrowSpin = true;

    public CollisionReaction colReac;

    public float angleToGoTo = 0;

    public float radians = 0;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(arrowSpin)
	        arrow.transform.Rotate(new Vector3(0,3,0));

        if (angleToGoTo != gameObject.transform.eulerAngles.y)
        {
            float myAngle = Mathf.LerpAngle(playerModel.gameObject.transform.eulerAngles.y, angleToGoTo, Time.deltaTime);
            Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);
            playerModel.gameObject.transform.rotation = currentRotation;
        }

    }
      
    public void _camRotAroundPlayer(bool cw)
    {
        camMovement._rotAroundPlayer(cw);
    }

    public void _camRotAroundPlayer(bool cw , float angle)
    {
        camMovement._rotAroundPlayer(cw, angle);
    }



    public void _motorGoTowardDir()
    {
        angleToGoTo = arrow.transform.eulerAngles.y;
        radians = arrow.transform.eulerAngles.y * (Mathf.PI / 180);

        arrowSpin = false;
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

    public void OnCollisionEnter(Collision collision)
    {
        //colReac
        for (int i = 0; i < colReac.onColReacList.Capacity; ++i)
        {
            colReac.onColReacList[i].onColRec(collision);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < colReac.onColReacList.Capacity; ++i)
        {
            colReac.onColReacList[i].onTriEnter(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < colReac.onColReacList.Capacity; ++i)
        {
            colReac.onColReacList[i].onTriExit(other);
        }
    }
}
