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
        foreach (GameObject go in CheckPoints)
        {
            CheckForCollision Coc = go.GetComponent<CheckForCollision>();
            if (Coc.Collided == true && Coc.noMoreCheckNeed == false)
            {
                Coc.Collided = false;
                Coc.noMoreCheckNeed = true;
                Debug.Log("check point updated");
            }
        }

	}
}
