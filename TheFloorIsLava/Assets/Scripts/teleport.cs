using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

	public Vector3 newPosition = new Vector3 (0, 0, 0);
    public AudioClip sound;

	void OnCollisionStay(Collision collisionInfo) {
		if (collisionInfo.gameObject.name == "FPSController") {
			collisionInfo.gameObject.transform.position = newPosition;

            AudioSource a = gameObject.GetComponent<AudioSource>();
            a.PlayOneShot(sound, 0.7f);
		}
	}
}
