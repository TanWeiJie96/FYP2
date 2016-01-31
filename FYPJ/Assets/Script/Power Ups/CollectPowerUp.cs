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
	private Image invisImage; 
	private Image bombImage; 

	// Power-up GameObjects
	public GameObject speedUp;
	public GameObject speedUpOnMap;
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
		speedUpOnMap = GameObject.Find("charge");
		speedUp = speedUpOnMap;

		startTime = defaultTime;

		//if (boostImage)
		boostImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

		//if (invisImage)
		//	invisImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

		//if (bombImage)
		//	bombImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
	}

	public override void onTriEnterPower(Collider other)
    {	
        if (other.tag == "Speed")
        {	
			Debug.Log("Got Speed!");
			//speedUp.SetActive(false);
            other.gameObject.SetActive(false);
			gotSpeedUp = true;
			boostImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

//		if (other.tag == "Invis")
//		{
//			gotInvis = true;
//			//turnInvisible.SetActive(false);
//			invisImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
//		}		

//		if (other.tag == "Bomb")
//		{
//			gotBomb = true;
//			//shootBomb.SetActive(false);
//			bombImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
//		}
    }


	void SpeedPowerUp()
	{
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
					
					Global.playerScript.motor.amtOfAccel = 5.0f;
					
					startTime = defaultTime;
				}
				else 
				{
					startTime -= Time.deltaTime;
					
					Global.playerScript.motor.amtOfAccel = 25.0f;
				}
			}
			
			
		}
	}

	void InvisPowerUp()
	{
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
	}

	void BombPowerUp()
	{
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
	}

	void Update()
	{	
		SpeedPowerUp();
		//InvisPowerUp();
		//BombPowerUp ();

		if (startTime <= 0.0f)
		{
			wall1.GetComponent<Collider>().isTrigger = false;
			startTime = 0.0f;
			speedUp.SetActive(true);
			
		}
	}
}