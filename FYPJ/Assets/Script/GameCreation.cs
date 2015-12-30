using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameCreation : MonoBehaviour 
{
    public List<GameObject> gameObjList;


	// Use this for initialization
	void Awake () {
		Global.CreationFunc += Create;
	}

	void Create()
	{
		for (int i = 0; i < gameObjList.Count; ++i)
		{
			if(GameObject.Find(gameObjList[i].name))
			{
				Debug.Log(gameObjList[i].name + " is in the scene~!");
			}
			else
			{
				GameObject.Instantiate(gameObjList[i]);
				Debug.Log(gameObjList[i].name + " has been created~!");
			}
		}
	}

	void OnDestroy()
	{
		Global.CreationFunc -= Create;
	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
