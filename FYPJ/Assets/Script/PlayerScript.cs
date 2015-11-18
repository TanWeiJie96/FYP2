using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public Motor motor;
    public CameraMovement camMovement;

    public GameObject arrow;
    public bool arrowSpin = true;

    public CollisionReaction colReac;

    //Magnets//
    public float magnetStrength = 5.0f;
    public float magnetDirection = 0; // 1 = Attraction, -1 = Repel, 0 = Neutral
    public float distanceStrength = 10.0f; // Strength, based on the distance
    public bool looseMagnet = true; // able to leave the magnetInZone and move freely

    private Transform trans; // player's Transform
    private Transform magnetTrans; // magnets's Transform
    private Rigidbody thisRd; // player's Rigidbody
    private bool magnetInZone; // within magnet's zone

    public GameObject magneticState;
    //Magnets//

    // Use this for initialization
    void Start () {

        //Magnet//
        trans = transform;
        thisRd = trans.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(arrowSpin)
	        arrow.transform.Rotate(new Vector3(0,3,0));

        //Magnet//
        if (magnetInZone)
        {
            Vector3 directionToMagnet = magnetTrans.position - trans.position;
            float distance = Vector3.Distance(magnetTrans.position, trans.position);
            float magnetDistanceStr = (distanceStrength / distance) * magnetStrength;

            thisRd.AddForce(magnetDistanceStr * (directionToMagnet * magnetDirection), ForceMode.Force);

        }

        //// Neutral
        if ( Input.GetKeyDown("z"))
        {
            Debug.Log("Change magnetic direction");
            Debug.Log(magnetDirection);
            magnetDirection = 0;

            //Color neutral = magneticState.GetComponent<Renderer>().material.color = Color.white;
            //neutral.a =0.023f;

            magneticState.GetComponent<Renderer>().material.color = new Color(255,255,255, 0.1f); 
            //magneticState.GetComponent<Renderer>().material.color = ;

        }

        //// Repel
        if (Input.GetKeyDown("x"))
        {
            Debug.Log("Change magnetic direction");
            Debug.Log(magnetDirection);
            magnetDirection = -1;

            //Color Repel = magneticState.GetComponent<Renderer>().material.color = Color.blue;
            //Repel.a = 0.1f;

            magneticState.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 0.1f);
        }

        //// Attract
        if (Input.GetKeyDown("c"))
        {
            Debug.Log("Change magnetic direction");
            Debug.Log(magnetDirection);
            magnetDirection = 1 ;

           // Color attract = magneticState.GetComponent<Renderer>().material.color = Color.red;
            //attract.a = 0.1f;

            magneticState.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 0.1f);
        }


    }
      
    public void _camRotAroundPlayer()
    {
        camMovement._rotAroundPlayer();
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

    //Magnet//
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Magnet")
        {
            Debug.Log("Magnet Detected!");
            magnetTrans = other.transform;
            magnetInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Magnet" && looseMagnet == true)
        {
            Debug.Log("Magnet Exit!");
            magnetInZone = false;
        }
    }
}
