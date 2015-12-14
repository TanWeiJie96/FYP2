using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {
    public int menuIndex = 0;       //indicates which menu it is on 
    public List<GameObject> menuList;
   

	// Use this for initialization
	void Start () {
	    menuList[menuIndex].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void _tranverseMenu()
    {
        menuList[menuIndex].SetActive(false);
        if (menuIndex < menuList.Count)
            ++menuIndex;
        else
            menuIndex = 0;
        menuList[menuIndex].SetActive(true);
    }

    public void _jumpMenu(int newIndex)
    {
        menuIndex = newIndex;
        menuList[menuIndex].SetActive(false);
    }
}
