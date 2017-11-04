using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateControllerInitializer : MonoBehaviour {

    public static GameStateControllerInitializer instance;

    public GameStateController gameStateController;

	void Awake() {
        if(instance != null) {
            Debug.LogError("more than one instance of gamestatecontrollerinitializer");
            return;
        }
        instance = this;
    }

    public void InitializeGameStateController() {
        gameStateController.Initialize();
    }
}
