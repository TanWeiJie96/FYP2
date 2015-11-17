using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class CheckPointSystem : MonoBehaviour {
    public List<GameObject> CheckPoints;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for (int x = 0; x < CheckPoints.Count; ++x)
        {
            GameObject go = CheckPoints[x];
            CheckForCollision Coc = go.GetComponent<CheckForCollision>();
            if (Coc.Collided == true && Coc.noMoreCheckNeed == false)
            {
                Global.gameEndSystem.winCondition[Coc.slot] = Coc.Collided;
                Global.gameEndSystem.needsCheckForGameEnd = true;
                Coc.noMoreCheckNeed = true;
                Coc.Collided = false;
                Debug.Log("check point updated");
            }
        }

	}
}
