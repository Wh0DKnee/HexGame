using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveHandler{

    void HandleMove(Champion champion, HexCoordinates coordinates);
}
