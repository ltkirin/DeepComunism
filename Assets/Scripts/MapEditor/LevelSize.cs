using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LevelSize 
{
    public LevelSize(int with, int height)
    {
        With = with;
        Height = height;
    }

    [SerializeField]
    public int With { get; set; }
    [SerializeField]
    public int Height { get; set; }
}
