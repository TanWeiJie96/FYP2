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

    public GameEnd gameEnd;

    public bool allNeededToWin = false;
    public List<bool> winCondition;

    public bool allNeededToLose = false;
    public List<bool> loseCondition;

    public Text winLoseText;

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
                    winLoseText.text = "you win";
                    StartCoroutine(Global.levelSystem.beforeNextLevel());
					//Global.levelSystem.nextLevel();
                    break;
                }
            }
            Debug.Log("something is wrong");
        }
        else
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
                winLoseText.text = "you win";
                StartCoroutine(Global.levelSystem.beforeNextLevel());
            }

        }
        needsCheckForGameEnd = false;

    }
}
