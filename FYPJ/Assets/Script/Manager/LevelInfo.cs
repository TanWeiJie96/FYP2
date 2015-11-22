using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {
    public int levelno;
    public float camStartAngle;
    public Vector3 startPosition;

    public void _init()
    {
        Global.playerScript._camRotAroundPlayer(true, camStartAngle) ;
        Global.playerScript.gameObject.transform.position = startPosition;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
