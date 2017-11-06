using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class GameBoardLoader : MonoBehaviour {

    private string gameBoardDataFileName = "board.json";

    private void Awake() {
        LoadGameBoardFromJson();
    }

    private void LoadGameBoardFromJson() {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameBoardDataFileName);

        if (File.Exists(filePath)) {
            string dataAsJson = File.ReadAllText(filePath);
            List<HexCoordinates> cellCoordinates = JsonConvert.DeserializeObject<List<HexCoordinates>>(dataAsJson);
            HexGrid.Instance.AddCells(cellCoordinates);
        } else {
            Debug.LogError("Cant find board.json file");
        }
    }
}
