using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReachTopOfWall : MonoBehaviour {

    public UnityEvent onReachTop;
    Transform finishLine;
    bool finished;

	// Use this for initialization
	void Start ()
    {
        finishLine = GameObject.FindGameObjectWithTag("Finish").transform;
		
	}
	
	// Update is called once per frame
	void Update () {

        Check();
		
	}

    public void Check()
    {
        if(transform.position.y >= finishLine.transform.position.y && !finished)
        {
            finished = true;
            onReachTop.Invoke();
        }
    }
}
