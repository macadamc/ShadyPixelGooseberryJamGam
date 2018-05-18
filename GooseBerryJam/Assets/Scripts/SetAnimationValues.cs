using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationValues : MonoBehaviour {

    internal Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateValues();
    }

    public virtual void UpdateValues()
    {
        if (anim == null)
            return;
    }
}
