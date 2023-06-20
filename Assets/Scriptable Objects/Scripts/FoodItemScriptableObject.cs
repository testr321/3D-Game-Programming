using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item Scriptable Object", menuName = "Scriptable Objects/Food Item Scriptable Object")]
public class FoodItemScriptableObject : ScriptableObject
{
    public GameObject[] items;
    public bool[] cooked;   
}
