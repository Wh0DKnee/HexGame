using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HighlightState {

    CellHighlighter highlighter;

    public abstract void Tick();

    public virtual void OnStateEnter() {

    }

    public virtual void OnStateExit() {

    }

    public HighlightState(CellHighlighter _highlighter) {
        highlighter = _highlighter;
    }
}
