using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

	public Vector3 newPosition = new Vector3 (0, 0, 0);

	void OnCollisionStay(Collision collisionInfo) {
		if (collisionInfo.gameObject.name == "FPSController") {
			collisionInfo.gameObject.transform.position = newPosition;
		}
	}
}
