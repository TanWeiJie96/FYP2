using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	public Motor motor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.F))
        {
            Global.playerScript._camRotAroundPlayer(true);
        }
        if (Input.GetKey(KeyCode.G))
        {
            Global.playerScript._camRotAroundPlayer(false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Global.playerScript._motorGoTowardDir();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Global.playerScript._motorSlowsDowm();
			motor.inc.dir = Vector3.zero;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            Global.levelSystem.nextLevel();
        }

		// Show Instructions
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			//Global.playerScript.show_I = !Global.playerScript.show_I;
			if (Global.playerScript.show_I == false)
			{
				Global.playerScript.showInstructions.SetActive(true);
				Global.playerScript.showBackgroundColor.SetActive(true);
				Time.timeScale = 0;
			}
			else 
			{
				Time.timeScale = 1;
				Global.playerScript.showInstructions.SetActive(false);
				Global.playerScript.showBackgroundColor.SetActive(false);
			}
		}
	}
}
