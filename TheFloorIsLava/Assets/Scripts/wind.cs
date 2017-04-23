using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind : MonoBehaviour {

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //translate in certain direction
        rb.transform.Translate(Vector3.left * Time.deltaTime, Space.World);
    }
}
