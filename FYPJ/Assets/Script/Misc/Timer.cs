using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class Timer : MonoBehaviour {
    public float startingTime;
    public float timerAmount;

    public bool stopTime;
    public bool countdown = true;

    //for losing condition
    public bool loseToTime = false; 
    public int slot;



	// Use this for initialization
	void Start () {
       // timerAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (!stopTime)
        {
            if (timerAmount > 0)
            {
                if (countdown)
                {
                    timerAmount -= Time.deltaTime;
                }
                else
                {
                    timerAmount += Time.deltaTime;
                }
            }
            else
            {
                timerAmount = 0;
                stopTime = true;

                //for losing condition
                loseToTime = true;

                Global.gameEndSystem.loseCondition[slot] = loseToTime; 
                Global.gameEndSystem.needsCheckForGameEnd = true;
            }
        }
	}
}
