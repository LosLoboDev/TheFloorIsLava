using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour {


//	void OnCollisionEnter (Collision col)
//	{
//		if(col.gameObject.name != "Ground")
//		{
//			Debug.Log(col.gameObject.name);
//		}
//	}

	void OnCollisionStay(Collision collisionInfo) {
		if (collisionInfo.gameObject.name == "FPSController") {
			collisionInfo.gameObject.transform.position = new Vector3 (0, 0, 0);
		}
	}

	void Update() {
//		Debug.Log ("Update");
	}

}
