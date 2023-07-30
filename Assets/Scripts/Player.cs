using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    float speed = 12;
    bool isWalking = false;

    // Update is called once per frame
    void Update()
    {

        MoveAndRotate();



    }

    void MoveAndRotate()
    {
        Vector3 moveDir = playerInput.GetMovementNormalized() * Time.deltaTime * speed;
        transform.position += moveDir;
        //rotate
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * 10);

        isWalking = moveDir != Vector3.zero;
    }

    public bool IsWalking() { return isWalking; }
}
