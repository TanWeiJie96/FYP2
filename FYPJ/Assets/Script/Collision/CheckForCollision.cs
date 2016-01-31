using UnityEngine;
using System.Collections;

public class CheckForCollision : MonoBehaviour {
    public bool intoWinCon = true;     //if you want the trigger added to wincondition
    public bool intoLoseCon = false;    //if you want the trigger added to losecondition

    public bool Collided = false;        //check if collided

    public bool resetNeeded = false;
    public bool noMoreCheckNeed = false; //stop checking wheter collide or not

    public int slot;
	// Use this for initialization
	public void _initCol () {
       // Debug.Log("Shit is real");

        if (intoWinCon)
        {
            Global.gameEndSystem.winCondition.Add(Collided);
            slot = Global.gameEndSystem.winCondition.Count - 1;
        }
            /*
        else
        {
            slot = 0;
        }
        */
        if (intoLoseCon)
        {
            Global.gameEndSystem.loseCondition.Add(Collided);
            slot = Global.gameEndSystem.loseCondition.Count - 1;
        }

	}
	

    void OnTriggerEnter(Collider collider)
    {
        if (!noMoreCheckNeed && collider.gameObject.tag == "Player")
        {
            //gameObject.GetComponent<Renderer>().material.color = new Color(Color.green.r, Color.green.g, Color.green.b, gameObject.GetComponent<Renderer>().material.color.a);
            Collided = true;
            if (intoWinCon)
            {
                Global.gameEndSystem.winCondition[slot] = Collided;
                Global.gameEndSystem.needsCheckForGameEnd = true;
                if (!resetNeeded)
                {
                    noMoreCheckNeed = true;
                }
                Collided = false;
            }
            else if (intoLoseCon)
            {
                Global.gameEndSystem.loseCondition[slot] = Collided;
                Global.gameEndSystem.needsCheckForGameEnd = true;
                if (!resetNeeded)
                {
                    noMoreCheckNeed = true;
                }
                Collided = false;
            }

            Debug.Log("check point hit");
        }
    }
}
