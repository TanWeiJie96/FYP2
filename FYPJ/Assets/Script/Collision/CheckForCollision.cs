using UnityEngine;
using System.Collections;

public class CheckForCollision : MonoBehaviour {
    public bool intoWinCon = false;     //if trigger added to wincondition

    public bool Collided = false;        //check if collided
    public bool noMoreCheckNeed = false; //stop checking wheter collide or not

    public int slot;
	// Use this for initialization
	void Start () {
        if (intoWinCon)
        {
            Global.gameEndSystem.winCondition.Add(Collided);
            slot = Global.gameEndSystem.winCondition.Count - 1;
        }
        else
        {
            slot = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (!noMoreCheckNeed && collider.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(Color.green.r, Color.green.g, Color.green.b, gameObject.GetComponent<Renderer>().material.color.a);
            Collided = true;
            Debug.Log("check point hit");
        }
    }
}
