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

        if (Input.GetKeyDown(KeyCode.F))
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

		if (curButton == buttonOnMenu[0])
		{
			curButton.animator.SetTrigger("Highlighted");
			Debug.Log ("HIGHLIGHT");
		}
    }


    public void _resetMenu()
    {
        ColorBlock cb = curButton.colors;
        curButton.targetGraphic.color = cb.normalColor;
		

        curButton = buttonOnMenu[0];
        _highlightButton();
    }


    void _transerveButton(bool downward, int jumpAmount){
        ColorBlock cb = curButton.colors;
        curButton.targetGraphic.color = cb.normalColor;

		if (curButton == buttonOnMenu[0])
		{
			curButton.animator.SetTrigger("Normal");
			Debug.Log ("NORMAL");
			
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
                if (curButtonIndex + jumpAmount < buttonOnMenu.Count)
                    curButtonIndex -= jumpAmount;
                else
                    curButtonIndex = 0;
            else
                curButtonIndex = buttonOnMenu.Count - 1;
        }
        curButton = buttonOnMenu[curButtonIndex];

        ColorBlock cb2 = curButton.colors;
        curButton.targetGraphic.color = cb2.highlightedColor; 


		if (curButton == buttonOnMenu[0])
		{
			curButton.animator.SetTrigger("Highlighted");
			Debug.Log ("HIGHLIGHT");
		}
	
    }

}
