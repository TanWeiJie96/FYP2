using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSystem : MonoBehaviour {
    public List<LevelInfo> levelList;
    public int curLevel = 1;


	// Use this for initialization
	void Start () {
        if (levelList.Count > 0)
            levelList[curLevel - 1]._init();
        else
            Debug.Log("No level to init");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
