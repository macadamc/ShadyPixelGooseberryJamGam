﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

    public static DontDestroyOnLoad instance;

	// Use this for initialization
	void Start () {

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
