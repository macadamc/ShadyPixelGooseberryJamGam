using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPoints : MonoBehaviour {
    public float floatSpeed;
	// Update is called once per frame
	void Update ()
    {
        float newY = transform.position.y + (floatSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
	}

}
