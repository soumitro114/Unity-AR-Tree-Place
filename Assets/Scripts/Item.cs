using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item1", menuName = "Additem/Item")]
public class Item : ScriptableObject
{ 
    public GameObject itemPreFab;
    public Sprite itemimage;
}
