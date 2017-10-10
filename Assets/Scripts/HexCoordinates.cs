using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HexCoordinates : ScriptableObject {

    public int x, y, z;
    private float size = 1; //height is size * 2, width is sqrt(3)/2 * height

    public void Init(int q, int r, int s) {
        this.x = q;
        this.y = r;
        this.z = s;
        Debug.Assert(q + r + s == 0, "Invalid coordinates");
    }

    public void Init(int q, int r) {
        this.x = q;
        this.y = r;
        this.z = -q - r;
    }

    public static HexCoordinates CreateInstance(int _x, int _y, int _z) {
        HexCoordinates coords = ScriptableObject.CreateInstance<HexCoordinates>();
        coords.Init(_x, _y, _z);
        return coords;
    }

    public static HexCoordinates CreateInstance(int _x, int _y) {
        HexCoordinates coords = ScriptableObject.CreateInstance<HexCoordinates>();
        coords.Init(_x, _y);
        return coords;
    }

    public static bool operator ==(HexCoordinates a, HexCoordinates b) {
        return a.x == b.x && a.y == b.y && a.z == b.z;
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
        float _x = size * Mathf.Sqrt(3) * (x + z/2f);
        float _z = -size * 3/2f * z;
        return new Vector3(_x, 0, _z);
    }

    HexCoordinates GetNeighbor(int direction) {
       return HexMath.HexNeighbor(this, direction);
    }

    public override string ToString() {
        return ("x: " + x + ", y: " + y + ", z: " + z);
    }
}
