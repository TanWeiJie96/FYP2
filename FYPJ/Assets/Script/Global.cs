using UnityEngine;
using System.Collections;


public class Global:MonoBehaviour{
    public static GameObject gameUI;
    public static GameObject gameSystem;
    public static GameObject ingameObject;

    public static PlayerScript playerScript;
    public static GameInfo gameInfo;

    public static GameEndSystem gameEndSystem;
    public static LevelSystem levelSystem;
	public static CheckPointSystem checkPointSystem;
    public static ScoreSystem scoreSystem;
    public static SceneManager sceneManager;

    public static UIManager uiManager;


	public static CollectPowerUp collectPowerUp;

    public static Controls controls;

	public delegate void CreationEvent();
	public static CreationEvent CreationFunc;

    void Start()
    {
		if (CreationFunc != null)
			CreationFunc();
        //Debug.Log("Starting to do shit");

        gameUI = GameObject.Find("Game UI");
        gameSystem = GameObject.Find("Game System");
        ingameObject = GameObject.Find("InGame Object");

        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        gameEndSystem = GameObject.Find("GameEndSystem").GetComponent<GameEndSystem>();
        levelSystem = GameObject.Find("LevelInit").GetComponent<LevelSystem>();
        
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
		
        checkPointSystem = GameObject.Find("CheckPointSystem").GetComponent<CheckPointSystem>();
        controls = GameObject.Find("Controls").GetComponent<Controls>();
        scoreSystem = GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>();

        gameInfo = GameObject.Find("GameInfo").GetComponent<GameInfo>();
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();

        if (gameUI.name != null)
            Debug.Log(gameUI.name + " is up");

        if (playerScript.name != null)
            Debug.Log(playerScript.name + " is up");

        if(playerScript.name!=null)
            Debug.Log(playerScript.name + " is up");
         if(gameEndSystem.name!=null)
            Debug.Log(gameEndSystem.name + " is up");
		if (levelSystem && levelSystem.name != null)
             Debug.Log(levelSystem.name + " is up");

		if (checkPointSystem && checkPointSystem.name != null)
			Debug.Log(checkPointSystem.name + " is up");

        uiManager._initUI();
        levelSystem._initLevel();
        playerScript._createCar(gameInfo.chosen_VehProfile);
      // playerScript
    }

}
