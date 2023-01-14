using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Keeper", menuName = "Inventory")]
public class SO_Inventory : ScriptableObject
{
    [SerializeField]
    public Sprite[] spritesOfSlots;
}
