using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_on_impact : MonoBehaviour
{
    public Vector3 newPosition = new Vector3(0, 0, 0);

    void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.gameObject.name);
        if (collisionInfo.gameObject.name == "FPSController")
        {
            collisionInfo.gameObject.transform.position = newPosition;
            Debug.Log("You died");
        }
    }
}
