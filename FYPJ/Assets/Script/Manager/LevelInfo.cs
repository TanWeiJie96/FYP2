using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {
    public int levelno;
    public float camStartAngle;
    public Vector3 startPosition;

    //track object and placement
    public GameObject track;
    public GameObject placedTrack;

    public Vector3 trackPosition;

    //Scoring and time init
    public float scorePerMin;
    public float timeToComplete;


    public IEnumerator _init()
    {
        Debug.Log("Level number:" + levelno);

        while (Global.playerScript == null || Global.uiManager == null)
        {

        }

       if (Global.playerScript != null)
       {
           
		    //Track init
           if (GameObject.Find(track.name))
           {
               track.SetActive(true);
           }
           else
           {
               placedTrack = GameObject.Instantiate(track);
           }

           //getting startpoint and the check points
           foreach (Transform child in placedTrack.transform){
                if (child.name == "startPosition"){
                    startPosition = child.transform.position;
                    //Debug.Log("Starting position" + startPosition);
                }
                if (child.name == "Checkpoints")
                {
                    Global.checkPointSystem.getCheckPoint(child.gameObject);
                   // Debug.Log("Checkpoints getto");
                }
           }
           //player init
            Global.playerScript._camRotAroundPlayer(true, camStartAngle) ;
            Global.playerScript.gameObject.transform.position = startPosition;
	        
           //UI info init
            Global.uiManager.timerClass.startingTime = timeToComplete;
            Global.uiManager.timerClass.timerAmount = timeToComplete;
            Global.uiManager._updateLevel(levelno.ToString());


       }
      
       yield return null;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
