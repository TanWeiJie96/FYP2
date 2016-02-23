using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {
    public int menuIndex = 0;       //indicates which menu it is on 
    public List<GameObject> menuList;
    public List<MenuHandler> menuHandlerList;

    public static MenuManager instance;
   

	// Use this for initialization
	void Start () {
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);


        if (menuHandlerList[menuIndex] != null)
            menuHandlerList[menuIndex].gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Quit()
	{
		Application.Quit();
	}

    public void _reverseMenu()
    {
        menuHandlerList[menuIndex]._resetMenu();
        menuHandlerList[menuIndex].gameObject.SetActive(false);
        if (menuIndex > 0)
            --menuIndex;
        else
            menuIndex = menuHandlerList.Count;

        SoundManager.instance._playSingle(SoundManager.instance.buttonDownIndex);

        menuHandlerList[menuIndex].gameObject.SetActive(true);
    }


    public void _tranverseMenu()
    {
        menuHandlerList[menuIndex]._resetMenu();
        menuHandlerList[menuIndex].gameObject.SetActive(false);
        if (menuIndex < menuHandlerList.Count)
            ++menuIndex;
        else
            menuIndex = 0;
        SoundManager.instance._playSingle(SoundManager.instance.buttonDownIndex);

        menuHandlerList[menuIndex].gameObject.SetActive(true);
    }

    public void _jumpMenu(int newIndex)
    {
        menuHandlerList[menuIndex]._resetMenu();
        menuHandlerList[menuIndex].gameObject.SetActive(false);

        menuIndex = newIndex;
        SoundManager.instance._playSingle(SoundManager.instance.buttonDownIndex);
        menuHandlerList[menuIndex].gameObject.SetActive(true);
    }
}
