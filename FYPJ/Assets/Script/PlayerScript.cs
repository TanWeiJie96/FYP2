using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public Motor motor;
    public CameraMovement camMovement;

    public GameObject arrow;
    public bool arrowSpin = true;

    public CollisionReaction colReac;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(arrowSpin)
	        arrow.transform.Rotate(new Vector3(0,3,0));

    }
      
    public void _camRotAroundPlayer(bool cw)
    {
        camMovement._rotAroundPlayer(cw);
    }

    public void _camRotAroundPlayer(bool cw , float angle)
    {
        camMovement._rotAroundPlayer(cw,angle);
    }



    public void _motorGoTowardDir()
    {
        float radians = arrow.transform.eulerAngles.y * (Mathf.PI / 180);

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
}
