using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class MenuHandler : MonoBehaviour {
   // public List<Button> buttonOnMenu;
    public List<ButtonHandler> buttonHanOnMenu;

    public int curButtonIndex;
    public int updownSize = 1;

    public ButtonHandler curButton;

    public bool Updown = true;
	

	// Use this for initialization
	void Start () {
        //Debug.Log("gg");
       curButton = buttonHanOnMenu[curButtonIndex];
       _resetMenu();
	}
	
	// Update is called once per frame
	void Update () {

        //if (Updown)
        {
            if (InputSetUp.instance.characterActions.Down.WasPressed)
            {
                _transerveButton(true, updownSize);
            }
            if (InputSetUp.instance.characterActions.Up.WasPressed)
            {
                _transerveButton(false, updownSize);
            }


        }
       // else
        {
            if (InputSetUp.instance.characterActions.Right.WasPressed)
            {
                _transerveButton(true, 1);
            }
            if (InputSetUp.instance.characterActions.Left.WasPressed)
            {
                _transerveButton(false,1);
            }
        }

        if (InputSetUp.instance.characterActions.Select.WasReleased)
        {
            _selectButton();
        }



	}

    void _selectButton()
    {
        curButton.ownButton.onClick.Invoke();
    }

    void _highlightButton()
    {
        ColorBlock cb2 = curButton.ownButton.colors;
        curButton.ownButton.targetGraphic.color = cb2.highlightedColor;

        curButton._buttonScale(true);
    }


    public void _resetMenu()
    {
        ColorBlock cb = curButton.ownButton.colors;
        curButton.ownButton.targetGraphic.color = cb.normalColor;

        curButtonIndex = 0;
        curButton = buttonHanOnMenu[curButtonIndex];
        _highlightButton();
    }


    void _transerveButton(bool downward, int jumpAmount){

        //check if the mouse has selected any button
        foreach (ButtonHandler tempbuthan in buttonHanOnMenu)
        {
            if (tempbuthan.selected)
            {
                ColorBlock cb3 = tempbuthan.ownButton.colors;
                tempbuthan.ownButton.targetGraphic.color = cb3.normalColor;
                tempbuthan._buttonScale(false);
                tempbuthan.selected = false;
                break;
            }
        }


        ColorBlock cb = curButton.ownButton.colors;
        curButton.ownButton.targetGraphic.color = cb.normalColor;

        curButton._buttonScale(false);
        curButton.selected = false;
        /*
		if (curButtonIndex == 0)
		{
			curButton.animator.SetTrigger("Normal");
			curButton.animator.SetTrigger("Normal_char1");
			curButton.animator.SetTrigger("Normal_levelIcon");
			curButton.animator.SetTrigger("Normal_BGM");
			curButton.animator.SetTrigger("Normal_Retry");
			curButton.animator.SetTrigger("Normal_PauseRetry");

		}

		else if (curButtonIndex == 1)
		{
			curButton.animator.SetTrigger("Normal_Option");
			curButton.animator.SetTrigger("Normal_char2");
			curButton.animator.SetTrigger("Normal_levelIcon");
			curButton.animator.SetTrigger("Normal_SE");
			curButton.animator.SetTrigger("Normal_NextLevel");
			curButton.animator.SetTrigger("Normal_PauseBackToMenu");
			
			
		}
		else if (curButtonIndex == 2)
		{ 
			curButton.animator.SetTrigger("Normal_Exit");
			curButton.animator.SetTrigger("Normal_Back");
			curButton.animator.SetTrigger("Normal_levelIcon");
			curButton.animator.SetTrigger("Normal_BackToMenu");
			curButton.animator.SetTrigger("Normal_PauseNL");
			
			
		}
		else if (curButtonIndex == 3)
		{
			curButton.animator.SetTrigger("Normal_levelIcon");
			curButton.animator.SetTrigger("Normal_PauseBTG");
			
		}
		else if (curButtonIndex == 4)
		{
			curButton.animator.SetTrigger("Normal_levelIcon");
			
		}
		else if (curButtonIndex == 5)
		{
			curButton.animator.SetTrigger("Normal_levelIcon");
			
		}	
		else if (curButtonIndex == 6)
		{
			curButton.animator.SetTrigger("Normal_levelIcon");
			
		}	
		else if (curButtonIndex == 7)
		{
			curButton.animator.SetTrigger("Normal_levelIcon");
			
		}	
		else if (curButtonIndex == 8)
		{
			curButton.animator.SetTrigger("Normal_levelIcon");
			
		}
		else if (curButtonIndex == 9)
		{
			curButton.animator.SetTrigger("Normal_Back");
			
		}*/

        if (downward)
        {
            if (curButtonIndex < buttonHanOnMenu.Count - 1)
                if (curButtonIndex + jumpAmount < buttonHanOnMenu.Count)
                    curButtonIndex += jumpAmount;
                else
                    curButtonIndex = buttonHanOnMenu.Count - 1;
            else
                curButtonIndex = 0;
           
        }
        else
        {
            if (curButtonIndex > 0)
                if (curButtonIndex - jumpAmount < buttonHanOnMenu.Count)
                    curButtonIndex -= jumpAmount;
                else
                    curButtonIndex = 0;
            else
                curButtonIndex = buttonHanOnMenu.Count - 1;
        }
        curButton = buttonHanOnMenu[curButtonIndex];

        ColorBlock cb2 = curButton.ownButton.colors;
        curButton.ownButton.targetGraphic.color = cb2.highlightedColor;

        curButton._buttonScale(true);
        curButton.selected = true;
        /*
		if (curButtonIndex == 0)
		{
			curButton.animator.SetTrigger("Highlighted");
			curButton.animator.SetTrigger("Highlighted_char1");
			curButton.animator.SetTrigger("Highlighted_levelIcon");
			curButton.animator.SetTrigger("Highlighted_BGM");
			curButton.animator.SetTrigger("Highlighted_Retry");
			curButton.animator.SetTrigger("Highlighted_PauseRetry");
		}

		else if (curButtonIndex == 1)
		{
			curButton.animator.SetTrigger("Highlighted_Option");
			curButton.animator.SetTrigger("Highlighted_char2");
			curButton.animator.SetTrigger("Highlighted_levelIcon");
			curButton.animator.SetTrigger("Highlighted_SE");
			curButton.animator.SetTrigger("Highlighted_NextLevel");
			curButton.animator.SetTrigger("Highlighted_PauseBackToMenu");
		}

		else if (curButtonIndex == 2)
		{
			curButton.animator.SetTrigger("Highlighted_Exit");
			curButton.animator.SetTrigger("Highlighted_Back");
			curButton.animator.SetTrigger("Highlighted_levelIcon");
			curButton.animator.SetTrigger("Highlighted_BackToMenu");
			curButton.animator.SetTrigger("Highlighted_PauseNL");
		}
		else if (curButtonIndex == 3)
		{
			curButton.animator.SetTrigger("Highlighted_levelIcon");
			curButton.animator.SetTrigger("Highlighted_PauseBTG");
			
		}
		else if (curButtonIndex == 4)
		{
			curButton.animator.SetTrigger("Highlighted_levelIcon");
			
		}
		else if (curButtonIndex == 5)
		{
			curButton.animator.SetTrigger("Highlighted_levelIcon");
			
		}
		else if (curButtonIndex == 6)
		{
			curButton.animator.SetTrigger("Highlighted_levelIcon");
			
		}
		else if (curButtonIndex == 7)
		{
			curButton.animator.SetTrigger("Highlighted_levelIcon");
			
		}
		else if (curButtonIndex == 8)
		{
			curButton.animator.SetTrigger("Highlighted_levelIcon");
			
		}
		else if (curButtonIndex == 9)
		{
			curButton.animator.SetTrigger("Highlighted_Back");
			
		}
         */ 
    }
}
