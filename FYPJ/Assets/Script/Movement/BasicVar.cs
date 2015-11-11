using UnityEngine;
using System.Collections;

public class BasicVar : MonoBehaviour {
	public string ident;

	public float speed;
	public Vector3 dir;
	public Vector3 accel;
	public Vector3 vel;

	void Awake () {
        vel = accel * speed;
	}
}
