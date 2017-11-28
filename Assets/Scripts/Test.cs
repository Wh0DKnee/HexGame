using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private Plane plane;

    private void Awake() {
        plane = new Plane(Vector3.up, Vector3.zero);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
            Vector3 mousePosNear =new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
            Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
            Debug.DrawRay(mousePosN, mousePosF-mousePosN, Color.green);

            HexCoordinates coords = null;
            float distance;
            Ray ray = new Ray(mousePosN, mousePosF - mousePosN);
            if (plane.Raycast(ray, out distance)) {
                coords = HexMath.WorldPosToHex(ray.GetPoint(distance));
            } else {
                return;
            }

            Debug.Log(coords.ToString());
        }
	}
}
