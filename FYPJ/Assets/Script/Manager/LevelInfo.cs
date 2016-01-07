using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {
    public int levelno;
    public float camStartAngle;
    public Vector3 startPosition;

    public GameObject track;

    public GameObject placedTrack;
    public Vector3 trackPosition;


    public IEnumerator _init()
    {
        Debug.Log("Level number:" + levelno);

        while (Global.playerScript == null)
        {

        }

       if (Global.playerScript != null)
       {		
			//Debug.Log ("zzz");
           if (GameObject.Find(track.name))
           {
               track.SetActive(true);
           }
           else
           {
               placedTrack = GameObject.Instantiate(track);
           }

           foreach (Transform child in placedTrack.transform){
                if (child.name == "startPosition"){
                    startPosition = child.transform.position;
                    Debug.Log("Starting position" + startPosition);
                }
           }

            Global.playerScript._camRotAroundPlayer(true, camStartAngle) ;
            Global.playerScript.gameObject.transform.position = startPosition;
			/*
            if (GameObject.Find(track.name))
            {
                track.SetActive(true);
            }
            else
            {
                placedTrack = GameObject.Instantiate(track);
            }

            track.transform.position = trackPosition;
			*/
       }
       Global.checkPointSystem.getCheckPoint();
       yield return null;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
