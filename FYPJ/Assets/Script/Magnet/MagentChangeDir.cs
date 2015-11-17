using UnityEngine;
using System.Collections;

public class MagentChangeDir : MonoBehaviour {

    public Vector3 magnetDirection;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Magnet")
        {
            Debug.Log("Magnet Hit!");
            col.GetComponent <MagnetAction> ().newPosition = magnetDirection;
        }
    }
}
