using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public bool isMoving = false;
	public float speed = 0.05f;
	Vector3 startPos;
	public Vector3 endPos = new Vector3(0,0,0);
	Vector3 direction;
	float distance;

	// Use this for initialization
	void Start () {
		startPos  = gameObject.transform.position;
		direction = (endPos - startPos).normalized;
		distance = (endPos - startPos).magnitude;
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			gameObject.transform.Translate (direction * speed);
			if (currentDistance() >= distance) {
				direction = -direction;
				Vector3 temp = startPos;
				startPos = gameObject.transform.position;
				endPos = temp;
				distance = (endPos - startPos).magnitude;
			}
		}
	}

	float currentDistance() {
		return (gameObject.transform.position - startPos).magnitude;
	}
//	void OnCollisionStay(Collision collisionInfo) {
//		if (collisionInfo.gameObject.name == "FPSController") {
//			collisionInfo.gameObject.transform.Translate (new Vector3 (speed, 0, 0));
//		}
//	}
}
