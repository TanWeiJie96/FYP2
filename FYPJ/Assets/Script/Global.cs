using UnityEngine;
using System.Collections;


public class Global:MonoBehaviour{
    public static PlayerScript playerScript;
    public static GameEndSystem gameEndSystem;
    public static LevelSystem levelSystem;
	public static CheckPointSystem checkPointSystem;

	public delegate void CreationEvent();
	public static CreationEvent CreationFunc;

    void Start()
    {
		if (CreationFunc != null)
			CreationFunc();

        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        gameEndSystem = GameObject.Find("GameEndSystem").GetComponent<GameEndSystem>();

        levelSystem = GameObject.Find("LevelInit").GetComponent<LevelSystem>();
		checkPointSystem = GameObject.Find("CheckPointSystem").GetComponent<CheckPointSystem>();
       
        if(playerScript.name!=null)
            Debug.Log(playerScript.name + " is up");
         if(gameEndSystem.name!=null)
            Debug.Log(gameEndSystem.name + " is up");
		if (levelSystem && levelSystem.name != null)
             Debug.Log(levelSystem.name + " is up");

		if (checkPointSystem && checkPointSystem.name != null)
			Debug.Log(checkPointSystem.name + " is up");

         levelSystem._initLevel();
    } 

}
