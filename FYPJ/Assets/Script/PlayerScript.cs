using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public Motor motor;
    public CameraMovement camMovement;

    public GameObject Arrow;
    public bool arrowSpin = true;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(arrowSpin)
	        Arrow.transform.Rotate(new Vector3(0,3,0));
      

       
    
	}

    public void _camRotAroundPlayer()
    {
        camMovement._rotAroundPlayer();
    }

    public void _motorGoTowardDir()
    {
        float radians = Arrow.transform.eulerAngles.y * (Mathf.PI / 180);

        arrowSpin = false;
        //Arrow.SetActive(false);
        Debug.Log(Arrow.transform.eulerAngles.y);
        Vector3 dir = new Vector3(Mathf.Sin(radians), 0, Mathf.Cos(radians));
        motor._movetowards(dir);
        Debug.Log(dir);
    }

    public void _motorSlowsDowm()
    {
         arrowSpin = true;
         motor.slowDown = true;
    }
}
