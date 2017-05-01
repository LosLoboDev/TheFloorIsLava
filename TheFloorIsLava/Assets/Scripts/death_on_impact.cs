using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_on_impact : MonoBehaviour
{
    public Vector3 newPosition = new Vector3(-1.73f, 7.41f, -13.54f);

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.name == "FPSController")
        {
            collisionInfo.gameObject.transform.position = newPosition;
            Debug.Log("You died, restart!");
        }
    }
}
