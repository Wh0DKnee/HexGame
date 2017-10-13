using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface MouseEvents<T>{

    event Action<T> mouseEnter;
    event Action<T> mouseExit;
    event Action<T> mouseDown;
    event Action<T> mouseOver;
}
