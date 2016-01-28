using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

    public UIHandler pauseUI;
    public InGameUI inGameUI;
    public GameEndMenu gameEndMenu;

	// Use this for initialization
	public void _initUI () {
        //Debug.Log("Init uimanager" + Global.gameUI.gameObject.transform.GetChild(0).gameObject.name);

        foreach (Transform child in Global.gameUI.gameObject.transform.GetChild(0))
        {
            if (child.gameObject.name == "InGameUI")
            {
                inGameUI = child.gameObject.GetComponent<InGameUI>();
            }


            if (child.gameObject.name == "PauseMenu")
            {
                pauseUI = child.gameObject.GetComponent<UIHandler>();
            }

            if (child.gameObject.name == "GameEndMenu" && gameEndMenu == null)
            {
                gameEndMenu = child.gameObject.GetComponent<GameEndMenu>();
                gameEndMenu.gameObject.SetActive(false);
            }
        }
        pauseUI.gameObject.SetActive(false);

        
	}
	
	// Update is called once per frame
	void Update () {
        _updateTimer();
    }

    void _updateTimer()
    {
        if (inGameUI.timerClass.timerAmount > 5)
            inGameUI.timerUI._changeText(inGameUI.timerClass.timerAmount.ToString(), Color.black);
        else
            inGameUI.timerUI._changeText(inGameUI.timerClass.timerAmount.ToString(), Color.red);
    }

    public void _updateScore(int temptext)
    {
        inGameUI.scoreUI._changeText(temptext.ToString());
    }

    public void _updateLevel(int temptext)
    {
        inGameUI.levelUI._changeText(temptext.ToString());
    }

    public void _pauseGame()
    {
        inGameUI.timerClass.stopTime = !inGameUI.timerClass.stopTime;

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
        inGameUI.scoreUI.gameObject.SetActive(!inGameUI.scoreUI.gameObject.activeSelf);
        _pauseGame();
    }
}
