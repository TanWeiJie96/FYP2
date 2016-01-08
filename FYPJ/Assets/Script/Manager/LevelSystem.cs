using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSystem : MonoBehaviour {
    public List<LevelInfo> levelList;
    
    public LevelInfo curLevel;

    public int index;

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
            StartCoroutine( curLevel._init() );
			
        }
        else
        {
            Debug.Log("No level to init");
        }
    }

    public IEnumerator beforeNextLevel()
    {
        Global.controls.paused = true;
        yield return new WaitForSeconds(5);
        Global.controls.paused = false;
        nextLevel();

        yield return null;
    }


    public void nextLevel()
    {
		Global.checkPointSystem.CheckPoints.Clear();
		Global.gameEndSystem.winCondition.Clear();
		Global.gameEndSystem.loseCondition.Clear();
        Global.gameEndSystem.winLoseText.text = "";
       
        Destroy(curLevel.placedTrack.gameObject);

        if (index < levelList.Count-1)
            ++index;
        else
            index = 0;

        curLevel = levelList[index] ;
        _initLevel();


    }
}
