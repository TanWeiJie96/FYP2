using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSystem : MonoBehaviour {
    public List<LevelInfo> levelList;
    
    public LevelInfo curLevel;

    public int index;


    public CheckForCollision loseArea;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown( KeyCode.R ) )
		{
			resetLevel();
		}
	}

    public void _initLevel()
    {
        if (loseArea == null)
        {
            loseArea = GameObject.Find("loseArea").GetComponent<CheckForCollision>();
        }
        loseArea._init();

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
        Global.uiManager.gameEndMenu._showStats();
        Global.uiManager.gameEndMenu.gameObject.SetActive(!Global.uiManager.gameEndMenu.gameObject.activeSelf);
        _switchForBeforeNextLevel();
    }



    public void _switchForBeforeNextLevel()
    {
        
        Global.controls.paused = !Global.controls.paused;

        Global.playerScript.motor.stopMoving = !Global.playerScript.motor.stopMoving;
        Global.playerScript.motor.RbToMove.useGravity = !Global.playerScript.motor.RbToMove.useGravity;

        Global.uiManager.inGameUI.timerClass.stopTime = !Global.uiManager.inGameUI.timerClass.stopTime;
        //Global.uiManager.gameEndMenu.gameObject.SetActive(!Global.uiManager.gameEndMenu.gameObject.activeSelf);
    }

    public IEnumerator beforeNextLevel()
    {
        _setUpGameEndMenu();
        yield return new WaitForSeconds(5);
        _switchForBeforeNextLevel();
        
        nextLevel();
        yield return null;
    }

    public void resetStat(bool GameEnd)
    {
        Global.checkPointSystem.CheckPoints.Clear();
        Global.gameEndSystem._reset();

        //Score reset
        Global.scoreSystem._updateScore(0);

        //Players vel and dir
        Global.playerScript.motor.cur.vel = Vector3.zero;
        Global.playerScript.motor.cur.dir = new Vector3(0, 0, 1);
        Global.playerScript.playerModel.gameObject.transform.rotation = Quaternion.identity;

        Destroy(curLevel.placedTrack.gameObject);
       
        if(GameEnd)
            Global.uiManager.gameEndMenu.gameObject.SetActive(false);
        else
            Global.uiManager.pauseUI.gameObject.SetActive(false);
    }

    public void nextLevel(bool GameEnd = false)
    {

         _switchForBeforeNextLevel();

       
        resetStat(GameEnd);

        if (index < levelList.Count-1)
            ++index;
        else
            index = 0;

        curLevel = levelList[index] ;
        _initLevel();
    }


    public void resetLevel(bool GameEnd = false)
	{
         _switchForBeforeNextLevel();

        resetStat(GameEnd);
		
		curLevel = levelList[index] ;
		_initLevel();
		
	}
}
