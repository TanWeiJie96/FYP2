using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
    public UIHandler scoreUI;
    
    public UIHandler timerUI;
    public Timer timerClass;

    public UIHandler levelUI;

    public UIHandler pauseUI;

    public GameEndMenu gameEndMenu;

	// Use this for initialization
	public void _initUI () {
        //Debug.Log("Init uimanager" + Global.gameUI.gameObject.transform.GetChild(0).gameObject.name);

        foreach (Transform child in Global.gameUI.gameObject.transform.GetChild(0))
        {
            if (child.gameObject.name == "InGameScore")
            {
                scoreUI = child.gameObject.GetComponent<UIHandler>();
            }

            if (child.gameObject.name == "InGameTimer")
            {
                timerUI = child.gameObject.GetComponent<UIHandler>();
            }

            if (child.gameObject.name == "InGameLevel")
            {
                levelUI = child.gameObject.GetComponent<UIHandler>();
            }

            if (child.gameObject.name == "PauseMenu")
            {
                pauseUI = child.gameObject.GetComponent<UIHandler>();
            }
        }
        pauseUI.gameObject.SetActive(false);

        if (gameEndMenu == null)
        {
            gameEndMenu = GameObject.Find("GameEndMenu").GetComponent<GameEndMenu>();
            gameEndMenu.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        _updateTimer();
    }

    void _updateTimer()
    {
        if (timerClass.timerAmount > 5)
            timerUI._changeText(timerClass.timerAmount.ToString(), Color.yellow);
        else
            timerUI._changeText(timerClass.timerAmount.ToString(), Color.red);
    }

    public void _updateScore(int temptext)
    {
        scoreUI._changeText(temptext.ToString());
    }

    public void _updateLevel(int temptext)
    {
        levelUI._changeText(temptext.ToString());
    }

    public void _pauseGame()
    {
        timerClass.stopTime = !Global.uiManager.timerClass.stopTime;

        Global.controls.paused = !Global.controls.paused;
        Global.playerScript.motor.stopMoving = !Global.playerScript.motor.stopMoving; 
    }

    public void _togglePauseUI()
    {
        pauseUI.gameObject.SetActive(!Global.uiManager.pauseUI.gameObject.activeSelf);
        _pauseGame();
   
    }

    public void _toggleScoreUI()
    {
        scoreUI.gameObject.SetActive(!Global.uiManager.scoreUI.gameObject.activeSelf);
        _pauseGame();
    }
}
