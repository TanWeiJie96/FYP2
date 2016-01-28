using UnityEngine;
using UnityEngine.UI;

using System.Collections;


public class GameEndMenu : MonoBehaviour {
    public Text title; 

    public UIHandler score;
    public UIHandler timeBonus;
    public UIHandler totalScore;

    public UIHandler rating;

    public void _showStats()
    {
        int IScore = Global.scoreSystem.getScore();
        float ITBonus = Mathf.Round(Global.levelSystem.curLevel._calcTimeBonus());
        float ITScore = (IScore + ITBonus);

        float IRat = Mathf.Round(Global.levelSystem.curLevel._calcRating(ITScore));

        score._changeText( IScore.ToString() );
        timeBonus._changeText( ITBonus.ToString() );
        totalScore._changeText( ITScore.ToString() );

        rating._changeText( IRat.ToString() + " / 10 ");
        
    }
}
