using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    bool yes = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            RotateObjectSlow();
    }

    void RotateObjectSlow()
    {
        transform.Rotate(Time.deltaTime * 30, 0, 0);
    }
}
