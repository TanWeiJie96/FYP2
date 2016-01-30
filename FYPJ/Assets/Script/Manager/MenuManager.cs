using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {
    public int menuIndex = 0;       //indicates which menu it is on 
    public List<GameObject> menuList;
   

	// Use this for initialization
	void Start () {
		if (menuList[menuIndex] != null)
	    menuList[menuIndex].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void _reverseMenu()
    {
        menuList[menuIndex].SetActive(false);
        if (menuIndex > 0)
            --menuIndex;
        else
            menuIndex = menuList.Count;

        SoundManager.instance._playSingle(SoundManager.instance.buttonDownIndex);

        menuList[menuIndex].SetActive(true);
    }


    public void _tranverseMenu()
    {
        menuList[menuIndex].SetActive(false);
        if (menuIndex < menuList.Count)
            ++menuIndex;
        else
            menuIndex = 0;
        SoundManager.instance._playSingle(SoundManager.instance.buttonDownIndex);

        menuList[menuIndex].SetActive(true);
    }

    public void _jumpMenu(int newIndex)
    {
        menuList[menuIndex].SetActive(false);

        menuIndex = newIndex;
        SoundManager.instance._playSingle(SoundManager.instance.buttonDownIndex);
        menuList[menuIndex].SetActive(true);
    }
}
