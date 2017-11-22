using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveHandler : IStateHandler{

    void HandleMove(Champion champion, HexCoordinates coordinates);
}
