using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class MenuHandler : MonoBehaviour {
    public List<Button> buttonOnMenu;

    public int curButtonIndex;
    public int updownSize = 1;

    public Button curButton;

    public bool Updown = true;
	

	// Use this for initialization
	void Start () {
        curButton = buttonOnMenu[0];
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

        if (InputSetUp.instance.characterActions.SwitchPolarity.WasPressed)
        {
            _selectButton();
        }



	}

    void _selectButton()
    {
        curButton.onClick.Invoke();
    }

    void _highlightButton()
    {
       ColorBlock cb2 = curButton.colors;
       curButton.targetGraphic.color = cb2.highlightedColor; 
    }


    public void _resetMenu()
    {
        ColorBlock cb = curButton.colors;
        curButton.targetGraphic.color = cb.normalColor;
		


        curButtonIndex = 0;
        curButton = buttonOnMenu[curButtonIndex];
        _highlightButton();
    }


    void _transerveButton(bool downward, int jumpAmount){
        ColorBlock cb = curButton.colors;
        curButton.targetGraphic.color = cb.normalColor;

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
			
		}

        if (downward)
        {
            if (curButtonIndex < buttonOnMenu.Count - 1)
                if (curButtonIndex + jumpAmount < buttonOnMenu.Count)
                    curButtonIndex += jumpAmount;
                else
                    curButtonIndex = buttonOnMenu.Count-1;
            else
                curButtonIndex = 0;
           
        }
        else
        {
            if (curButtonIndex > 0)
                if (curButtonIndex - jumpAmount < buttonOnMenu.Count)
                    curButtonIndex -= jumpAmount;
                else
                    curButtonIndex = 0;
            else
                curButtonIndex = buttonOnMenu.Count - 1;
        }
        curButton = buttonOnMenu[curButtonIndex];

        ColorBlock cb2 = curButton.colors;
        curButton.targetGraphic.color = cb2.highlightedColor; 


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
    }
}
