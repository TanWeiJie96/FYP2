using UnityEngine;
using System.Collections;

public class PlayerMagnetAction : MonoBehaviour {

    public float magnetStrength = 5f;
    public float magnetDirection = 1; // 1 = Attraction, -1 = Repel
    public bool looseMagnet = true;

    public float distanceStrength = 10f; // Strength, based on the distance

    private Transform trans; // playerTransform
    private Rigidbody thisRd; // playerRigidBody
    private Transform magnetTrans; // magnetTransform 
    private bool magnetInZone;

    void Awake()
    {
        trans = transform;
        thisRd = trans.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (magnetInZone)
        {
            Vector3 directionToMagnet = magnetTrans.position - trans.position;
            float distance = Vector3.Distance(magnetTrans.position, trans.position);
            float magnetDistanceStr = (distanceStrength / distance) * magnetStrength;

            thisRd.AddForce(magnetDistanceStr * (directionToMagnet * magnetDirection), ForceMode.Force);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Magnet")
        {
            Debug.Log("Magnet Detected!");
            magnetTrans = other.transform;
            magnetInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Magnet" && looseMagnet == true)
        {
            Debug.Log("Magnet Exit!");
            magnetInZone = false;
        }
    }
}
