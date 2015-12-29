using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {
    public int levelno;
    public float camStartAngle;
    public Vector3 startPosition;

    public GameObject track;

    public IEnumerator _init()
    {
        while (Global.playerScript == null)
        {
            Debug.Log("Loading player script.....");
        }
        Debug.Log("Player script is up~!");

       if (Global.playerScript != null)
       {
            Global.playerScript._camRotAroundPlayer(true, camStartAngle) ;
            Global.playerScript.gameObject.transform.position = startPosition;

            if (GameObject.Find(track.name))
                track.SetActive(true);
            else
                GameObject.Instantiate(track);
            
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
