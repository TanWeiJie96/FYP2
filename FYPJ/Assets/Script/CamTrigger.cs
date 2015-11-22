using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamTrigger : MonoBehaviour {
    public List<GameObject> camTriggerList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for (int x = 0; x < camTriggerList.Count; ++x)
        {
            GameObject go = camTriggerList[x];
            CheckForCollision Coc = go.GetComponent<CheckForCollision>();
            if (Coc.Collided == true && Coc.noMoreCheckNeed == false)
            {
                Coc.noMoreCheckNeed = true;
                Coc.Collided = false;
                Global.playerScript._camRotAroundPlayer(true, -90);
            }
        }
	}
}
