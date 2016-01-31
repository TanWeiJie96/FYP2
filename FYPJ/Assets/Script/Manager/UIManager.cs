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


            else if (child.gameObject.name == "PauseMenu")
            {
                pauseUI = child.gameObject.GetComponent<UIHandler>();
            }

            else if (child.gameObject.name == "GameEndMenu" && gameEndMenu == null)
            {
                gameEndMenu = child.gameObject.GetComponent<GameEndMenu>();
          
            }
        }

        foreach (Transform child in gameEndMenu.gameObject.transform)
        {
            if (child.name == "NextLevel_Button")
            {
                child.gameObject.GetComponent<Button>().onClick.AddListener(delegate { Global.levelSystem.nextLevel(true); });
            }
            else if (child.name == "BackToMenu_Button")
            {
                child.gameObject.GetComponent<Button>().onClick.AddListener(delegate { Global.sceneManager._changeSceneWithName("Menu"); });
            }
            else if (child.name == "Retry_Button")
            {
                child.gameObject.GetComponent<Button>().onClick.AddListener(delegate { Global.levelSystem.resetLevel(true); });
            }
        }
        gameEndMenu.gameObject.SetActive(false);

        foreach (Transform child in pauseUI.gameObject.transform.GetChild(1))
        {
            if (child.name == "NextLevel_Button")
            {
                child.gameObject.GetComponent<Button>().onClick.AddListener(delegate { Global.levelSystem.nextLevel(); });
            }
            else if (child.name == "BackToMenu_Button")
            {
                child.gameObject.GetComponent<Button>().onClick.AddListener(delegate { Global.sceneManager._changeSceneWithName("Menu"); });
            }
            else if (child.name == "Retry_Button")
            {
                child.gameObject.GetComponent<Button>().onClick.AddListener(delegate { Global.levelSystem.resetLevel(); });
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
            inGameUI.timerUI._changeText(inGameUI.timerClass.timerAmount.ToString("F2"), Color.black);
        else
            inGameUI.timerUI._changeText(inGameUI.timerClass.timerAmount.ToString("F2"), Color.red);
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
        Global.playerScript.motor.RbToMove.useGravity = !Global.playerScript.motor.RbToMove.useGravity;
    }

    public void _togglePauseUI()
    {
        pauseUI.gameObject.SetActive(!pauseUI.gameObject.activeSelf);


        _pauseGame();
   
    }

    public void _toggleScoreUI()
    {
        inGameUI.scoreUI.gameObject.SetActive(!inGameUI.scoreUI.gameObject.activeSelf);
        _pauseGame();
    }
}
