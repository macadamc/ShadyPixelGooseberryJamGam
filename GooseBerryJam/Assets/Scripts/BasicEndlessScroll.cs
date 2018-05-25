using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEndlessScroll : MonoBehaviour {

    public float screenWidth = 16f;
    public float scrollSpeed = 0.1f;

    Vector2 startPos;


	// Use this for initialization
	void Start () {

        startPos = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 newVec = transform.position;
        newVec.x += scrollSpeed * Time.deltaTime;
        transform.position = newVec;

        if (Mathf.Abs(transform.position.x - startPos.x) > screenWidth)
            transform.position = startPos;

		
	}
}
