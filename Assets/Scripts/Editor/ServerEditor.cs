using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Server))]
public class ServerEditor : Editor {

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        Server server = (Server) target;

        if(GUILayout.Button("add client")) {
            Instantiate(server.clientPrefab);
        }
    }
}
