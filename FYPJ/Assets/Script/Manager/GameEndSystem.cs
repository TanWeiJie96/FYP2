using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;


public enum GameEnd
{
    WIN,
    DRAW,
    LOSE,
    NOTYET
}


public class GameEndSystem : MonoBehaviour {

    public bool needsCheckForGameEnd;                  //needed so that checking whether the game has ended does not happen every frame

    public GameEnd gameEnd;                             //enum to indicate cur game state

    public bool allNeededToWin = false;
    public List<bool> winCondition;

    public bool allNeededToLose = false;
    public List<bool> loseCondition;

    public CheckForCollision areaToLose;

    //public Text winLoseText;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (needsCheckForGameEnd)
        {
            _checkForGameEnd();
        }
	}

    public void _checkForGameEnd()
    {
        //Debug.Log("win condition needed:"+winCondition.Count);
        if (!allNeededToWin)
        {
            //if one of the winning condition is met, return win status
            for (int i = 0; i < winCondition.Count; ++i)
            {
                if (winCondition[i] == true)
                {
                    gameEnd = GameEnd.WIN;
                    Debug.Log("you win with one of the condition met");
                    
                    Global.uiManager.gameEndMenu.title.text = "You win";
                    //StartCoroutine(Global.levelSystem.beforeNextLevel());
					//Global.levelSystem.nextLevel();
                    Global.levelSystem._setUpGameEndMenu();
                    break;
                }
            }
            Debug.Log("something is wrong");
        }
        else if (allNeededToWin)
        {
            //if all of the winning condition is met, return win status
            bool confirmWin = true;
            for (int i = 0; i < winCondition.Count; ++i)
            {
                if (winCondition[i] == false)
                {
                    Debug.Log("Amount of condition met: " + i + "/" + winCondition.Count);
                    confirmWin = false;
                    break;
                }
            }
            if (confirmWin)
            {
                gameEnd = GameEnd.WIN;
                Debug.Log("you win with all the condition met");
                Global.uiManager.gameEndMenu.title.text = "you win";
                //StartCoroutine(Global.levelSystem.beforeNextLevel());
                Global.levelSystem._setUpGameEndMenu();
            }
        }
        
        if (gameEnd == GameEnd.NOTYET)
        {
            Debug.Log(" Checking for lose condition");
            for (int i = 0; i < loseCondition.Count; ++i)
            {
                if (loseCondition[i] == true)
                {
                    gameEnd = GameEnd.LOSE;
                    Debug.Log("you lose~!");
                    Global.uiManager.gameEndMenu.title.text = "you lose";
                    Global.levelSystem._setUpGameEndMenu();
                    
                }
            }
        }

        needsCheckForGameEnd = false;

    }

    public void _reset()
    {
        gameEnd = GameEnd.NOTYET;
        winCondition.Clear();
        loseCondition.Clear();
    }
}
