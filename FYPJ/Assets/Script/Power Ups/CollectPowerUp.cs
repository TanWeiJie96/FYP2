using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectPowerUp : OnColReactTemplete
{
	// Power-up Variables
	public bool gotSpeedUp = false;
	public bool gotInvis = false;
	public bool gotBomb = false;

	public bool useSpeedUp = false;
	public bool useInvis = false;
	public bool useBomb = false;

	// Power-up Image
	public Image boostImage; 
	public Image invisImage; 
	public Image bombImage; 

	// Power-up GameObjects
	public GameObject speedUp;
	public GameObject turnInvisible;
	public GameObject shootBomb;
	public GameObject wall1;
	private GameObject clone;

	// Bomb Variables
	public GameObject bombP;
	public float fireDelay;
	public float rateOfFire = 0.5f;
	public float speedOfBomb = 20.0f;

	//-------------------------------------------------

	public float startTime = 4.5f;

	void Start()
	{
		boostImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
		invisImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
		bombImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
	}

	public override void onTriEnterPower(Collider other)
    {	
        if (other.tag == "Speed")
        {	
			gotSpeedUp = true;
			boostImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			speedUp.SetActive(false);
			
        }

		if (other.tag == "Invis")
		{
			gotInvis = true;
			turnInvisible.SetActive(false);
			invisImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
		

		if (other.tag == "Bomb")
		{
			gotBomb = true;
			shootBomb.SetActive(false);
			bombImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
    }

	void Update()
	{
		Debug.Log ("Timer: " + startTime); 
		if (gotSpeedUp == true)
		{
			if (Input.GetKeyUp(KeyCode.A))
			{	
				useSpeedUp = true;
				boostImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
			}
			
			if (useSpeedUp == true)
			{
				startTime -= Time.deltaTime;
				
				Global.playerScript.motor.amtOfAccel = 3.0f;

				if (startTime <= 0.0f)
				{
					gotSpeedUp = false;
					useSpeedUp = false;
				}
			}
		}
		//-----------------------------------------------------------------------------

		if (gotInvis == true)
		{
			if (Input.GetKeyDown(KeyCode.S))
			{
				useInvis = true;
				invisImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
			}
			
			if (useInvis == true)
			{
				startTime -= Time.deltaTime;
				
				wall1.GetComponent<Collider>().isTrigger = true;

				if (startTime <= 0.0f)
				{
					gotInvis = false;
					useInvis = false;
				}
			}
		}
		//-----------------------------------------------------------------------------

		if (gotBomb == true)
		{
			if (Input.GetKeyDown (KeyCode.D))
			{
				//useBomb = true;
				bombImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

				///startTime -= Time.deltaTime;

				//if (useBomb == true)
				//{

					clone = (GameObject)Instantiate(bombP, transform.position, transform.rotation);
					clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0,0,speedOfBomb));
					//Physics.IgnoreCollision(clone.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
					

				//}
					
//				if (startTime <= 0.0f)
//				{
//						gotBomb = false;
//						useBomb = false;
//				}

			}
		}
		//-----------------------------------------------------------------------------
		
		if (startTime <= 0.0f)
		{
			Global.playerScript.motor.amtOfAccel = 1.0f;
			//gotSpeedUp = false;
			//gotInvis = false;
			//gotBomb = false;
			//useSpeedUp = false;
			//useInvis = false;
			//useBomb = false;
			wall1.GetComponent<Collider>().isTrigger = false;
			startTime = 0.0f;
		}





	}
}