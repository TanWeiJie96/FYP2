using UnityEngine;
using System.Collections;

public class CheckForCollision : MonoBehaviour {
    public bool Collided = false;
    public bool noMoreCheckNeed = false; //stop checking wheter collide or not

    public int slot;
	// Use this for initialization
	void Start () {
        Global.gameEndSystem.winCondition.Add(Collided);
        slot = Global.gameEndSystem.winCondition.Count - 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (!noMoreCheckNeed && collider.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            Collided = true;
            Debug.Log("check point hit");
        }
    }
}
