using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexMath {

    public static readonly HexCoordinates[] directions = {   new HexCoordinates(1,-1,0), new HexCoordinates(1,0,-1), new HexCoordinates(0,1,-1),
                                    new HexCoordinates(-1,1,0), new HexCoordinates(-1,0,1), new HexCoordinates(0,-1,1)};

    public static HexCoordinates HexAdd(HexCoordinates a, HexCoordinates b) {
        return new HexCoordinates(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static HexCoordinates HexSubtract(HexCoordinates a, HexCoordinates b) {
        return new HexCoordinates(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static HexCoordinates HexMultiply(HexCoordinates a, int k) {
        return new HexCoordinates(a.x * k, a.y * k, a.z * k);
    }

    public static int HexLength(HexCoordinates hex) {
        return (int)((Mathf.Abs(hex.x) + Mathf.Abs(hex.y) + Mathf.Abs(hex.z)) / 2);
    }

    public static int HexDistance(HexCoordinates a, HexCoordinates b) {
        return HexLength(HexSubtract(a, b));
    }

    public static HexCoordinates HexDirection(int direction) {
        Debug.Assert(direction >= 0 && direction < 6, "Invalid direction");
        return directions[direction];
    }

    public static HexCoordinates HexNeighbor(HexCoordinates hex, int direction) {
        return HexAdd(hex, HexDirection(direction));
    }

    public static int Distance(HexCoordinates a, HexCoordinates b){
        return (Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z)) / 2;
    }
}
