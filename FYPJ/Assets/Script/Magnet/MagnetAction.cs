using UnityEngine;
using System.Collections;

public class MagnetAction  : MonoBehaviour {

    // Script for managing magnet movement

    //public
    public Vector3 newPosition; // Target Position
    
    //private
    private Transform trans; // Hold this.transform

    void Awake()
    {
        trans = transform;
    }

    void Update()
    {
        trans.position = Vector3.Lerp(trans.position, newPosition, Time.deltaTime * 1.5f);

        if (Mathf.Abs(newPosition.x - trans.position.x) < 0.05)
        {
            trans.position = newPosition;
        }
    }
}

