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
            
        }
        
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

    public void resetStat()
    {
        Global.checkPointSystem.CheckPoints.Clear();
        Global.gameEndSystem._reset();

        Global.playerScript.motor.cur.vel = Vector3.zero;
        Global.playerScript.motor.cur.dir = new Vector3(0, 0, 1);
 
        Global.playerScript.playerModel.gameObject.transform.rotation = Quaternion.identity;

        Destroy(curLevel.placedTrack.gameObject);

        Global.uiManager.PauseUI.gameObject.SetActive(false);
    }

    public void nextLevel()
    {
        resetStat();

        if (index < levelList.Count-1)
            ++index;
        else
            index = 0;

        curLevel = levelList[index] ;
        _initLevel();
    }

	
	public void resetLevel()
	{
        resetStat();
		
		curLevel = levelList[index] ;
		_initLevel();
		
	}
}
