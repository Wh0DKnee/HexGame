using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState {

    public abstract void Tick();

    public virtual void OnStateEnter() {

    }

    public virtual void OnStateExit() {

    }

    public GameState() {}
}
