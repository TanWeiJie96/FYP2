using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

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
        }
	}
}
