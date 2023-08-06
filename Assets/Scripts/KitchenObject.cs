using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    IKitchenObjectParent kitchenObjectParent;
    public void SetKithcenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent= kitchenObjectParent;
        transform.parent=kitchenObjectParent.GetObjectFollowTransform();
        kitchenObjectParent.SetKitchenObject(this);
        transform.localPosition=Vector3.zero;
    }
    public IKitchenObjectParent GetKitchenObjectParent(){return kitchenObjectParent;}
}
