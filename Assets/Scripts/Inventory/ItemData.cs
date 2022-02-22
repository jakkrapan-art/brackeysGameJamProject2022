using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Item/Data", fileName = "Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string itemDescription;
}
