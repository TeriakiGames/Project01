using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
//using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public Vector3 rawInputMovement;

    public void OnMovement(InputAction.CallbackContext value)
    {
       Vector2 inputMovement = value.ReadValue<Vector2>();
       rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    } 
}
