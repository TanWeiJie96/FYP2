using UnityEngine;
using System.Collections;

public enum VehicleType
{
    SPEED,
    CONTROL,
    HEAVY
}

//storage class
public class GameInfo : MonoBehaviour {
    public VehicleType vehicleType = VehicleType.SPEED;
    public MenuManager MMan;

    public void _setVehicleType(int VT)
    {
       // vehicleType = VT;
        vehicleType = (VehicleType)VT;
        MMan._tranverseMenu();
    }
}
