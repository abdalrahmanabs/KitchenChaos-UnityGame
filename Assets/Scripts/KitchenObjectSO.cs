using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="KitchenObjects",fileName ="Object")]
public class KitchenObjectSO : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public GameObject prefab;


}
