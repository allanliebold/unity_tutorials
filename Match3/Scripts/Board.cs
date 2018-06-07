using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

  public int width;
  public int height;
  
  public int borderSize;
  
  public GameObject tilePrefab;
  
  Tile[,] m_allTiles;
  GamePiece[,] m_allGamePieces;
  
  void Start () {
    m_allTiles = new Tile[width,height];
    m_allGamePieces = new GamePiece[width,height];
    
    SetupTiles();
    SetupCamera();
  }
  
  void SetupTiles() {
     for (int i = 0; i < width; i++) {
      for(int j = 0; i < height; j++) {
        GameObject tile = Instantiate (tilePrefab, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
        tile.name = "Tile (" + i + "," + j + ")";
        m_allTiles [i, j] = tile.GetComponent<Tile>();
        tile.transform.parent = transform;
      }       
     }
  }
  
  void SetupCamera() {
    Camera.main.transform.position = new Vector3((float) width / 2, (float) height / 2, -10f);
    
    float aspectRatio = (float) Screen.width / (float) Screen.height;
    float verticalSize = (float) height / 2f + (float) borderSize;
    float horizontalSize = (float) width / 2f + (float) borderSize / aspectRatio;
    
    Camera.main.orthographicSize = (verticalSize > horizontalSize) ? verticalSize : horizontalSize;
    
  }
}
