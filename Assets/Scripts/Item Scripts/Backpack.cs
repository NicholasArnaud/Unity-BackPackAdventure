using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Backpack", menuName = "Backpack")]
public class Backpack : ScriptableObject
{
    public List<Item> Inventory;
    public int Capacity;
    public float MaxCarryWeight;        // Change
}
