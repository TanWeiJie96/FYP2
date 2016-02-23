using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour {
    private int score = 0;
    public int highScore = 0;
    
    
    private float rating = 0;
    public float highRating = 0;

    public int getScore()
    {
        return score;
    }

    public float makeRating()
    {

        return rating;
    }

    public float getRating()
    {
        return rating;
    }

    public void updateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            //Debug.Log("HighScore has been made");
        }
        else
        {
            Debug.Log("Score has not beat highRating");
        }
    }

    public void _updateHighRating()
    {
       if (rating > highRating)
       {
           highRating = rating;
        }
        else
        {
            Debug.Log("rating has not beat highRating");
        }
        
    }

    public void _updateScore(int amount)
    {
        int tempScore = amount;
        if (tempScore < 0)
        {
            Debug.LogWarning("Score should not be negative");
        }
        else
        {
            //Debug.Log("Score Updated");
            score = tempScore;
            Global.uiManager._updateScore(score);
        }
    }

    public void _incrScore(int amount)
    {
        int tempScore = score + amount;
        if (tempScore < 0)
        {
            Debug.LogWarning("Score should not be negative");
        }
        else
        {
            //Debug.Log("Score Updated");
            score = tempScore;
            Global.uiManager._updateScore(score);
        }
    }


    public void updateRating(float amount)
    {
       // float tempRating = amount;
        if (amount < 0 || amount > 100)
        {
            Debug.LogWarning("Rating not in range");
        }
    
        else
        {
            rating = amount;
            //Global.uiManager.(score);
        }
    }
}
