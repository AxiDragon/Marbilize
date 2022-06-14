using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Item", fileName = "Item")]
public class ItemScriptable : ScriptableObject
{
    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;
    public Color itemColor; //Green - Stats, Red - Explosions, Yellow - Money, Gray - Other
}
