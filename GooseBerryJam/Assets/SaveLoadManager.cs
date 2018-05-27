using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[CreateAssetMenu]
public class SaveLoadManager : ScriptableObject
{
    [HideInInspector]
    public string filePath;

    public Dictionary<string, int> data;

    public IntVariable highScore;

    public void LoadFromFile()
    {
        FileStream stream = File.Open(filePath, FileMode.Open);
        var formatter = new BinaryFormatter();
        if (stream.Length != 0)
            data = formatter.Deserialize(stream) as Dictionary<string, int>;
        stream.Close();

        if (data.ContainsKey("HighScore"))
        {
            highScore.SetValue(data["HighScore"]);
        }
        else
        {
            highScore.SetValue(0);
        }

    }

    public void SaveFile()
    {
        bool dirty = false;

        if (data.ContainsKey("HighScore"))
        {
            if (highScore.value >= data["HighScore"])
            {
                data["HighScore"] = highScore.value;
                dirty = true;
            }
        }
        else
        {
            data.Add("HighScore", highScore.value);
            dirty = true;
        }

        if (dirty)
        {
            FileStream fs = File.Open(filePath, FileMode.OpenOrCreate);
            var formatter = new BinaryFormatter();
            formatter.Serialize(fs, data);
            fs.Close();
            Debug.Log("fileSaved");
        }

    }
}