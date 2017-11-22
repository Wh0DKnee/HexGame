using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Newtonsoft.Json;

[Serializable]
public class HexCoordinates{

    public int X { get; private set; }
    public int Y { get; private set; }
    public int Z { get; private set; }
    public static readonly float size = 1; //height is size * 2, width is sqrt(3)/2 * height
    public static readonly float height = size * 2;
    public static readonly float width = (Mathf.Sqrt(3) / 2f) * height;

    [JsonConstructor]
    public HexCoordinates(int x, int y, int z) {
        X = x;
        Y = y;
        Z = z;
        Debug.Assert(x + y + z == 0, "Invalid coordinates");
    }

    public HexCoordinates(int x, int y) {
        X = x;
        Y = y;
        Z = -x - y;
    }

    public static bool operator ==(HexCoordinates a, HexCoordinates b) {
        return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    }

    public static bool operator !=(HexCoordinates a, HexCoordinates b) {
        return !(a==b);
    }

    public static HexCoordinates operator + (HexCoordinates a, HexCoordinates b){
        return HexMath.HexAdd(a, b);
    }

    public static HexCoordinates operator - (HexCoordinates a, HexCoordinates b) {
        return HexMath.HexSubtract(a, b);
    }

    public static HexCoordinates operator * (HexCoordinates a, int k) {
        return HexMath.HexMultiply(a, k);
    }

    public Vector3 ToWorldPosition() {
        float _x = size * Mathf.Sqrt(3) * (X + Z/2f);
        float _z = -size * 3/2f * Z;
        return new Vector3(_x, 0, _z);
    }

    HexCoordinates GetNeighbor(int direction) {
       return HexMath.HexNeighbor(this, direction);
    }

    public override string ToString() {
        return ("x: " + X + ", y: " + Y + ", z: " + Z);
    }
}
