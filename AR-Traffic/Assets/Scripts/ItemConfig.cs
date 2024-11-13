using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Items")]

public class ItemConfig : ScriptableObject
{
    public List<Item> _objects;
}
