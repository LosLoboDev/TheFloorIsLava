using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public bool isMoving = false;
	public float speed = 0.05f;
	int updateCount = 0;
	int xDistance = 80;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			gameObject.transform.Translate (new Vector3 (speed, 0, 0));
			updateCount++;
			if (updateCount == xDistance) {
				speed = -speed;
				updateCount = 0;
			}
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		if (collisionInfo.gameObject.name == "FPSController") {
			Debug.Log ("on platform!");
			collisionInfo.gameObject.transform.Translate (new Vector3 (speed, 0, 0));
		}
	}
}
