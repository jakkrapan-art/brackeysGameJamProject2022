using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item/ItemData")]
public class ItemData : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
    public string itemDescription;
}
