using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class CheckPointSystem : MonoBehaviour {
    public List<GameObject> CheckPoints;

	// Use this for initialization
	void Start () {
		//getCheckPoint();
	}

    public void getCheckPoint()
    {
        GameObject CP = GameObject.Find("Checkpoints");
        //Debug.Log("getting check point");
        if (CP)
        {
            Debug.Log("check points up");
            foreach (Transform child in CP.transform)
            {
                CheckPoints.Add(child.gameObject);
            }
        }
    }


	public void getCheckPoint(GameObject CP)
	{
		//GameObject CP = GameObject.Find("Checkpoints");
		//Debug.Log("getting check point");

		//Debug.Log("check points up");
		foreach (Transform child in CP.transform)
		{
            CheckPoints.Add(child.gameObject);
            child.gameObject.GetComponent<CheckForCollision>()._init();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
        /*
        for (int x = 0; x < CheckPoints.Count; ++x)
        {
            GameObject go = CheckPoints[x];
            //Debug.Log("hi");
			if(go != null)
			{
                //Debug.Log("bye");
	            CheckForCollision Coc = go.GetComponent<CheckForCollision>();
                
	            if (Coc.Collided == true && Coc.noMoreCheckNeed == false)
	            {
	                Global.gameEndSystem.winCondition[Coc.slot] = Coc.Collided;
	                Global.gameEndSystem.needsCheckForGameEnd = true;
	                Coc.noMoreCheckNeed = true;
	                Coc.Collided = false;
	                Debug.Log("check point updated");

                    Debug.Log(CheckPoints.Count);
	            }
                
			}
        }
         */ 

	}
}
