using UnityEngine;
using System.Collections;


public class Global:MonoBehaviour{
    public static PlayerScript playerScript;
    public static GameEndSystem gameEndSystem;
    public static LevelSystem levelSystem;

    void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        gameEndSystem = GameObject.Find("GameEndSystem").GetComponent<GameEndSystem>();
        levelSystem = GameObject.Find("LevelInit").GetComponent<LevelSystem>();
       
        if(playerScript.name!=null)
            Debug.Log(playerScript.name + " is up");
         if(gameEndSystem.name!=null)
            Debug.Log(gameEndSystem.name + " is up");
         if (levelSystem.name != null)
             Debug.Log(levelSystem.name + " is up");

         levelSystem._initLevel();
    } 

}
