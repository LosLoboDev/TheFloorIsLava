using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_on_fall : MonoBehaviour {

    public Vector3 newPosition = new Vector3(-1.73f, 7.41f, -13.54f);
    // Use this for initialization
    void Start () {
	}

    void Update()
    {
        if (transform.position.y < -25)
        {
            transform.position = newPosition;
        }
    }
}
