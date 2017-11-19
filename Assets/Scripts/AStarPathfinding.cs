using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding {
    public static class AStarPathfinding {

        public static List<Cell> FindPath(Cell start, Cell goal) {
            List<Cell> closedSet = new List<Cell>();
            List<Cell> openSet = new List<Cell>(){ start };
            Dictionary<Cell, Cell> cameFrom = new Dictionary<Cell, Cell>();
            Dictionary<Cell, int> gScore = new Dictionary<Cell, int>();

            foreach (Cell cell in HexGrid.Instance.cells) {
                gScore.Add(cell, int.MaxValue);
            }

            gScore[start] = 0;

            Dictionary<Cell, int> fScore = new Dictionary<Cell, int>();

            foreach (Cell cell in HexGrid.Instance.cells) {
                fScore.Add(cell, int.MaxValue);
            }

            fScore[start] = CostEstimate(start, goal);

            while(openSet.Count > 0) {
                Cell current = GetCellWithLowestFScore(openSet, fScore);
                
                if(current == goal) {
                    return ReconstructPath(cameFrom, current);
                }

                openSet.Remove(current);
                closedSet.Add(current);

                for (int i = 0; i < 6; i++) {
                    HexCoordinates neighborCoords = HexMath.HexNeighbor(current.coordinates, i);
                    Cell neighbor = HexGrid.Instance.GetCell(neighborCoords);
                    if(closedSet.Contains(neighbor) || !IsCellPassable(neighbor)) {
                        continue;
                    }
                    if (!openSet.Contains(neighbor)) {
                        openSet.Add(neighbor);
                    }
                    int tentativeGScore = gScore[current] + 1;
                    if(tentativeGScore >= gScore[neighbor]) {
                        continue;
                    }

                    cameFrom[neighbor] = current;
                    //cameFrom.Add(neighbor, current);
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + CostEstimate(neighbor, goal);
                }
            }
            Debug.LogError("Could not find path, returning null");
            return null;
        }

        private static int CostEstimate(Cell start, Cell goal) {
            return HexMath.HexDistance(start.coordinates, goal.coordinates);
        }

        private static Cell GetCellWithLowestFScore(List<Cell> cells, Dictionary<Cell, int> fScoreDic) {
            int lowestFScore = int.MaxValue;
            Cell bestCell = cells[0];
            foreach (Cell cell in cells) {
                if (fScoreDic[cell] < lowestFScore) {
                    bestCell = cell;
                    lowestFScore = fScoreDic[cell];
                }
            }
            return bestCell;
        }

        private static bool IsCellPassable(Cell cell) {
            if(cell == null) { return false; }
            if(cell.HasChamp()) { return false; }

            return true;
        }

        private static List<Cell> ReconstructPath(Dictionary<Cell, Cell> cameFrom, Cell goal) {
            List<Cell> path = new List<Cell>(){ goal };
            Cell current = goal;
            while (cameFrom.ContainsKey(current)) {
                current = cameFrom[current];
                path.Insert(0, current);
            }
            return path;
        }      

    }
}
