using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public FloatVariable gameTime;

	// Update is called once per frame
	void Update ()
    {
        gameTime.ApplyChange(Time.deltaTime);
	}
}
