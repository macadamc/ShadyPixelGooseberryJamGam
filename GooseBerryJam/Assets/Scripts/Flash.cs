using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

    public GameObject objToFlash;
    public float flashTime = 0.1f;

    float nextFlashTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Time.time > nextFlashTime)
        {
            FlashObj();
        }
		
	}

    public void FlashObj()
    {
        SetNextFlashTime();
        objToFlash.SetActive(!objToFlash.activeInHierarchy);
    }

    public void SetNextFlashTime()
    {
        nextFlashTime = Time.time + flashTime;
    }
}
