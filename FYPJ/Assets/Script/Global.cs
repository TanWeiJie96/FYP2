using UnityEngine;
using System.Collections;


public class Global:MonoBehaviour{
    public static PlayerScript playerScript;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

}
