using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
    public UIHandler scoreUI;
    
    public UIHandler timerUI;
    public Timer timerClass;

    public UIHandler levelUI;

    public UIHandler PauseUI;

	// Use this for initialization
	void Start () {
        PauseUI.gameObject.SetActive(false);


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

    public void _updateScore(string temptext)
    {
        scoreUI._changeText(temptext);
    }

    public void _updateLevel(string temptext)
    {
        levelUI._changeText(temptext);
    }
}
