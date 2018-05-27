using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HighScoreLoader : MonoBehaviour
{
    public SaveLoadManager slm;

	// Use this for initialization
	void Start ()
    {
        slm.filePath = Application.persistentDataPath + "/HighScore.bin";

        if (slm.data == null)
            slm.data = new Dictionary<string, int>();

        FileInfo info = new FileInfo(slm.filePath);

        if (info.Exists)
        {
            slm.LoadFromFile();
        }
	}

    
}




