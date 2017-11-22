using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexMath {

    public static readonly HexCoordinates[] directions = {   new HexCoordinates(1,-1,0), new HexCoordinates(1,0,-1), new HexCoordinates(0,1,-1),
                                    new HexCoordinates(-1,1,0), new HexCoordinates(-1,0,1), new HexCoordinates(0,-1,1)};

    public static HexCoordinates HexAdd(HexCoordinates a, HexCoordinates b) {
        return new HexCoordinates(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static HexCoordinates HexSubtract(HexCoordinates a, HexCoordinates b) {
        return new HexCoordinates(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static HexCoordinates HexMultiply(HexCoordinates a, int k) {
        return new HexCoordinates(a.X * k, a.Y * k, a.Z * k);
    }

    public static HexCoordinates HexMirrorAtOrigin(HexCoordinates h) {
        return new HexCoordinates(-h.X, -h.Y, -h.Z);
    }

    public static int HexLength(HexCoordinates hex) {
        return (int)((Mathf.Abs(hex.X) + Mathf.Abs(hex.Y) + Mathf.Abs(hex.Z)) / 2);
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

    // return HexCoordinates closest to the input coordinates
    public static HexCoordinates CubeRound(Vector3 coordinates) {
        int x = Mathf.RoundToInt(coordinates.x * HexCoordinates.width);
        int y = Mathf.RoundToInt(coordinates.y * HexCoordinates.width);
        int z = Mathf.RoundToInt(coordinates.z * HexCoordinates.width);

        float xDiff = Mathf.Abs(x - coordinates.x);
        float yDiff = Mathf.Abs(y - coordinates.y);
        float zDiff = Mathf.Abs(z - coordinates.z);

        if(xDiff > yDiff && xDiff > zDiff) {
            x = -y-z;
        } else if(yDiff > zDiff) {
            y = -x-z;
        } else {
            z = -x-y;
        }
        return new HexCoordinates(x, y, z);
    }

    public static List<HexCoordinates> DrawLine(HexCoordinates a, HexCoordinates b) {
        int distance = HexDistance(a, b);
        List<HexCoordinates> result = new List<HexCoordinates>();
        if(distance == 0) {
            return result;
        }
        for (int i = 0; i <= distance; i++) {
            result.Add(CubeRound(Vector3.Lerp(new Vector3(a.X, a.Y, a.Z), new Vector3(b.X, b.Y, b.Z), 1.0f/distance*i)));
        }
        return result;
    }
}
