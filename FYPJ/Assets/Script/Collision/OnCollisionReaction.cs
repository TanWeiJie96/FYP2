using UnityEngine;
using System.Collections;

public abstract class OnCollisionReaction : MonoBehaviour {
    public abstract void onColRec(Collision collision);
    
    public abstract void onTriEnter(Collider other);

    public abstract void onTriExit(Collider other);

}
