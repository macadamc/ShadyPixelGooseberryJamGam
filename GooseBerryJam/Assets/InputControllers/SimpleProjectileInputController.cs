using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectileInputController : InputController {

    private void Awake()
    {
        move = transform.forward;
    }
}
