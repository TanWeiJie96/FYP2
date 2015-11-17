using UnityEngine;
using System.Collections;


public class Global:MonoBehaviour{
    public static PlayerScript playerScript;
    public static GameEndSystem gameEndSystem;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        gameEndSystem = GameObject.Find("GameEndSystem").GetComponent<GameEndSystem>();
       
        if(playerScript.name!=null)
            Debug.Log(playerScript.name + " is up");
         if(gameEndSystem.name!=null)
            Debug.Log(gameEndSystem.name + " is up");
    } 

}
