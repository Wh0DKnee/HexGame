using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellListenerStateHighlighter : StateHighlighter {

    public CellListenerStateHighlighter(CellHighlighter _highlighter) : base(_highlighter) {
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        foreach (Cell cell in HexGrid.Instance.cells) {
            cell.mouseEnter += CellMouseEnter;
            cell.mouseExit += CellMouseExit;
        }
        //ManuallyTriggerMouseEnterEvent();
    }

    public override void OnStateExit() {
        base.OnStateExit();
        foreach (Cell cell in HexGrid.Instance.cells) {
            cell.mouseEnter -= CellMouseEnter;
            cell.mouseExit -= CellMouseExit;
        }
    }

    private void ManuallyTriggerMouseEnterEvent() { //TODO: fix calculation
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
        RaycastHit hit;
        HexCoordinates coords = null;
        if(Physics.Raycast(mousePosN, mousePosF - mousePosN, out hit, 500f)) {
            coords = HexMath.CubeRound(hit.point);
        } else {
            return;
        }

        Cell cell = HexGrid.Instance.GetCell(coords);
        if (cell != null) {
            CellMouseEnter(cell);
        }
    }

    public abstract void CellMouseEnter(Cell cell);

    public abstract void CellMouseExit(Cell cell);
}
