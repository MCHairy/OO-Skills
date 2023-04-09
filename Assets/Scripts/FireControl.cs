using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//ABSTRACTION
public interface FireControl
{
    public void Fire(InputAction.CallbackContext context) { }
}
