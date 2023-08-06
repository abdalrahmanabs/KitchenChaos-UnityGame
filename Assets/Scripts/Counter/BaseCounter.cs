using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{

    [SerializeField] private Transform topPoint;
    private KitchenObject kitchenObject = null;
    public virtual void Interact(Player player)
    {
        Debug.LogError("CALLED FROM BASE COUNTER CLASS");
    }

    public void SetKitchenObject(KitchenObject passedObject)
    {
        kitchenObject = passedObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

    public Transform GetObjectFollowTransform()
    {
        return topPoint;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
}
