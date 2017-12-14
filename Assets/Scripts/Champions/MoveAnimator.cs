using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MoveAnimator : MonoBehaviour {

    public static MoveAnimator instance;
    private float speed = 2f;

	void Awake() {
        if(instance != null) {
            Debug.LogError("more than on moveanimator");
            return;
        }
        instance = this;
    }

    public void Move(Champion champion, HexCoordinates target) {
        Cell targetCell = HexGrid.Instance.GetCell(target);
        List<Cell> path = AStarPathfinding.FindPath(champion.GetCell(), targetCell);
        StartCoroutine(AnimatePathMovement(champion, path));
    }

    private IEnumerator AnimatePathMovement(Champion champion, List<Cell> path) {
        for (int i = 1; i < path.Count; i++) {
            yield return StartCoroutine(AnimateMove(champion, path[i]));
        }
    }

    private IEnumerator AnimateMove(Champion champion, Cell cell) {
        float progress = 0f;
        Vector3 startPos = champion.transform.position;
        Vector3 targetPos = cell.coordinates.ToWorldPosition();
        champion.transform.forward = targetPos - startPos;
        while(progress < 1f) {
            print(progress);
            champion.transform.position = Vector3.Lerp(startPos, targetPos, progress);
            progress += Time.deltaTime / (1f/speed);
            yield return null;
        }
        champion.transform.position = targetPos;
    }
}
