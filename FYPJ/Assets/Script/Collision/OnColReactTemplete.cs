using UnityEngine;
using System.Collections;

public class OnColReactTemplete : OnCollisionReaction
{

    public override void onColRec(Collision collision) {/*Debug.Log("Templete hit!");*/ }

    public override void onTriEnter(Collider other) { /*Debug.Log("Templete hit!");*/ }

    public override void onTriExit(Collider other) {/*Debug.Log("Templete hit!");*/ }

    public override void onTriEnterPower(Collider other) { /*Debug.Log("Templete hit!");*/ }

	public override void onTriStay(Collider other) { /*Debug.Log("Templete hit!");*/ } 
}
