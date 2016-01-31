using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum VehicleType
{
    SPEED,
    CONTROL,
    HEAVY
}

//storage class
public class GameInfo : MonoBehaviour {
    public List<VehicleProfile> list_VehProfile;
    public VehicleProfile chosen_VehProfile;

   // public MenuManager MMan;

    public static GameInfo instance;

    // Use this for initialization
    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    public void _setVehicleType(int VT)
    {
        chosen_VehProfile = list_VehProfile[VT];
        MenuManager.instance._tranverseMenu();
    }
}
