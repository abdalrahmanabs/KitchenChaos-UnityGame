using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputAction playerinputAction;
    public event EventHandler OnInteractionFired;



    void Awake()
    {
        playerinputAction = new PlayerInputAction();
        playerinputAction.Player.Enable();
        playerinputAction.Player.Interact.performed+=Interact_Performed;

    }

    private void Interact_Performed(InputAction.CallbackContext context)
    {
       OnInteractionFired?.Invoke(this,EventArgs.Empty);
    }

    public Vector3 GetMovementNormalized()
    {
        Vector3 Movement = new Vector3(playerinputAction.Player.Movement.ReadValue<Vector2>().x
        , 0, playerinputAction.Player.Movement.ReadValue<Vector2>().y);
        Movement = Movement.normalized;

        return Movement;
    }
}
