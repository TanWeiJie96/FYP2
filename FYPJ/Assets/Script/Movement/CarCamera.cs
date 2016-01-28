using UnityEngine;
using System.Collections;

public class CarCamera : MonoBehaviour
{
    public Transform car;

    public float distance = 6.4f;
    public float height = 1.4f;
    public float rotationDamping = 3f;
    public float heightDamping = 2f;
    public float zoomRatio = 0.5f;
    public float defaultFOV = 60;
    public float lookAtDamping = 5;

    public bool lookBehind;
    public bool followAngle;

    private Vector3 rotationVector;

    private bool cameraView;

    Rigidbody carRb;
    public Transform myTransform;
    public Camera cam;

    void Start()
    {
        car = GameObject.Find("CarModel").transform;

        cam = Camera.main;
        myTransform = transform;

        if (car != null)
            carRb = car.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// When collided with wall, my camera shld be position at the wall "INCOMPLETED: it looks very immediate teleport to the wall instead of lerp.. so i havent fix this problem yet"
    /// </summary>
    /// <returns></returns>
    bool CameraCollision()
    {
        RaycastHit wallHit;
        if (Physics.Linecast(this.transform.position, car.position, out wallHit))
        {
            // Requirement for this to happen, it must be a tall wall.
            if (wallHit.transform.localScale.y > 15)
            {
                Vector3 targetPos = new Vector3(this.transform.position.x,
                                                 this.transform.position.y,
                                                wallHit.point.z);

                this.transform.position = targetPos;//Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * 5);

                return true;
            }
        }
        return false;
    }

    void LateUpdate()
    {
        if (Application.loadedLevelName == "Level1")
        {
            // Smooth camera
            SmoothCamera();

            // Checking collision Camera-Wall
            CameraCollision();
        }
    }

    void SmoothCamera()
    {
        // Get "Targets"
        float targetAngle = rotationVector.y;
        float targetHeight = car.position.y + height;

        // Get "Currents"
        float myAngle = myTransform.eulerAngles.y;
        float myHeight = myTransform.position.y;

        // Lerp
        myAngle = Mathf.LerpAngle(myAngle, targetAngle, rotationDamping * Time.deltaTime);
        myHeight = Mathf.Lerp(myHeight, targetHeight, heightDamping * Time.deltaTime);

        // Apply Results
        Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);

        Vector3 targetPosition = car.position;
        targetPosition -= currentRotation * Vector3.forward * distance;
        targetPosition.y = myHeight;

        myTransform.position = targetPosition;

        myTransform.LookAt(car);
    }

    void FixedUpdate()
    {
        // Camera rotation follow car rotataion, meant for 3rd person camera only
        if (Application.loadedLevelName == "Level1")
        {
            if (followAngle)
                rotationVector.y = car.eulerAngles.y;
        }
    }

    public void ChangeCamera()
    {
        // Top Down View
        if(cameraView)
        {

            height = 9f;
            distance = 5f;
            
            // Camera rotation "DONT" follow car rotation
            followAngle = false;
        }

        // 3rd Person View
        else
        {
            height = 2f;
            distance = 4f;

            // Camera rotation "DO" follow car rotation
            followAngle = true;
        }


        cameraView = !cameraView;
    }
}
