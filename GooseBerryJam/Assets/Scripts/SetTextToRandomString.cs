using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextToRandomString : MonoBehaviour {

    public StringList stringList;
    Text t;

    private void OnEnable()
    {
        if(t == null)
            t = GetComponent<Text>();

        t.text = stringList.strings[ Random.Range(0, stringList.strings.Count) ];
    }
}
