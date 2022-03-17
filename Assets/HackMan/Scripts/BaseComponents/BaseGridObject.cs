using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public struct IntVector2
{
    public int x;
    public int y;

    private static IntVector2 zero => new IntVector2(0, 0);
    
    public IntVector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class BaseGridObject : MonoBehaviour
{
    public IntVector2 GridPosition;
}

