using UnityEngine;
using System.Collections;

public class VehicleProfile : MonoBehaviour {
    public VehicleType vehicleType = VehicleType.SPEED;
    public GameObject vehicleModel;

    public float arrowSpinVel = 10f;
    public float motorJumpStr = 1000f;
    public float motorJumpDec = 0.8f;
    public float motorAmtAccel = 5.0f;
    public float motorMaxSpeed = 50f;

}
