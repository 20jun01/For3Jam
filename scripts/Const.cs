using System;
using UnityEngine;

public enum Direction {
    None = -1,
    Right,
    Up,
    Left,
    Down
}

public static class Colors
{
    public static readonly Color AColor = new Color(210f/255f, 217f/255f, 145f/255f);
    public static readonly Color WColor = new Color(123f/255f, 179f/255f, 157f/255f);
    public static readonly Color SColor = new Color(145f/255f, 151f/255f, 201f/255f);
    public static readonly Color DColor = new Color(181f/255f, 141f/255f, 167f/255f);
    public static readonly Color DefaultColor = new Color(214f/255f, 179f/255f, 144f/255f);
}