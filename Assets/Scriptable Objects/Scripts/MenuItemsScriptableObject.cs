using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Menu Item Scriptable Object", menuName = "Scriptable Objects/Menu Item Scriptable Object")]
public class MenuItemsScriptableObject : ScriptableObject
{
    public FoodItemScriptableObject[] items;

    public int GetLen()
    {
        return items.Length;
    }
}
