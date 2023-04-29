using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MenuScriptableObject", menuName = "ScriptableObjects/MenuScriptableObject")]
public class MenuScriptableObject : ScriptableObject
{
    public GameObject[] items;
}
