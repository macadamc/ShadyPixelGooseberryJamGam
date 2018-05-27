using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEventTimeLine : MonoBehaviour {

    public List<TimeLineEntry> entrys;

    private void Awake()
    {
        foreach (TimeLineEntry entry in entrys)
        {
            entry.executeTime += Time.time;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        foreach (TimeLineEntry entry in entrys)
        {
            if(entry.executed == false && Time.time >= entry.executeTime)
            {
                entry.events.Invoke();
                entry.executed = true;
            }
        }
	}

    public void log(string value)
    {
        Debug.Log(value);
    }
}

[System.Serializable]
public class TimeLineEntry
{
    public bool executed = false;
    public float executeTime;
    public UnityEngine.Events.UnityEvent events;
}
