using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSystem : MonoBehaviour {
    public List<LevelInfo> levelList;
    public LevelInfo curLevel;


	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void _initLevel()
    {
        if (levelList.Count > 0)
        {
            StartCoroutine(curLevel._init());
        }
        else
        {
            Debug.Log("No level to init");
        }
    }

}
