using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImageWidthToIntVar : MonoBehaviour {

    public IntVariable var;
    public Image image;
    public float imageWidth;

    private void OnEnable()
    {
        if (image == null)
            image = GetComponent<Image>();
	}

    private void Update()
    {
        if(image!=null && var!=null)
            image.rectTransform.sizeDelta = new Vector2(imageWidth * var.value, image.rectTransform.sizeDelta.y);

    }
}
