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
	public float defaultTime = 4.5f;
	public float startTime;

	void Start()
	{
		startTime = defaultTime;
		if (boostImage)
		boostImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
		if (invisImage)
		invisImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
		if (bombImage)
		bombImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
	}

	public override void onTriEnterPower(Collider other)
    {	
		Debug.Log (other.tag);
        if (other.tag == "Speed")
        {	
			gotSpeedUp = true;
			boostImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

		if (other.tag == "Invis")
		{
			gotInvis = true;
			//turnInvisible.SetActive(false);
			invisImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
		

		if (other.tag == "Bomb")
		{
			gotBomb = true;
			//shootBomb.SetActive(false);
			bombImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
    }

	void Update()
	{	
		Debug.Log("gotSpeedUp: " + gotSpeedUp);
		Debug.Log("useSpeedUp: " + useSpeedUp);

		if (gotSpeedUp == true)
		{
			if (Input.GetKeyUp(KeyCode.A))
			{	
				useSpeedUp = true;
				boostImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
			}

			if (useSpeedUp == true)
			{
				if (startTime <= 0.0f)
				{
					gotSpeedUp = false;
					useSpeedUp = false;
					
					Global.playerScript.motor.amtOfAccel = 1.0f;

					startTime = defaultTime;
				}
				else 
				{
					startTime -= Time.deltaTime;
					
					Global.playerScript.motor.amtOfAccel = 3.0f;
				}
			}


		}
		//-----------------------------------------------------------------------------

		if (gotInvis == true)
		{
			Debug.Log ("Active:" + speedUp.activeSelf);
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
			wall1.GetComponent<Collider>().isTrigger = false;
			startTime = 0.0f;
		}





	}
}