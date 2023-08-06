using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    private const float PLAYER_RADUIS = 0.7f;
    private const float PLAYER_HEIGHT = 2f;

    private const float INTERACTION_DISTANCE = 2;


    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private LayerMask interactionLayer;

    [SerializeField] Transform ObjectHoldPoint;

    KitchenObject kitchenObject;

    Vector3 lastInteractDir;


    BaseCounter selectedCounter;

    float speed = 24;
    bool isWalking = false;

    public event EventHandler<OnCounterSelectedEventArgs> OnCounterSelected;

    public static Player Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

    public class OnCounterSelectedEventArgs
    {
        public BaseCounter selectedCounter;
    }
    void Start()
    {
        playerInput.OnInteractionFired += Interact;
    }

    private void Interact(object sender, EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInteractions();
        HandleMovementAndRotation();
    }


    private void HandleInteractions()
    {

        // Get the input vector from the player input
        Vector3 inputVector = playerInput.GetMovementNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.z);

        // If the input vector is not zero, update the lastInteractDir variable
        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        // Draw a debug line to show the direction of the raycast

        // Cast a ray from the player in the lastInteractDir direction
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit hit, INTERACTION_DISTANCE))
        {
            if (hit.transform.TryGetComponent<BaseCounter>(out BaseCounter cleanCounter))
            {
                SelectCounter(cleanCounter);
            }
            else
            {
                SelectCounter(null);
            }
        }

        else
        {
            SelectCounter(null);
        }
    }

    void HandleMovementAndRotation()
    {
        float moveDistance = speed * Time.deltaTime;
        Vector3 moveDir = playerInput.GetMovementNormalized() * Time.deltaTime * speed;



        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PLAYER_HEIGHT
        , PLAYER_RADUIS, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PLAYER_HEIGHT
        , PLAYER_RADUIS, moveDirX, moveDistance);

            if (canMove)
            {
                moveDir = moveDirX;
            }
            if (!canMove)
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PLAYER_HEIGHT
            , PLAYER_RADUIS, moveDirZ, moveDistance);
                if (!canMove)
                    return;
                moveDir = moveDirZ;

            }


        }


        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }
        isWalking = moveDir != Vector3.zero;


        //rotate

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * 10);
    }

    public bool IsWalking() { return isWalking; }

    private void SelectCounter(BaseCounter selectedCounter)
    {

        this.selectedCounter = selectedCounter;
        OnCounterSelected?.Invoke(this, new OnCounterSelectedEventArgs { selectedCounter = selectedCounter });
    }

    public void SetKitchenObject(KitchenObject passedObject)
    {
        this.kitchenObject = passedObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public Transform GetObjectFollowTransform()
    {
        return ObjectHoldPoint;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
