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

    private void ManuallyTriggerMouseEnterEvent() {
        //TODO: fix calculation
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit hit;
        HexCoordinates coords = null;
        if(Physics.Raycast(mousePos, Camera.main.transform.forward, out hit)) {
            coords = HexMath.CubeRound(hit.point);
        }

        Cell cell = HexGrid.Instance.GetCell(coords);
        if (cell != null) {
            CellMouseEnter(cell);
        }
    }

    public abstract void CellMouseEnter(Cell cell);

    public abstract void CellMouseExit(Cell cell);
}
