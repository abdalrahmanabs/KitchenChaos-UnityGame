using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    public void SetKitchenObject(KitchenObject passedObject);
    public KitchenObject GetKitchenObject();
    public void ClearKitchenObject();
    public Transform GetObjectFollowTransform();
    public bool HasKitchenObject();
}
