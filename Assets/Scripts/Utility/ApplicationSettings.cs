using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationSettings : MonoBehaviour {

    private void Awake() {
        Application.runInBackground = true;
    }
}
