using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Tool")]
public class ToolItem : Item
{
    public ToolItem (string name, int weight) : base(name, weight)
    {
        
    }
}
