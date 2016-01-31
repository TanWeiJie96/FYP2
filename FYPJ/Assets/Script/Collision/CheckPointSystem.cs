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
            child.gameObject.GetComponent<CheckForCollision>()._initCol();
		}
	
	}
}
