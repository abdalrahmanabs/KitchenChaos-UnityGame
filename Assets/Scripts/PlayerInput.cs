using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputAction playerinputAction;

    void Awake()
    {
        playerinputAction = new PlayerInputAction();
        playerinputAction.Player.Enable();

    }

    public Vector3 GetMovementNormalized()
    {
        Vector3 Movement = new Vector3(playerinputAction.Player.Movement.ReadValue<Vector2>().x
        , 0, playerinputAction.Player.Movement.ReadValue<Vector2>().y);
        Movement = Movement.normalized;

        return Movement;
    }
}
