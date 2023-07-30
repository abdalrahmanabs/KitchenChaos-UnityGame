using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{


    public Vector3 GetMovementNormalized()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal")
        , 0, Input.GetAxis("Vertical"));


        return Movement;
    }
}
