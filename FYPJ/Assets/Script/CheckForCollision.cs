using UnityEngine;
using System.Collections;

public class CheckForCollision : MonoBehaviour {
    public bool Collided = false;
    public bool noMoreCheckNeed = false; //stop checking wheter collide or not

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        if (!noMoreCheckNeed)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            Collided = true;
            Debug.Log("check point hit");
        }
    }
}
