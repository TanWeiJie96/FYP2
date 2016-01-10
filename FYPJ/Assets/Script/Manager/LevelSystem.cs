using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSystem : MonoBehaviour {
    public List<LevelInfo> levelList;
    
    public LevelInfo curLevel;

    public int index;
    public GameEndMenu gameEndMenu;

	// Use this for initialization
	void Awake () {
        if (gameEndMenu == null)
        {
            gameEndMenu = GameObject.Find("GameEndMenu").GetComponent<GameEndMenu>();
            gameEndMenu.gameObject.SetActive(false);
        }
        
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

    public void _setUpGameEndMenu()
    {
         //gameEndMenu.timeBonus._changeText(Global
    }

    void _switchForBeforeNextLevel()
    {
        gameEndMenu.gameObject.SetActive(!gameEndMenu.gameObject.activeSelf);
        Global.controls.paused = !Global.controls.paused;
        Global.playerScript.motor.stopMoving = !Global.playerScript.motor.stopMoving;
        Global.uiManager.timerClass.stopTime = !Global.uiManager.timerClass.stopTime;
    }

    public IEnumerator beforeNextLevel()
    {
        _switchForBeforeNextLevel();
        yield return new WaitForSeconds(5);
        _switchForBeforeNextLevel();
        
        nextLevel();
        yield return null;
    }


    public void nextLevel()
    {
		Global.checkPointSystem.CheckPoints.Clear();
        Global.gameEndSystem._reset();
       
        Destroy(curLevel.placedTrack.gameObject);

        if (index < levelList.Count-1)
            ++index;
        else
            index = 0;

        curLevel = levelList[index] ;
        _initLevel();


    }
}
