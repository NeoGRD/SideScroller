using System;
using UnityEngine;

public class vector2
{
    private int v1;
    private int v2;

    public vector2(int v1, int v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }

    public static implicit operator Vector2(vector2 v)
    {
        throw new NotImplementedException();
    }
}