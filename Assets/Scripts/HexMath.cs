using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexMath {

    public static readonly HexCoordinates[] directions = {   HexCoordinates.CreateInstance(1,-1,0), HexCoordinates.CreateInstance(1,0,-1), HexCoordinates.CreateInstance(0,1,-1),
                                    HexCoordinates.CreateInstance(-1,1,0), HexCoordinates.CreateInstance(-1,0,1), HexCoordinates.CreateInstance(0,-1,1)};

    public static HexCoordinates HexAdd(HexCoordinates a, HexCoordinates b) {
        return HexCoordinates.CreateInstance(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static HexCoordinates HexSubtract(HexCoordinates a, HexCoordinates b) {
        return HexCoordinates.CreateInstance(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static HexCoordinates HexMultiply(HexCoordinates a, int k) {
        return HexCoordinates.CreateInstance(a.x * k, a.y * k, a.z * k);
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

    // return HexCoordinates closest to the input coordinates
    public static HexCoordinates CubeRound(Vector3 coordinates) {
        int x = Mathf.RoundToInt(coordinates.x);
        int y = Mathf.RoundToInt(coordinates.y);
        int z = Mathf.RoundToInt(coordinates.z);

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
        return HexCoordinates.CreateInstance(x, y, z);
    }

    public static List<HexCoordinates> DrawLine(HexCoordinates a, HexCoordinates b) {
        int distance = Distance(a, b);
        List<HexCoordinates> result = new List<HexCoordinates>();
        if(distance == 0) {
            return result;
        }
        for (int i = 0; i <= distance; i++) {
            result.Add(CubeRound(Vector3.Lerp(new Vector3(a.x, a.y, a.z), new Vector3(b.x, b.y, b.z), 1.0f/distance*i)));
        }
        return result;
    }
}
