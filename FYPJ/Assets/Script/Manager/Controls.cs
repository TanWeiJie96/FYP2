using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	public Motor motor;
    public bool paused;
	
	// Update is called once per frame
	void Update () {
        //button to remove when game is paused
        if (!paused)
        {
            if (InputSetUp.instance.characterActions.Accelerate.IsPressed)
            {
				//SoundManager.instance._playSingle(2);
				//SoundManager.instance.efxSource1.Play();
				
                Global.playerScript._motorGoTowardDir();
            }
            if (InputSetUp.instance.characterActions.Accelerate.WasReleased)
            {
				//SoundManager.instance.efxSource1.Stop();
				//SoundManager.instance._stopSingle(2);
				
				
                Global.playerScript._motorSlowsDowm();
                motor.inc.dir = Vector3.zero;
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                Global.levelSystem.nextLevel();
            }

            //for jumping
            if (Global.playerScript.motor.jumping == false)
            {
                if (InputSetUp.instance.characterActions.Jump.WasPressed)
                {
                   // Debug.Log("ok....");
                    Global.playerScript.motor._jump();
                }
            }

            // Show Instructions
    
        }
        else
        {

        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {

            Global.uiManager._togglePauseUI();
        }
	}
}
