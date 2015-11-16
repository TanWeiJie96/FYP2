﻿using UnityEngine;
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

    void _checkForGameEnd()
    {
        if (!allNeededToWin)
        {
            //if one of the winning condition is met, return win status
            for (int i = 0; i < winCondition.Capacity; ++i)
            {
                if (winCondition[i] == true)
                {
                    gameEnd = GameEnd.WIN;
                    break;
                }
            }
        }
        else
        {
            //if all of the winning condition is met, return win status
            bool confirmWin = true;
            for (int i = 0; i < winCondition.Capacity; ++i)
            {
                if (winCondition[i] == false)
                {
                    confirmWin = false;
                    break;
                }
            }
            if (confirmWin)
            {
                gameEnd = GameEnd.WIN;
            }

        }


    }
}
